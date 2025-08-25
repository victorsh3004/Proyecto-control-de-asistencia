CREATE DATABASE DBCONTRLATTENDANCEPROJECT
GO


USE DBCONTRLATTENDANCEPROJECT
GO

create table ROL(
IdRol int primary key identity,
Descripcion varchar(50),
FechaRegistro datetime default getdate()
)
GO

create table TURNO(
IdTurno int primary key identity,
Descripcion varchar(50),
FechaRegistro datetime default getdate()
)
GO

create table USUARIO(
IdUsuario int primary key identity,
Documento varchar(50),
NombreCompleto varchar(100),
Correo varchar(50),
Clave varchar(50),
Estado bit,
Huella varbinary(max),
IdRol int references ROL(IdRol),
FechaRegistro datetime default getdate()
)
GO

create table ASISTENCIA(
IdAsistencia int primary key identity,
IdUsuario varchar(50),
IdTurno int references TURNO(IdTurno),
HoraIngreso datetime,
HoraSalida datetime,
EstadoAsistencia bit,
FechaRegistro datetime default getdate()
)
GO

create table PERMISO(
IdPermiso int primary key identity,
IdRol int references ROL(IdRol),
NombreMenu varchar(100),
FechaRegistro datetime default getdate()
)
GO

insert into ROL(Descripcion) values ('ADMINISTRADOR'),('Empleado')
GO
insert into TURNO(Descripcion) values ('Dia'),('Noche')
GO
insert into PERMISO(IdRol,NombreMenu) values  (1,'menuusuarios'),(1,'menumantenedor'),(1,'menuasistencia'),(1,'menuparteoperativo'),(1,'menuEstadoPO'),(1,'menuacompaniamiento'),(1,'menureportes'),(1,'menuacercade')
GO
insert into PERMISO(IdRol,NombreMenu) values  (2,'menuusuarios'),(2,'menuasistencia'),(2,'menuparteoperativo'),(2,'menuEstadoPO'),(2,'menuacompaniamiento')
GO

create PROC SP_EDITUSUARIO(
@IdUsuario int,
@documento varchar(50),
@NombreCompleto varchar(100),
@Correo varchar(50),
@Clave varchar (100),
@IdRol int,
@Estado bit,
@Respuesta bit output,
@Mensaje varchar(500) output
)
as
begin
	set @Respuesta = 0
	set @Mensaje = ''

	if not exists(select * from USUARIO where Documento = @documento and IdUsuario != @IdUsuario)
	begin
		update usuario set
		Documento = @documento,
		NombreCompleto = @NombreCompleto,
		Correo = @Correo,
		Clave = @Clave,
		IdRol = @IdRol,
		Estado = @Estado
		where IdUsuario = @IdUsuario

		set @Respuesta = 1
		
	end
	else
		set @Mensaje = 'No se puede repetir el documento para mas de un usuario'
end
GO

create PROC SP_EDITARUSUARIOHUELLA(
@IdUsuario int,
@Huella varbinary(max),
@Respuesta bit output,
@Mensaje varchar(500) output
)
as
begin
	set @Respuesta = 0
	set @Mensaje = ''

	if exists(select * from USUARIO where IdUsuario = @IdUsuario)
	begin
		update USUARIO set
		Huella = @Huella where IdUsuario = @IdUsuario

		set @Respuesta = 1
		
	end
	else
		set @Mensaje = 'No se encuentra el usuario'
end
GO

create PROC SP_ELIMINARUSUARIO(
@IdUsuario int,
@Respuesta bit output,
@Mensaje varchar(500) output
)
as
begin
	set @Respuesta = 0
	set @Mensaje = ''
	Declare @pasoreglas bit = 1

	if exists(select * from asistencia a
	inner join USUARIO u ON a.IdUsuario = u.IdUsuario
	where u.IdUsuario = @IdUsuario
	)
	BEGIN
		SET @pasoreglas = 0
		SET @Respuesta = 0
		SET @Mensaje = @Mensaje + 'No se puede eliminar el usuario se encuentra relacionado a una COMPRA\n'
	END

	if(@pasoreglas = 1)
	begin
		delete from USUARIO where IdUsuario = @IdUsuario
		set @Respuesta = 1
	end

end
GO

create PROC SP_REGISTRARASISTENCIA(
@IdUsuario int,
@Respuesta int output,
@Mensaje varchar(500) output
)
as
begin
	set @Respuesta = -3
	set @Mensaje = ''
	/**/
	 Declare @HoraSalida DATETIME

	SELECT TOP 1 @HoraSalida = HoraSalida
    FROM ASISTENCIA 
    WHERE IdUsuario = @IdUsuario
    ORDER BY IdAsistencia DESC

	if not exists (select * from ASISTENCIA where IdUsuario = @IdUsuario)
	begin
		insert into asistencia (IdUsuario, HoraIngreso, EstadoAsistencia) values (@IdUsuario,GETDATE(),0)
			set @Respuesta = 0
	end
	else if exists(select * from ASISTENCIA where IdUsuario = @IdUsuario and HoraSalida IS NULL)
	begin
		if exists(select * from ASISTENCIA where IdUsuario = @IdUsuario and HoraSalida IS NULL and HoraIngreso < DATEADD(MINUTE, -3, GETDATE()))
			begin
				update ASISTENCIA set
				HoraSalida = GETDATE(),
				EstadoAsistencia = 1
				where IdUsuario = @IdUsuario
				and HoraSalida IS NULL

				set @Respuesta = 1
			end
		else
			begin
				set @Mensaje = 'Ya registro su ingreso'
				set @Respuesta = -2
			end
		
		
	end
	else if exists(select * from ASISTENCIA where IdUsuario = @IdUsuario and HoraIngreso IS NOT NULL and @HoraSalida < DATEADD(MINUTE, -2, GETDATE()))
		begin
			
			insert into asistencia (IdUsuario, HoraIngreso, EstadoAsistencia) values (@IdUsuario,GETDATE(),0)
			set @Respuesta = 0
		end
	else
		begin
		set @Mensaje = 'Ya registro su salida'
		set @Respuesta = -1
		end
end
GO

create PROC SP_REGISTRARUSUARIO(
@documento varchar(50),
@NombreCompleto varchar(100),
@Correo varchar(50),
@Clave varchar (100),
@IdRol int,
@Estado bit,
@IdUsuarioResultado int output,
@Mensaje varchar(500) output
)
as
begin
	set @IdUsuarioResultado = 0
	set @Mensaje = ''

	if not exists(select * from USUARIO where Documento = @documento)
	begin
		insert into usuario(Documento, NombreCompleto,Correo,Clave,IdRol,Estado) values
		(@documento,@NombreCompleto,@Correo,@Clave,@IdRol,@Estado)

		set @IdUsuarioResultado = SCOPE_IDENTITY()
		
	end
	else
		set @Mensaje = 'No se puede repetir el documento para mas de un usuario'
end
GO

create PROC sp_ReporteAsistencia(
@FechaInicio varchar(10),
@FechaFin varchar(10),
@IdUsuario int
)
as 
begin

SET DATEFORMAT dmy;
select FORMAT(CAST(a.HoraIngreso AS DATETIME), 'dd/MM/yyyy   HH:mm:ss') AS Ingreso,FORMAT(CAST(a.HoraSalida AS DATETIME), 'dd/MM/yyyy   HH:mm:ss') AS Salida, u.Documento,u.NombreCompleto, r.Descripcion
from ASISTENCIA a
inner join USUARIO u on a.IdUsuario = u.IdUsuario
inner join ROL r on r.IdRol = u.IdRol
where CONVERT(date,a.HoraIngreso) between CONVERT(date, @FechaInicio, 103) and CONVERT(date, @FechaFin, 103)
and u.IdUsuario = iif(@IdUsuario=0, u.IdUsuario,@IdUsuario)

end
GO