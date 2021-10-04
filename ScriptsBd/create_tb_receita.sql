create table finance.receita
(
	id uuid PRIMARY KEY not null,
	usuario_id uuid not null,
	categoria_id uuid not null,
	valor money not null,
	origem VARCHAR not null,
	descricao VARCHAR null,
	data_cadastro TIMESTAMP not null,
	data_receita TIMESTAMP not null,
	CONSTRAINT fk_usuario
		FOREIGN KEY(usuario_id)
		REFERENCES finance.usuario(id)
		ON DELETE CASCADE,
	CONSTRAINT fk_categoria
		FOREIGN KEY(categoria_id)
		REFERENCES finance.categoria(id)
		ON DELETE CASCADE
	
)