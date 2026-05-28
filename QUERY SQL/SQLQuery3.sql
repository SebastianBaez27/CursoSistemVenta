
select u.IdUsuario, u.Documento,u.NombreCompleto,u.Correo,u.Clave,u.Estado, r.IdRol, r.Descripcion from usuario u
inner join rol r on r.IdRol = u.IdRol


update usuario set estado = 0 where idusuario = 1

select * from usuario

create proc SP_REGISTRARUSUARIO(
@Documento varchar(50),
@NombreCompleto varchar(100),
@Correo varchar (100),
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

	if not exists (select * from USUARIO where Documento = @Documento)
	begin
		insert into usuario (Documento,NombreCompleto,Correo,Clave,IdRol,Estado) values
		(@Documento,@NombreCompleto,@Correo,@Clave,@IdRol,@Estado)

		set @IdUsuarioResultado = SCOPE_IDENTITY()
	end
	else
		set @Mensaje = 'No se puede repetir el documento para mas de un usuario'


end

create proc SP_EDITARUSUARIO(
@IdUsuario int,
@Documento varchar(50),
@NombreCompleto varchar(100),
@Correo varchar (100),
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

	if not exists (select * from USUARIO where Documento = @Documento and idusuario != @IdUsuario)
	begin
		update usuario set
		Documento = @Documento,
		NombreCompleto = @NombreCompleto,
		Correo = @Correo,
		Clave = @Clave,
		IdRol = @IdRol,
		Estado = @Estado
		where IdUsuario = @IdUsuario
		

		set @Respuesta = 1
	end
	ELSE
		set @Mensaje = 'No se puede repetir el documento para mas de un usuario'


end


go


create proc SP_ELIMINARUSUARIO(
@IdUsuario int,
@Respuesta bit output,
@Mensaje varchar(500) output
)
as
begin
	set @Respuesta = 0
	set @Mensaje = ''
	declare @pasoreglas bit =1

	if exists (select * from COMPRA c
	inner join usuario u on u.IdUsuario = c.IdUsuario
	where u.IdUsuario = @IdUsuario
	)
	begin
		set @pasoreglas =0
		set @Respuesta = 0
		set @Mensaje = @mensaje + 'no se puede El usuario se encuentra relacionado a una compra\n'
	end 

if exists (select * from Venta V 
	inner join usuario u on u.IdUsuario = v.IdUsuario
	where u.IdUsuario = @IdUsuario
	)
	begin
		set @pasoreglas =0
		set @Respuesta = 0
		set @Mensaje = @mensaje + 'no se puede El usuario se encuentra relacionado a una venta\n'
	end 

if (@pasoreglas =1 )
	begin
	 delete from usuario where IdUsuario = @IdUsuario 
	 set @Respuesta = 1
	end
end




--HECTOR VIDEO 8 MIN 0 a 
--Procedimientos de CATEGORIA

--REGISTRAR CATEGORIA
alter procedure SP_RegistrarCategoria(
@Descripcion varchar(50),
@Estado bit,
@Resultado bit output,
@Mensaje varchar(500) output
)as
begin
	SET @Resultado =0
	IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE Descripcion = @Descripcion)
	begin
		insert into CATEGORIA(Descripcion, Estado) values (@Descripcion, @Estado)
		set @Resultado = SCOPE_IDENTITY()
	end
	ELSE
		set @Mensaje = 'No se puede repetir la descripcion para mas de una categoria'
end
go


--EDITAR CATEGORIA
alter procedure SP_EditarCategoria(
@IdCategoria int,
@Descripcion varchar(50),
@Estado bit,
@Resultado bit output,
@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE Descripcion = @Descripcion and IdCategoria != @IdCategoria)
		update CATEGORIA set
		Descripcion = @Descripcion
		Estado = @Estado
		where IdCategoria = @IdCategoria
	ELSE
	begin
		set @Resultado = 0
		set @Mensaje = 'No se puede repetir la descripcion de una categoria'
	end
end

go


--Eliminar CATEGORIA
create procedure SP_EliminarCategoria(
@IdCategoria int,
@Estado bit,
@Resultado bit output,
@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 1
	IF NOT EXISTS (
		SELECT * FROM CATEGORIA c
		inner join PRODUCTO p on p.IdCategoria = c.IdCategoria
		where c.IdCategoria = @IdCategoria
		)
		begin
		delete top (1) from CATEGORIA where IdCategoria = @IdCategoria
		end
	ELSE
	begin
		set @Resultado = 0
		set @Mensaje = 'La categoria se encuentra relacionada a un producto'
	end
end


SELECT *FROM CATEGORIA
INSERT INTO CATEGORIA (Descripcion,Estado) VALUES ('Lacteos',1)
INSERT INTO CATEGORIA (Descripcion,Estado) VALUES ('Embutidos',1)
INSERT INTO CATEGORIA (Descripcion,Estado) VALUES ('Condones',1)




--PROCEDIMIENTOS DE PRODUCTO 

--Registrar Producto
alter procedure SP_RegistrarProducto(
@Codigo varchar(20),
@Nombre varchar(30),
@Descripcion varchar(30),
@IdCategoria int,
@Estado bit,
@Resultado bit output,
@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 0
	IF NOT EXISTS (SELECT * FROM PRODUCTO WHERE Codigo = @Codigo)
	begin
		insert into PRODUCTO(Codigo,Nombre,Descripcion,IdCategoria,Estado) values (@Codigo, @Nombre,@Descripcion,@IdCategoria,@Estado)
		set @Resultado = SCOPE_IDENTITY()
	end
	ELSE
		set @Mensaje = 'Ya existe un producto con el mismo codigo'
end


--Editar producto
go
alter procedure SP_ModificarProducto
(@IdProducto int,
@Codigo varchar(20),
@Nombre varchar(30),
@Descripcion varchar(30),
@IdCategoria int,
@Estado bit,
@Resultado bit output,
@Mensaje varchar(500) output
)as
begin
	SET @Resultado =1
	IF NOT EXISTS (SELECT * FROM PRODUCTO WHERE codigo = @Codigo and IdProducto != @IdProducto)
		update PRODUCTO set
		Codigo = @Codigo,
		Nombre = @Nombre,
		Descripcion = @Descripcion,
		IdCategoria = @IdCategoria,
		Estado = @Estado
		Where IdProducto = @IdProducto

	ELSE
	begin
		set @Resultado = 0
		set @Mensaje = 'Ya existe un producto con el mismo codigo'
	end
end

--Eliminar producto
go
alter procedure SP_EliminarProducto
(@IdProducto int,
@Respuesta bit output,
@Mensaje varchar(500) output
)as
begin
	SET @Respuesta = 0
	set @Mensaje = ''
	declare @pasoreglas bit = 1

	IF EXISTS (SELECT * FROM DETALLE_COMPRA dc
	inner join PRODUCTO p on p.IdProducto = dc.IdProducto 
	WHERE p.IdProducto = @IdProducto)
	Begin
		set @pasoreglas = 0
		set @Respuesta = 0
		set @Mensaje = @Mensaje + 'No se puede eliminar por que se encuentra relacionado a una COMPRA\n'
	end

		IF EXISTS (SELECT * FROM DETALLE_VENTA dv 
		inner join PRODUCTO p on p.IdProducto = dv.IdProducto 
		WHERE p.IdProducto = @IdProducto)
	Begin
		set @pasoreglas = 0
		set @Respuesta = 0
		set @Mensaje = @Mensaje + 'No se puede eliminar por que se encuentra relacionado a una VENTA\n'
	end

	if(@pasoreglas = 1)
	begin
		delete from PRODUCTO where IdProducto = @IdProducto
		set @Respuesta = 1
	end
end

go

create procedure sp_RegistrarCliente(
@Documento varchar(50),
@NombreCompleto varchar(50),
@Correo varchar(50),
@Telefono varchar(50),
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 0
	DECLARE @IDPERSONA INT
	IF NOT EXISTS (SELECT * FROM CLIENTE WHERE Documento = @Documento)
	begin

		insert into CLIENTE (Documento, NombreCompleto, Correo, Telefono, Estado) values (@Documento, @NombreCompleto, @Correo, @Telefono, @Estado)

		set @Resultado = SCOPE_IDENTITY()

	end
	else

		set @Mensaje = 'El numero de documento ya existe'

	end
go

Create PROC sp_ModificarCliente (
@IdCliente int,
@Documento varchar(50),
@NombreCompleto varchar(50),
@Correo varchar(50),
@Telefono varchar(50),
@Estado bit,
@Resultado bit output,
@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 1
	Declare @IDPERSONA INT
	IF NOT EXISTS (SELECT * FROM CLIENTE WHERE Documento = @Documento and IdCliente != @IdCliente)
	begin
		update CLIENTE set
		Documento = @Documento,
		NombreCompleto = @NombreCompleto,
		Correo = @Correo,
		Telefono = @Telefono,
		Estado = @Estado
		where IdCliente=@IdCliente
	end
	else
	begin
		SET @Resultado = 0
		set @Mensaje = 'El numero de documento ya existe'
	end
end

--  PROCEDURES PARA PROVEEDOR
create PROC sp_RegistrarProveedor(
@Documento varchar(50),
@RazonSocial varchar(50),
@Correo varchar(50),
@Telefono varchar(50),
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 0
	DECLARE @IDPERSONA INT
	IF NOT EXISTS (SELECT * FROM PROVEEDOR WHERE Documento = @Documento)
	begin
		insert into PROVEEDOR(DOcumento,RazonSocial,Correo,telefono,Estado) values (
		@Documento,@RazonSocial,@Correo,@Telefono,@Estado)

		set @Resultado = SCOPE_IDENTITY()
	end
	ELSE
		set @Mensaje = 'El numero de documento ya existe'
end

Go

Create PROC sp_ModificarProveedor (
@IdProveedor int,
@Documento varchar(50),
@RazonSocial varchar(50),
@Correo varchar(50),
@Telefono varchar(50),
@Estado bit,
@Resultado bit output,
@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 1
	Declare @IDPERSONA INT
	IF NOT EXISTS (SELECT * FROM PROVEEDOR WHERE Documento = @Documento and IdProveedor != @IdProveedor)
	begin
		update PROVEEDOR set
		Documento = @Documento,
		RazonSocial = @RazonSocial,
		Correo = @Correo,
		Telefono = @Telefono,
		Estado = @Estado
		where IdProveedor=@IdProveedor
	end
	else
	begin
		SET @Resultado = 0
		set @Mensaje = 'El numero de documento ya existe'
	end
end
go

CREATE procedure sp_EliminarProveedor
(@IdProveedor int,
@Resultado bit output,
@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 1
	IF NOT EXISTS (
	select * from PROVEEDOR p
	inner join COMPRA c on p.IdProveedor = c.IdProveedor
	where p.IdProveedor = @IdProveedor
	)
	begin
	 delete top(1) from PROVEEDOR where IdProveedor = @IdProveedor
	end 
	ELSE
	begin
		set @Resultado = 0
		set @Mensaje = 'El proveedor se encuentra relacionado con una compra'
	end 
end

delete from PROVEEDOR where IdProveedor = 1
select * from PROVEEDOR



select IdProveedor,Documento,RazonSocial,Correo,Telefono,Estado from PROVEEDOR

select IdProveedor,Documento,RazonSocial,Correo,Telefono from PROVEEDOR