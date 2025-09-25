create table padre(
id_padre int auto_increment PRIMARY kEY,
nombre varchar(30),
apellido varchar(30),
id_hijo int
);

create table hijo(
id_hijo int auto_increment PRIMARY kEY,
nombre varchar(30),
apellido varchar(30)
);

ALTER TABLE padre
ADD CONSTRAINT fk_padre_hijo
FOREIGN KEY (id_hijo) REFERENCES hijo(id_hijo);