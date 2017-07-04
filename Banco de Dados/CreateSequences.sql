CREATE TABLE max_seq(
    cod_seq   NUMBER(8) NOT NULL,
    nome      VARCHAR2(30) NOT NULL,
    valor     NUMBER(8) NOT NULL,
    CONSTRAINT max_seq_pk PRIMARY KEY(cod_seq)
);
INSERT INTO max_seq VALUES(1,'seq_produtos',0);
INSERT INTO max_seq VALUES(3,'seq_fornecedor',0);

CREATE SEQUENCE seq_produtos;
CREATE SEQUENCE seq_cliente;
CREATE SEQUENCE seq_fornecedor;
CREATE SEQUENCE seq_especificacao;
CREATE SEQUENCE seq_marca;
CREATE SEQUENCE seq_categoria;
CREATE SEQUENCE seq_frete;
CREATE SEQUENCE seq_artigo;
CREATE SEQUENCE seq_espec_prod;
CREATE SEQUENCE seq_espec_artigo;
CREATE SEQUENCE seq_espec_pre_val;
CREATE SEQUENCE seq_prod_forn;
CREATE SEQUENCE seq_log_produto;
CREATE SEQUENCE seq_endereco;
CREATE SEQUENCE seq_contato;