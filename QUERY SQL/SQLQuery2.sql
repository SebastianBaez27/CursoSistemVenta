

select * from usuario


insert into rol (Descripcion)
values('ADMINISTRADOR')

insert into rol (Descripcion)
values('EMPLEADO')

insert into USUARIO (Documento,NombreCompleto,Correo,Clave,IdRol,Estado)
values

('101010','ADMIN','@GMAIL.COM','123',1,1)


select * from rol

select p.IdRol,p.NombreMenu from PERMISO p

inner join ROL r on r.IdRol = p.IdRol
inner join USUARIO u on u.IdRol = r.IdRol

 where u.IdUsuario=3

insert into PERMISO(IdRol, NombreMenu) values
(1,'menuusuarios'),
(1,'menumantenedor'),
(1,'menuventas'),
(1,'menucompras'),
(1,'menuclientes'),
(1,'menuproveedores'),
(1,'menureportes'),
(1,'menuacercade')

insert into PERMISO(IdRol, NombreMenu) values
(2,'menuventas'),
(2,'menucompras'),
(2,'menuclientes'),
(2,'menuproveedores'),
(2,'menuacercade')
