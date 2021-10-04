CREATE TABLE finance.categoria (
	id uuid primary key,
	usuario_id uuid not null,
	nome VARCHAR not null,
	descricao VARCHAR null,
	somatorio money not null,
	constraint fk_usuario
		FOREIGN KEY(usuario_id)
		REFERENCES finance.usuario(id)
		ON Delete Cascade
)