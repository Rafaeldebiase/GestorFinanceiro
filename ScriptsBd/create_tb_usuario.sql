create table finance.usuario (
	id uuid primary key,
	primeiro_nome VARCHAR not NULL,
	ultimo_nome VARCHAR null,
	email VARCHAR not null,
	senha VARCHAR not null,
	data_nascimento TIMESTAMP null,
	Genero VARCHAR null,
	logradouro VARCHAR null,
    numero INT null, 
    complemento varchar null,
    bairro VARCHAR null,
    cidade VARCHAR null, 
    estado VARCHAR null, 
    pais VARCHAR null,
    cep VARCHAR null,
	ativo BOOLEAN not null,
	codigo_ativacao int not null,
	funcao VARCHAR not null
)