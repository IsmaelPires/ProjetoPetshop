# Petshop IFP

Aplicativo .Net Core para Petshop.

## Instalação

Baixar o repositório e compilar os projetos.

Instalar o MySql Workbench 8.0.25 para banco de dados.

## Banco de Dados

```sql
CREATE DATABASE PetshopIFP;

USE PetshopIFP;

CREATE TABLE Petshop (
	Id  PRIMARY KEY auto_increment,
	Nome varchar(100) NOT NULL,
  Endereco varchar(100) NOT NULL,
  QuantidadeVagas int NOT NULL
);

CREATE TABLE Pet (
	Id int(10) PRIMARY KEY auto_increment,
	Nome varchar(100) NOT NULL,
  NomeDono varchar(100) NOT NULL,
  EnderecoDono varchar(100) NOT NULL,
  TelefoneDono varchar(100) NOT NULL,
  EstadoSaude varchar(100) NOT NULL,
  MotivoInternacao varchar(100) NOT NULL,
  Foto varchar(1000) NULL
);
```
