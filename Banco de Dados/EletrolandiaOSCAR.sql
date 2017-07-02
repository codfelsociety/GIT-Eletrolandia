CREATE TABLE clientes(
    cod          NUMBER(8) PRIMARY KEY NOT NULL,
    cod_con      NUMBER(8)             NOT NULL,
    nome         VARCHAR2(30)          NOT NULL,
    sobrenome    VARCHAR2(50)          NOT NULL,
    local_imagem VARCHAR2(100),
    sexo         CHAR(1),
    idade        NUMBER(2),
    cpf          NUMBER(11)
);

CREATE TABLE cliente_con(
    cod      NUMBER(8)    PRIMARY KEY NOT NULL,
    username VARCHAR2(50)             NOT NULL,
    password VARCHAR2(50)             NOT NULL,
    email    VARCHAR2(100)            NOT NULL
);

CREATE SEQUENCE seq_clientes;
CREATE SEQUENCE seq_clienteCon;


CREATE OR REPLACE PROCEDURE insert_clientes(
       p_cod_con IN clientes.cod_con%TYPE,
	   p_nome IN clientes.nome%TYPE,
	   p_sobrenome IN clientes.sobrenome%TYPE,
       p_local_imagem IN clientes.local_imagem%TYPE,
	   p_sexo IN clientes.sexo%TYPE,
	   p_idade IN clientes.idade%TYPE,
	   p_cpf IN clientes.cpf%TYPE)
IS
BEGIN
  INSERT INTO clientes
  VALUES (seq_clientes.NEXTVAL,p_cod_con, p_nome, p_sobrenome, p_local_imagem, p_sexo, p_idade, p_cpf);
  COMMIT;
END;

CREATE OR REPLACE PROCEDURE insert_clienteCon(
       p_cod IN cliente_con.cod%TYPE,
       p_username IN cliente_con.username%TYPE,
	   p_password IN cliente_con.password%TYPE,
	   p_email IN cliente_con.email%TYPE)
IS
BEGIN
  INSERT INTO cliente_con
  VALUES (p_cod,p_username, p_password, p_email);
  COMMIT;
END;

EXECUTE insert_clienteCon('codfel', 'ilikecats123', 'codfelsociety@gmail.com');
EXECUTE insert_clientes(1, 'Felipe', 'Salazar', 'D:\Imagens\POP TABLES\4chan.jpg', 'M', 18, 85874152632);

COMMIT;

SELECT cli.cod, cli.nome ||' '|| cli.sobrenome AS nome, cli.sexo, cli.idade, cli.cpf, 
cli.local_imagem AS image, ccon.username , ccon.password , ccon.email
FROM clientes cli
JOIN cliente_con ccon
ON ccon.COD = cli.cod_con;

SELECT cod, nome ||' '|| sobrenome AS nome, sexo, idade, cpf, local_imagem AS image from clientes