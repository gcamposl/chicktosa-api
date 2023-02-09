create table if not exists pessoa (
	id_pessoa serial primary key,
	nome varchar(50),
	documento varchar(255),
    telefone varchar(20)
);

create table if not exists pet (
	id_pet serial primary key,
	nome varchar(50),
	raca varchar(255),
	peso numeric (10,2)
);

create table if not exists plano (
	id_plano serial primary key,
	id_pessoa int,
	id_pet int,
	data_vencimento date,
	preco decimal,
	
	constraint fk_pessoa_plano foreign key(id_pessoa) references pessoa(id_pessoa),
	constraint fk_pet_plano foreign key(id_pet) references pet(id_pet)	
);

create table if usuario
(
	id_usuario serial,
	email varchar,
	senha varchar
);
