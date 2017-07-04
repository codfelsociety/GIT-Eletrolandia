CREATE TABLE produtos (
    cod_produto        NUMBER(8) NOT NULL,
    cod_artigo         NUMBER(8) NOT NULL,
    cod_marca          NUMBER(8) NOT NULL,
    cod_frete          NUMBER(8) NOT NULL,
    cod_barras         NUMBER(8),
    nome               VARCHAR2(50) NOT NULL,
    descricao          VARCHAR2(200) DEFAULT 'Produto sem descri��o',
    estoque            NUMBER(8) NOT NULL,
    estoque_min        NUMBER(8) DEFAULT 1,
    estoque_max        NUMBER(8) DEFAULT 100,
    ativo              NUMBER(1) DEFAULT 1 NOT NULL,
    data_cadastro      DATE DEFAULT SYSDATE NOT NULL ,
    on_line            NUMBER(1),
    limitado           NUMBER(1),
    CONSTRAINT produtos_pk PRIMARY KEY(cod_produto)
);

CREATE TABLE categoria (
    cod_categoria   NUMBER(8) NOT NULL,
    descricao       VARCHAR2(50) NOT NULL,
    CONSTRAINT categoria_pk PRIMARY KEY(cod_categoria)
);
CREATE TABLE artigo (
    cod_artigo   NUMBER(8) NOT NULL,
    cod_categoria      NUMBER(8) NOT NULL,
    descricao          VARCHAR2(25) NOT NULL,
    CONSTRAINT artigo_pk PRIMARY KEY(cod_artigo)
);

CREATE TABLE especificacao (
    cod_especificacao   NUMBER(8) NOT NULL,
    descricao           VARCHAR2(50) NOT NULL,
    tipo                NUMBER(1),
    CONSTRAINT especificacao_pk PRIMARY KEY (cod_especificacao)
);

CREATE TABLE especificacao_artigo (
    cod_especificacao_artigo   NUMBER(8) NOT NULL,
    cod_especificacao        NUMBER(8) NOT NULL,
    cod_artigo_produto       NUMBER(8) NOT NULL,
    CONSTRAINT espec_art_pk PRIMARY KEY(cod_especificacao_artigo)
);
CREATE TABLE especificacao_pre_valores (
    cod_espec_pre_valor   NUMBER(8) NOT NULL,
    cod_especificacao     NUMBER(8) NOT NULL,
    valor                 VARCHAR2(80) NOT NULL,
    CONSTRAINT espec_pre_valores_pk PRIMARY KEY(cod_espec_pre_valor)
);

CREATE TABLE especificacao_produto (
    cod_especificacao_produto   NUMBER NOT NULL,
    cod_especificacao           NUMBER(8) NOT NULL,
    cod_prod                    NUMBER(8) NOT NULL,
    valor                       VARCHAR2(30),
    cod_pre_valor               NUMBER(8),
    CONSTRAINT espec_produto_pk PRIMARY KEY(cod_especificacao_produto)
);

CREATE TABLE fornecedor (
    cod_fornecedor   NUMBER(8) NOT NULL,
    cod_endereco     NUMBER(8) NOT NULL,
    cod_contato      NUMBER(8) NOT NULL,
    nome             VARCHAR2(50),
    cnpj             VARCHAR2(15),
    ins_estadual     VARCHAR2(15),
    descricao        VARCHAR2(50),
    CONSTRAINT fornecedor_pk PRIMARY KEY(cod_fornecedor)
);

CREATE TABLE frete (
    cod_frete     NUMBER(8) NOT NULL,
    peso          NUMBER,
    altura        NUMBER,
    largura       NUMBER,
    comprimento   NUMBER,
    fragil        NUMBER(1),
    gratis        NUMBER(1),
    CONSTRAINT frete_pk PRIMARY KEY(cod_frete)
);

CREATE TABLE imagem_produto (
    cod_produto    NUMBER(8) NOT NULL,
    imagem   BLOB NOT NULL,
    descricao      VARCHAR2(50)
);

CREATE TABLE contato (
    cod_contato   NUMBER(8) NOT NULL,
    telefone           NUMBER(10),
    celular            NUMBER(11),
    email              VARCHAR2(70),
    CONSTRAINT contato_pk PRIMARY KEY(cod_contato)
);

CREATE TABLE log_produto (
    cod_log_prod   NUMBER(8) NOT NULL,
    cod_produto    NUMBER(8) NOT NULL,
    data_cadastro           DATE,
    custo          NUMBER(10,2),
    preco   NUMBER(10,2),
    CONSTRAINT log_produto_pk PRIMARY KEY(cod_log_prod)
);

CREATE TABLE marca (
    cod_marca   NUMBER(4) NOT NULL,
    descricao   VARCHAR2(50),
    CONSTRAINT marca_pk PRIMARY KEY(cod_marca)
);

CREATE TABLE produto_fornecedor (
    cod_prod_forn    NUMBER(8) NOT NULL,
    cod_prod         NUMBER(8) NOT NULL,
    cod_fornecedor   NUMBER(8) NOT NULL,
    CONSTRAINT produto_fornecedor_pk PRIMARY KEY(cod_prod_forn)
);

CREATE TABLE estado (
  id NUMBER(11) NOT NULL,
  nome varchar2(75),
  uf varchar2(5)
);

CREATE TABLE cidade(
  id NUMBER(11) NOT NULL,
  nome VARCHAR2(120),
  estado NUMBER(5)
);


CREATE TABLE endereco (
    cod_endereco   NUMBER(8) NOT NULL,
    tipo           NUMBER(1) NOT NULL,
    cep            VARCHAR2(8),
    cidade         NUMBER(11),
    estado         NUMBER(11),
    bairro         VARCHAR2(30),
    rua            VARCHAR2(30),
    numero         NUMBER(4),
    complemento    VARCHAR2(50),
    CONSTRAINT endereco_pk PRIMARY KEY ( cod_endereco )
);