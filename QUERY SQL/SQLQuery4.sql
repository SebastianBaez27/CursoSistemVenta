
select IdProducto,Codigo,Nombre,p.Descripcion,c.IdCategoria,c.Descripcion[DescripcionCategoria],Stock,PrecioCompra,PrecioVenta from PRODUCTO p 
inner join CATEGORIA c on c.IdCategoria = p.IdCategoria

select IdCliente,Documento,NombreCompleto,Correo,Telefono,Estado from CLIENTE
select IdProveedor,Documento,RazonSocial,Correo,Telefono,Estado from PROVEEDOR
