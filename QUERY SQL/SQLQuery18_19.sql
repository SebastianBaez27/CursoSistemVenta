
/*REGISTRAR VENTA*/
Create type [dbo].[EDetalle_vENTA] AS TABLE(
 [IdProducto] int NULL,
 [PrecioVenta] decimal (18,2) NULL,
 [Cantidad] int NULL,
 [SubTotal] decimal (18,2) NULL
)

alter procedure usp_RegistrarVenta(
	@IdUsuario int,
	@TipoDocumento varchar(500),
	@NumeroDocumento varchar (500),
	@DocumentoCliente varchar(500),
	@NombreCliente varchar(500),
	@MontoPago decimal (18,2),
	@MontoCambio decimal (18,2),
	@MontoTotal decimal (18,2),
	@DetalleVenta [EDetalle_Venta] READONLY,
	@Resultado bit output,
	@Mensaje varchar (500) output
)
as
begin
	begin try
		declare @idventa int = 0
		set @Resultado = 1
		set @Mensaje = ''

		begin transaction registro
	    
		insert into VENTA (IdUsuario,TipoDocumento,NumeroDocumento,DocumentoCliente,NombreCliente,MontoPago,MontoCambio,MontoTotal)
		values (@IdUsuario,@TipoDocumento,@NumeroDocumento,@DocumentoCliente,@NombreCliente,@MontoPago,@MontoCambio,@MontoTotal)

		set @idventa = SCOPE_IDENTITY()

		insert into DETALLE_VENTA(IdVenta,IdProducto,PrecioVenta,Cantidad,SubTotal)
		Select @idventa,IdProducto,PrecioVenta,Cantidad,SubTotal from @DetalleVenta


		commit transaction registro


	end try
	begin catch
		set @Resultado = 0
		set @Mensaje = ERROR_MESSAGE()

		rollback transaction registro

	end catch
end


select v.IdVenta, u.NombreCompleto,
v.DocumentoCliente, v.NombreCliente,
v.TipoDocumento,v.NumeroDocumento,
v.MontoPago,v.MontoCambio,v.MontoTotal,
convert(char(10),v.FechaRegistro,103)[FechaRegistro]
from VENTA v
inner join USUARIO u on u.IdUsuario = v.IdUsuario
where v.NumeroDocumento = '00001'

select
p.Nombre, dv.PrecioVenta, dv.Cantidad, dv.SubTotal
from DETALLE_VENTA dv
inner join PRODUCTO p on p.IdProducto = dv.IdProducto
where dv.IdVenta = 1


/*Video 21*/


Alter PROC sp_ReporteCompras(
@fechainicio varchar(10),
@fechafin varchar(10),
@idproveedor int
)
as
begin
SET DATEFORMAT mdy;
select
CONVERT(char(10),c.FechaRegistro,103)[FechaRegistro], c.TipoDocumento,c.NumeroDocumento,c.MontoTotal,
u.NombreCompleto[UsuarioRegistro],
pr.Documento[DocumentoProveedor],pr.RazonSocial,
p.Codigo[CodigoProducto],p.Nombre[NombreProducto],ca.Descripcion[Categoria],dc.PrecioCompra,dc.PrecioVenta,dc.Cantidad,dc.MontoTotal[SubTotal]
from COMPRA c
inner join USUARIO u on u.IdUsuario = c.IdUsuario
inner join PROVEEDOR pr on pr.IdProveedor = c.IdProveedor
inner join DETALLE_COMPRA dc on dc.IdCompra = c.IdCompra
inner join PRODUCTO p on p.IdProducto = dc.IdProducto
inner join CATEGORIA ca on ca.IdCategoria = p.IdCategoria
where CONVERT(date,c.FechaRegistro) between @fechainicio and @fechafin
and pr.IdProveedor = iif(@idproveedor=0,pr.IdProveedor,@idproveedor)
end


alter PROC sp_ReporteVentas(
@fechainicio varchar(10),
@fechafin varchar(10)
)
as
begin
SET DATEFORMAT mdy;
select
CONVERT(char(10),v.FechaRegistro,103)[FechaRegistro], v.TipoDocumento,v.NumeroDocumento,v.MontoTotal,
u.NombreCompleto[UsuarioRegistro],
v.DocumentoCliente,v.NombreCliente,
p.Codigo[CodigoProducto],p.Nombre[NombreProducto],ca.Descripcion[Categoria],dv.PrecioVenta,dv.Cantidad,dv.SubTotal
from VENTA v
inner join USUARIO u on u.IdUsuario = v.IdUsuario
inner join DETALLE_VENTA dv on dv.IdVenta = v.IdVenta
inner join PRODUCTO p on p.IdProducto = dv.IdProducto
inner join CATEGORIA ca on ca.IdCategoria = p.IdCategoria
where CONVERT(date,v.FechaRegistro) between @fechainicio and @fechafin
end


exec sp_ReporteVentas'11/07/2025', '11/30/2025'

exec sp_ReporteCompras'11/07/2025', '11/30/2025', 3