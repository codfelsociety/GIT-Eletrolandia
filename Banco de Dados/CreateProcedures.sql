CREATE OR REPLACE PROCEDURE insert_produto(
	   p_cod_produto IN PRODUTOS.COD_PRODUTO%TYPE,
	   p_cod_artigo IN PRODUTOS.COD_ARTIGO%TYPE,
	   p_cod_marca IN PRODUTOS.COD_MARCA%TYPE,
	   p_cod_frete IN PRODUTOS.COD_FRETE%TYPE,
       p_cod_barras IN PRODUTOS.COD_BARRAS%TYPE,
	   p_nome IN PRODUTOS.NOME%TYPE,
       p_descricao IN PRODUTOS.DESCRICAO%TYPE,
       p_estoque IN PRODUTOS.ESTOQUE%TYPE,
       p_estoque_min IN PRODUTOS.ESTOQUE_MIN%TYPE,
       p_estoque_max IN PRODUTOS.ESTOQUE_MAX%TYPE,
       p_ativo IN PRODUTOS.ATIVO%TYPE,
       p_online IN PRODUTOS.ON_LINE%TYPE,
       p_limitado IN PRODUTOS.LIMITADO%TYPE,
       p_data_cadastro IN VARCHAR2)
IS BEGIN
  INSERT INTO produtos 
  VALUES (p_cod_produto, p_cod_artigo,p_cod_marca, p_cod_frete, p_cod_barras, p_nome,
  p_descricao, p_estoque, p_estoque_min, p_estoque_max, p_ativo, TO_DATE(p_data_cadastro,'DD/MM/YYYY HH24:MI:SS'),
  p_online, p_limitado);
  COMMIT;
END;

CREATE OR REPLACE PROCEDURE insert_categoria(p_descricao IN categoria.descricao%TYPE)
IS BEGIN
INSERT INTO categoria VALUES(seq_categoria.NEXTVAL, p_descricao);
COMMIT;
END;

CREATE OR REPLACE PROCEDURE insert_marca(p_descricao IN marca.descricao%TYPE)
IS BEGIN
INSERT INTO marca VALUES(seq_marca.NEXTVAL, p_descricao);
COMMIT;
END;

CREATE OR REPLACE PROCEDURE insert_artigo(p_cod_categoria IN artigo.cod_categoria%TYPE, p_descricao IN artigo.descricao%TYPE)
IS BEGIN
INSERT INTO artigo VALUES(seq_artigo.NEXTVAL,p_cod_categoria ,p_descricao);
COMMIT;
END;


CREATE OR REPLACE PROCEDURE insert_produto_fornecedor(
	   p_cod_prod IN produto_fornecedor.cod_prod%TYPE,
	   p_cod_fornecedor IN produto_fornecedor.cod_fornecedor%TYPE)
IS
BEGIN
  INSERT INTO produto_fornecedor 
  VALUES (seq_prod_forn.NEXTVAL, p_cod_prod, p_cod_fornecedor);
  COMMIT;
END;

CREATE OR REPLACE PROCEDURE insert_log_produto(
	   p_cod_produto IN log_produto.cod_produto%TYPE,
	   p_data IN VARCHAR2,
	   p_custo IN log_produto.custo%TYPE,       
	   p_preco IN log_produto.preco%TYPE)
IS
BEGIN
  INSERT INTO log_produto 
  VALUES (seq_log_produto.NEXTVAL,p_cod_produto, TO_DATE(p_data,'DD/MM/YYYY HH24:MI:SS'), p_custo, p_preco);
  COMMIT;
END;

CREATE OR REPLACE PROCEDURE insert_imagem_produto(
	   p_cod_produto IN imagem_produto.cod_produto%TYPE,
	   p_imagem IN imagem_produto.imagem%TYPE,
	   p_descricao IN imagem_produto.descricao%TYPE)
IS
BEGIN
  INSERT INTO imagem_produto
  VALUES (p_cod_produto, p_imagem, p_descricao);
  COMMIT;
END;

CREATE OR REPLACE PROCEDURE insert_espec_prod(
	   p_cod_espec IN especificacao_produto.cod_especificacao%TYPE,
	   p_cod_prod IN especificacao_produto.cod_prod%TYPE,
	   p_valor IN especificacao_produto.valor%TYPE,
	   p_cod_pre_valor IN especificacao_produto.cod_pre_valor%TYPE)
IS
BEGIN
  INSERT INTO especificacao_produto
  VALUES (seq_espec_prod.NEXTVAL, p_cod_espec, p_cod_prod, p_valor, p_cod_pre_valor);
  COMMIT;
END;

CREATE OR REPLACE PROCEDURE UpdateProduto(
	   p_cod_artigo IN produtos.cod_artigo%TYPE,
	   p_cod_marca IN produtos.cod_marca%TYPE,
	   p_cod_barras IN produtos.cod_barras%TYPE,
	   p_nome IN produtos.nome%TYPE,
	   p_descricao IN produtos.descricao%TYPE,
	   p_estoque IN produtos.estoque%TYPE,
	   p_estoque_min IN produtos.estoque_min%TYPE,
	   p_estoque_max IN produtos.estoque_max%TYPE,
	   p_ativo IN produtos.ativo%TYPE,
	   p_online IN produtos.on_line%TYPE,
	   p_limitado IN produtos.limitado%TYPE,
       p_cod_produto IN produtos.cod_produto%TYPE)
IS
BEGIN
  UPDATE produtos SET cod_artigo = p_cod_artigo,
  cod_marca = p_cod_marca, cod_barras = p_cod_barras, 
  nome = p_nome, descricao = p_descricao, estoque= p_estoque,
  estoque_min = p_estoque_min, estoque_max = p_estoque_max,
  ativo = p_ativo, on_line = p_online, limitado = p_limitado
  WHERE cod_produto = p_cod_produto;
  COMMIT;
END;

CREATE OR REPLACE PROCEDURE UpdateFrete(
        p_cod_frete IN frete.cod_frete%TYPE,
        p_peso IN frete.peso%TYPE,
        p_altura IN frete.altura%TYPE,
        p_largura IN frete.largura%TYPE,
        p_comprimento IN frete.comprimento%TYPE,
        p_gratis IN frete.gratis%TYPE,
        p_fragil IN frete.fragil%TYPE)
IS BEGIN
    UPDATE frete SET peso = p_peso,
    altura = p_altura, largura = p_largura,
    comprimento = p_comprimento, gratis = p_gratis,
    fragil = p_fragil WHERE cod_frete = p_cod_frete;
COMMIT;
END;

CREATE OR REPLACE PROCEDURE DeleteImagens (p_cod_produto IN imagem_produto.cod_produto%TYPE)
IS BEGIN
    DELETE FROM IMAGEM_PRODUTO WHERE cod_produto = p_cod_produto;
COMMIT;
END;

CREATE OR REPLACE PROCEDURE DeleteProdForn (p_cod_produto IN produto_fornecedor.cod_prod%TYPE)
IS BEGIN
    DELETE FROM produto_fornecedor WHERE cod_prod = p_cod_produto;
COMMIT;
END;

CREATE OR REPLACE PROCEDURE DeleteEspecProd (p_cod_produto IN especificacao_produto.cod_prod%TYPE)
IS BEGIN
    DELETE FROM especificacao_produto WHERE cod_prod = p_cod_produto;
COMMIT;
END;

CREATE OR REPLACE PROCEDURE DeleteProduto (p_cod_produto IN produtos.cod_produto%TYPE, p_cod_frete IN produtos.cod_frete%TYPE)
IS BEGIN
    DELETE FROM Produtos WHERE cod_produto = p_cod_produto;
    DELETE FROM Produto_Fornecedor WHERE cod_prod = p_cod_produto;
    DELETE FROM Imagem_Produto WHERE cod_produto = p_cod_produto;
    DELETE FROM Frete WHERE cod_frete = p_cod_frete;
    DELETE FROM Log_Produto WHERE cod_produto = p_cod_produto;
    DELETE FROM Especificacao_Produto WHERE cod_prod = p_cod_produto;
COMMIT;
END;

CREATE OR REPLACE PROCEDURE insert_fornecedores(
	   p_cod_endereco   IN fornecedor.cod_endereco%TYPE,
	   p_cod_contato    IN fornecedor.cod_contato%TYPE,
	   p_nome           IN fornecedor.nome%TYPE,
	   p_cnpj           IN fornecedor.cnpj%TYPE,
       p_estadual       IN fornecedor.ins_estadual%TYPE,
       p_descricao      IN fornecedor.descricao%TYPE)
IS	  
BEGIN
  INSERT INTO fornecedor
  VALUES (seq_fornecedor.NEXTVAL, p_cod_endereco, p_cod_contato,
          p_nome, p_cnpj, p_estadual, p_descricao);
  COMMIT;
END;
commit;
CREATE OR REPLACE PROCEDURE update_fornecedor(
       p_cod_fornecedor IN fornecedor.cod_fornecedor%TYPE,
	   p_nome           IN fornecedor.nome%TYPE,
	   p_cnpj           IN fornecedor.cnpj%TYPE,
       p_estadual       IN fornecedor.ins_estadual%TYPE,
       p_descricao      IN fornecedor.descricao%TYPE)
IS
BEGIN
  UPDATE fornecedor SET  nome = p_nome,
  cnpj = p_cnpj, ins_estadual = p_estadual, descricao = p_descricao
  WHERE cod_fornecedor = p_cod_fornecedor;
  COMMIT;
END;

CREATE OR REPLACE PROCEDURE insert_endereco(
       p_cod_endereco IN endereco.cod_endereco%TYPE,
	   p_tipo   IN endereco.tipo%TYPE,
       p_cep    IN endereco.cep%TYPE,
       p_cidade IN endereco.cidade%TYPE,
       p_estado IN endereco.estado%TYPE,
       p_bairro IN endereco.bairro%TYPE,
       p_rua    IN endereco.rua%TYPE,
       p_numero IN endereco.numero%TYPE,
       p_complemento IN endereco.complemento%TYPE)
IS	  
BEGIN
  INSERT INTO endereco
  VALUES (p_cod_endereco, p_tipo, p_cep, p_cidade,
          p_estado, p_bairro, p_rua, p_numero, p_complemento);
  COMMIT;
END;

CREATE OR REPLACE PROCEDURE update_endereco(
       p_cod_endereco IN endereco.cod_endereco%TYPE,
	   p_tipo   IN endereco.tipo%TYPE,
       p_cep    IN endereco.cep%TYPE,
       p_cidade IN endereco.cidade%TYPE,
       p_estado IN endereco.estado%TYPE,
       p_bairro IN endereco.bairro%TYPE,
       p_rua    IN endereco.rua%TYPE,
       p_numero IN endereco.numero%TYPE,
       p_complemento IN endereco.complemento%TYPE)
IS	  
BEGIN
  UPDATE endereco SET tipo = p_tipo, cep = p_cep,
  cidade = p_cidade, estado = p_estado, bairro = p_bairro,
  rua = p_rua, numero = p_numero, complemento = p_complemento
  WHERE cod_endereco = p_cod_endereco;
  COMMIT;
END;

CREATE OR REPLACE PROCEDURE insert_contato(
    p_cod_contato IN contato.cod_contato%TYPE,
    p_telefone IN contato.telefone%TYPE,
    p_celular IN contato.celular%TYPE,
    p_email IN contato.email%TYPE)
IS BEGIN
    INSERT INTO contato VALUES
    (p_cod_contato, p_telefone, p_celular, p_email);
COMMIT;
END;

CREATE OR REPLACE PROCEDURE update_contato(
    p_cod_contato IN contato.cod_contato%TYPE,
    p_telefone IN contato.telefone%TYPE,
    p_celular IN contato.celular%TYPE,
    p_email IN contato.email%TYPE)
IS BEGIN
      UPDATE contato SET telefone = p_telefone,
      celular = p_celular, email = p_email
      WHERE cod_contato = p_cod_contato;
COMMIT;
END;

CREATE OR REPLACE PROCEDURE DeleteFornecedor (p_cod_fornecedor IN fornecedor.cod_fornecedor%TYPE)
IS BEGIN
    DELETE FROM fornecedor WHERE cod_fornecedor = p_cod_fornecedor;
    DELETE FROM produto_fornecedor WHERE cod_fornecedor = p_cod_fornecedor;
COMMIT;
END;


CREATE OR REPLACE PROCEDURE insert_usuario (
p_cod_usuario IN usuario.cod_usuario%TYPE,
p_cod_acesso IN usuario.cod_acesso%TYPE,
p_cod_sexo IN usuario.cod_sexo%TYPE,
p_nome IN usuario.nome%TYPE,
p_sobrenome IN usuario.sobrenome%TYPE,
p_username IN usuario.username%TYPE,
p_email IN usuario.email%TYPE,
p_senha IN usuario.senha%TYPE,
p_datacadastro IN Varchar2,
p_picture IN USUARIO.PICTURE%TYPE)
IS BEGIN
INSERT INTO usuario
VALUES(p_cod_usuario, p_cod_acesso, p_cod_sexo, p_nome, p_sobrenome,
p_username, p_email, p_senha, TO_DATE(p_datacadastro,'DD/MM/YYYY HH24:MI:SS'), p_picture);
UPDATE max_seq SET valor = p_cod_usuario WHERE cod_seq = 2;
COMMIT;
END;

CREATE OR REPLACE PROCEDURE update_usuario (
p_cod_usuario IN usuario.cod_usuario%TYPE,
p_cod_acesso IN usuario.cod_acesso%TYPE,
p_cod_sexo IN usuario.cod_sexo%TYPE,
p_nome IN usuario.nome%TYPE,
p_sobrenome IN usuario.sobrenome%TYPE,
p_username IN usuario.username%TYPE,
p_email IN usuario.email%TYPE,
p_senha IN usuario.senha%TYPE,
p_picture IN usuario.picture%TYPE)
IS BEGIN
UPDATE usuario SET cod_acesso = p_cod_acesso, cod_sexo = p_cod_sexo,
nome = p_nome, sobrenome = p_sobrenome, username = p_username,
email = p_email, senha = p_senha, 
picture = p_picture WHERE cod_usuario = p_cod_usuario;
COMMIT;
END;

CREATE OR REPLACE PROCEDURE delete_usuario(p_cod_usuario IN usuario.cod_usuario%TYPE)
IS BEGIN
DELETE FROM usuario WHERE cod_usuario = p_cod_usuario;
COMMIT;
END;


CREATE OR REPLACE PROCEDURE insert_venda(
p_id_venda IN venda.id_venda%TYPE,
p_id_tipo  IN venda.id_tipo%TYPE,
p_id_cliente IN venda.id_cliente%TYPE,
p_id_info IN venda.id_info%TYPE,
p_data_venda IN VARCHAR2)
IS BEGIN
INSERT INTO VENDA VALUES(p_id_venda, p_id_tipo,
p_id_cliente, p_id_info, TO_DATE(p_data_venda,'DD/MM/YYYY HH24:MI:SS'));
COMMIT;
END;

CREATE OR REPLACE PROCEDURE insert_item_venda(
p_id_venda IN item_venda.id_venda%TYPE,
p_id_produto IN item_venda.id_produto%TYPE,
p_preco_unit IN item_venda.preco_unit%TYPE,
p_quantidade IN item_venda.quantidade%TYPE)
IS BEGIN
INSERT INTO item_venda VALUES(p_id_venda,
p_id_produto, p_preco_unit, p_quantidade);
COMMIT;
END;

CREATE OR REPLACE PROCEDURE insert_pagamento(
p_id_venda IN pagamento.id_venda%TYPE,
p_tipo IN pagamento.tipo%TYPE,
p_valor IN pagamento.valor%TYPE)
IS BEGIN
INSERT INTO pagamento 
VALUES(p_id_venda, p_tipo, p_valor);
COMMIT;
END;

CREATE OR REPLACE PROCEDURE insert_info_venda(
p_id_info IN info_venda.id_info%TYPE,
p_nome IN info_venda.nome%TYPE,
p_cpf IN info_venda.cpf%TYPE)
IS BEGIN
INSERT INTO info_venda
VALUES(p_id_info, p_nome, p_cpf);
COMMIT;
END;

CREATE OR REPLACE PROCEDURE insert_mensagem (
p_mensagem IN mensagem.mensagem%TYPE,
p_nome IN mensagem.nome %TYPE,
p_email IN mensagem.email %TYPE)
IS BEGIN
INSERT INTO mensagem VALUES(seq_mensagem.NEXTVAL, p_mensagem, p_nome, p_email);
COMMIT;
END;
