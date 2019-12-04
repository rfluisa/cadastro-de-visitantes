create table Pessoa(
IDPessoa int identity not null,
CPF varchar(15) not null,
Nome varchar(100) not null,
Sexo varchar(5) not null,
Telefone varchar(30) not null,
);

create table Visita(
IDPessoa int  null,
IDSetor int  null,
DataEntrada datetime not null,
DataSaida datetime  null,
IDVeiculo int null
);

create table Setor(
IDSetor int identity not null,
Nome varchar(50) not null,
Descricao varchar(300) null,
);

create table VeiculoPessoa(
IDVeiculo int null,
IDPessoa int null,
);

create table Veiculo(
IDVeiculo int identity not null, 
Placa varchar(20) not null,
Ano varchar(5) not null,
IDCarro int not null,
);

create table Carro(
IDCarro int identity not null,
Marca varchar(50) not null,
Modelo varchar(50) not null,
);

create table Usuario(
IDUsuario int identity not null,
NomeUsuario varchar(50) not null,
Senha varchar(100) not null,
Tipo varchar(25) not null
);


--drop table Usuario
--drop table Pessoa
--drop table Setor
--drop table Veiculo
--drop table Carro
--drop table Visita
--drop table Veiculos



alter table Pessoa add constraint PK_PESSOA primary key(IDPessoa);
alter table Setor add constraint PK_SETOR primary key(IDSetor);
alter table Veiculo add constraint PK_VEICULO primary key (IDVeiculo);
alter table Carro add constraint PK_CARRO primary key (IDCarro);
alter table Usuario add constraint PK_USUARIO primary key (IDUsuario);


alter table Visita add constraint FK_VISITA_PESSOA foreign key(IDPessoa) references Pessoa(IDPessoa);
alter table Visita add constraint FK_VISITA_SETOR foreign key(IDSetor) references Setor(IDSetor);
alter table Visita add constraint FK_VISITA_VEICULO  foreign key(IDVeiculo) references Veiculo(IDVeiculo);
alter table VeiculoPessoa add constraint FK_VEICULOS_VEICULO foreign key(IDVeiculo) references Veiculo(IDVeiculo);
alter table VeiculoPessoa add constraint FK_VEICULOS_PESSOA foreign key(IDPessoa) references Pessoa(IDPessoa);
alter table Veiculo add constraint FK_VEICULO_CARRO foreign key(IDCarro) references Carro(IDCarro);