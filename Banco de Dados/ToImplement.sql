






CREATE TABLE cliente (
    cod_cliente   NUMBER(8) NOT NULL,
    cod_contato   NUMBER(8) NOT NULL,
    nome          VARCHAR2(50),
    sobrenome     VARCHAR2(50),
    gênero        VARCHAR2(1),
    cpf           VARCHAR2(11),
    CONSTRAINT cliente_pk PRIMARY KEY ( cod_cliente )
);


CREATE TABLE endereco_cliente (
    cod_endereco_cliente   NUMBER(8) NOT NULL,
    cod_endereco           NUMBER(8) NOT NULL,
    cod_cliente            NUMBER(8) NOT NULL,
    CONSTRAINT endereco_cliente_pk PRIMARY KEY ( cod_endereco_cliente )
);

CREATE TABLE mensagem_contato (
    cod_mensagem   NUMBER(8) NOT NULL,
    mensagem       VARCHAR2(300),
    remetente      VARCHAR2(100),
    nome           VARCHAR2(50),
    celular        VARCHAR2(20),
    CONSTRAINT mensagem_pk PRIMARY KEY(cod_mensagem)
);


SELECT prod.cod_produto AS cod,  img.imagem as IMGPATH, prod.nome, art.descricao AS artigo, cat.descricao AS categoria,
                           mar.descricao AS marca, prod.estoque,logprod.custo, logprod.preco AS preco, 
                            (logprod.preco - logprod.custo) * prod.estoque AS lucro_total, prod.ativo AS status,prod.data_cadastro AS data
                            FROM produtos prod
                            JOIN artigo art
                            ON art.cod_artigo = prod.cod_artigo
                            JOIN marca mar
                            ON mar.cod_marca = prod.cod_marca
                            JOIN categoria cat
                            ON cat.cod_categoria = art.cod_categoria
                            JOIN 
                            (SELECT inn.* FROM (SELECT log2.*, (ROW_NUMBER() OVER(PARTITION BY cod_produto ORDER BY cod_log_prod DESC)) As Rank 
                            FROM log_produto log2) inn WHERE inn.Rank=1) logprod
                            ON  prod.cod_produto = logprod.cod_produto
                            LEFT JOIN
                            (SELECT inn.* FROM (SELECT img2.*, (ROW_NUMBER() OVER(PARTITION BY cod_produto ORDER BY cod_produto DESC)) As Rank 
                            FROM imagem_produto img2) inn WHERE inn.Rank=1) img
                            ON prod.cod_produto = img.cod_produto ORDER BY prod.cod_produto;
