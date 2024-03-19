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

create table if not exists usuario
(
	id_usuario serial,
	email varchar,
	senha varchar,

	primary key (id_usuario)
);

create table if not exists pessoa_imagem (
	id_imagem serial,
	id_pessoa int not null,
	imagem_url varchar(150),
	imagem_base text,
	primary key (id_imagem),
	foreign key (id_pessoa)
		references pessoa (id_pessoa)	
);


create table if not exists permissao (
	id_permissao serial,
	nome_visual varchar(150),
	nome_permissao varchar(150),
	primary key (id_permissao)
);


create table if not exists permissao_usuario (
	id_permissao_usuario serial,
	id_usuario int,
	id_permissao int,
	
	primary key (id_permissao_usuario),
	foreign key (id_usuario)
		references usuario (id_usuario),
	foreign key (id_permissao)
		references permissao (id_permissao)
);

insert into usuario (email, senha) values ('teste@teste.com.br', '12345');
insert into usuario (email, senha) values ('abc@cba.com.br', '55555');
insert into usuario (email, senha) values ('value@teste.com.br', '4444');
insert into usuario (email, senha) values ('teste@teste.com.br', '333');


insert into pessoa (nome, documento, telefone) values ('teste', 0, 123);
insert into pessoa (nome, documento, telefone) values ('teste1', 1, 123);
insert into pessoa (nome, documento, telefone) values ('teste2', 2, 123);
insert into pessoa (nome, documento, telefone) values ('teste3', 3, 123);
insert into pessoa (nome, documento, telefone) values ('teste4', 4, 123);
insert into pessoa (nome, documento, telefone) values ('teste5', 5, 123);
