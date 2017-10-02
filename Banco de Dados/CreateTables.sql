CREATE TABLE produtos (
    cod_produto        NUMBER(8) NOT NULL,
    cod_artigo         NUMBER(8) NOT NULL,
    cod_marca          NUMBER(8) NOT NULL,
    cod_frete          NUMBER(8) NOT NULL,
    cod_barras         NUMBER(8),
    nome               VARCHAR2(50) NOT NULL,
    descricao          VARCHAR2(200) DEFAULT 'Produto sem descrição',
    ativo              NUMBER(1) DEFAULT 1 NOT NULL,
    data_cadastro      DATE DEFAULT SYSDATE NOT NULL ,
    on_line            NUMBER(1),
    limitado           NUMBER(1),
    CONSTRAINT produtos_pk PRIMARY KEY(cod_produto)
);

CREATE TABLE estoque (
    cod_prod           NUMBER(8) NOT NULL,
    data_cadastro      DATE DEFAULT SYSDATE NOT NULL,
    estoque            NUMBER(8) NOT NULL,
    estoque_min        NUMBER(8) DEFAULT 1,
    estoque_max        NUMBER(8) DEFAULT 100
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
    cnpj             NUMBER,
    ins_estadual     NUMBER(15),
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
    cep            NUMBER(8),
    cidade         NUMBER(11),
    estado         NUMBER(11),
    bairro         VARCHAR2(30),
    rua            VARCHAR2(30),
    numero         NUMBER(4),
    complemento    VARCHAR2(50),
    CONSTRAINT endereco_pk PRIMARY KEY ( cod_endereco )
);

CREATE TABLE usuario(
    id NUMBER(8) NOT NULL,
    cargo NUMBER(8),
    sexo NUMBER(1),
    nome VARCHAR2(50),
    sobrenome VARCHAR2(50),
    username VARCHAR2(50),
    email VARCHAR2(50),
    senha VARCHAR2(50),
    dataCadastro DATE,
    foto BLOB,
    status NUMBER(1),
    CONSTRAINT usuario_pk PRIMARY KEY(id)
);
CREATE TABLE sexo(
    cod_sexo NUMBER(1),
    descricao VARCHAR2(30),
    abreviacao VARCHAR2(1),
    CONSTRAINT sexo_pk PRIMARY KEY(cod_sexo)
);

CREATE TABLE acesso(
    cod_acesso NUMBER(8) NOT NULL,
    descricao VARCHAR2(30),
    CONSTRAINT acesso_pk PRIMARY KEY(cod_acesso)
);
CREATE TABLE venda(
    id_venda NUMBER(8) NOT NULL,
    id_tipo NUMBER(1) NOT NULL,
    id_cliente NUMBER(8),
    id_info NUMBER(15),
    data_venda DATE,
    CONSTRAINT venda_pk PRIMARY KEY(id_venda)
);

CREATE TABLE item_venda (
    id_venda     NUMBER(8) NOT NULL,
    id_produto   NUMBER(8) NOT NULL,
    preco_unit    NUMBER(10,2),
    quantidade    NUMBER(2)
);

CREATE TABLE pagamento(
    id_venda NUMBER(8),
    tipo NUMBER(1), /*1= Fisica 2 = Online*/
    valor NUMBER(10,2)
);

CREATE TABLE info_venda(
    id_info NUMBER(8)NOT NULL,
    nome VARCHAR2(50),
    cpf NUMBER(11)
);


CREATE TABLE mensagem (
    cod_mensagem   NUMBER(8) NOT NULL,
    mensagem       VARCHAR2(300),
    nome           VARCHAR2(50),
    email           VARCHAR2(50),
    CONSTRAINT mensagem_pk PRIMARY KEY(cod_mensagem)
);