using Oracle.DataAccess.Client;
using System.Data;
using DAO;

using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.IO;

namespace BLL
{
    public class Produtos
    {
        private static string SQL;
        private static OracleDataReader dr;
        private static OracleDataAdapter da;
        private DataSet ds;
        private OracleCommand cmd;

        private ClasseConexao con = new ClasseConexao();
        public static DataTable dtProdutos;
        public static DataTable dtCategorias;
        public static DataTable dtFornecedores;
        public static DataTable dtArtigos;
        public static DataTable dtEspecs;
        public static DataTable dtPreEspecs;
        public static DataTable dtConsultaCod;
        public static DataTable dtConsultaNome;
        public static DataTable dtRelatorioProdutos;

        private int _codProduto;
        private int _codArtigo;
        private int _codMarca;
        private int _codFrete;
        private int _codBarras;
        private string _nome;
        private string _localDescricao;
        private int _estoque;
        private int _estoqueMin;
        private int _estoqueMax;
        private int _codStatus;
        private int _limitado;
        private int _online;
        private string _dataCadastro;
        private decimal _custo;
        private decimal _preco;
        private DataTable _fornecedores;
        private DataTable _imagemProduto;

        public int CodProduto { get => _codProduto; set => _codProduto = value; }
        public int CodArtigo { get => _codArtigo; set => _codArtigo = value; }
        public int CodMarca { get => _codMarca; set => _codMarca = value; }
        public int CodFrete { get => _codFrete; set => _codFrete = value; }
        public int CodBarras { get => _codBarras; set => _codBarras = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string LocalDescricao { get => _localDescricao; set => _localDescricao = value; }
        public int Estoque { get => _estoque; set => _estoque = value; }
        public int EstoqueMin { get => _estoqueMin; set => _estoqueMin = value; }
        public int EstoqueMax { get => _estoqueMax; set => _estoqueMax = value; }
        public int CodStatus { get => _codStatus; set => _codStatus = value; }
        public string DataCadastro { get => _dataCadastro; set => _dataCadastro = value; }
        public DataTable Fornecedores { get => _fornecedores; set => _fornecedores = value; }
        public decimal Custo { get => _custo; set => _custo = value; }
        public decimal Preco { get => _preco; set => _preco = value; }
        public DataTable ImagemProduto { get => _imagemProduto; set => _imagemProduto = value; }
        public int Limitado { get => _limitado; set => _limitado = value; }
        public int Online { get => _online; set => _online = value; }

        public void Cadastrar()
        {
            ClasseConexao.Conexao();
            cmd = new OracleCommand("insert_produto", ClasseConexao.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_produto", "NUMBER").Value = CodProduto;
            cmd.Parameters.Add("p_cod_artigo", "NUMBER").Value = CodArtigo;
            cmd.Parameters.Add("p_cod_marca", "NUMBER").Value = CodMarca;
            cmd.Parameters.Add("p_cod_frete", "NUMBER").Value = CodFrete;
            cmd.Parameters.Add("p_cod_barras", "NUMBER").Value = CodBarras;
            cmd.Parameters.Add("p_nome", "VARCHAR2").Value = Nome;
            cmd.Parameters.Add("p_descricao", "VARCHAR2").Value = LocalDescricao;
            cmd.Parameters.Add("p_estoque", "NUMBER").Value = Estoque;
            cmd.Parameters.Add("p_estoque_min", "NUMBER").Value = EstoqueMin;
            cmd.Parameters.Add("p_estoque_max", "NUMBER").Value = EstoqueMax;
            cmd.Parameters.Add("p_ativo", "NUMBER").Value = CodStatus;
            cmd.Parameters.Add("p_online", "NUMBER").Value = Online;
            cmd.Parameters.Add("p_limitado", "NUMBER").Value = Limitado;
            cmd.Parameters.Add("p_data_cadastro", "VARCHAR2").Value = DataCadastro;
            cmd.ExecuteNonQuery();
            foreach (DataRow r in Fornecedores.Rows)
            {
                ClasseConexao.Conexao();
                cmd = new OracleCommand("insert_produto_fornecedor", ClasseConexao.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_cod_prod", "NUMBER").Value = CodProduto;
                cmd.Parameters.Add("p_cod_fornecedor", "NUMBER").Value = Convert.ToInt32(r[0]);
                cmd.ExecuteNonQuery();
            }
            ClasseConexao.Conexao();
            cmd = new OracleCommand("insert_log_produto", ClasseConexao.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_produto", "NUMBER").Value = CodProduto;
            cmd.Parameters.Add("p_data", "VARCHAR2").Value = DataCadastro;
            cmd.Parameters.Add("p_custo", "NUMBER").Value = Custo;
            cmd.Parameters.Add("p_preco", "NUMBER").Value = Preco;
            cmd.ExecuteNonQuery();
            if (ImagemProduto.Rows != null)
            {
                foreach (DataRow r in ImagemProduto.Rows)
                {
                    ClasseConexao.Conexao();
                    cmd = new OracleCommand("insert_imagem_produto", ClasseConexao.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_cod_produto", OracleDbType.Int32).Value = CodProduto;
                    string test = r[1].ToString();
                    PngBitmapEncoder p = new PngBitmapEncoder();
                    byte[] blob = ImageSourceToBytes(p, r[1] as ImageSource);

                    cmd.Parameters.Add("p_imagem", OracleDbType.Blob).Value = blob;
                    cmd.Parameters.Add("p_descricao", OracleDbType.Varchar2).Value = "";
                    cmd.ExecuteNonQuery();

                }
            }
        }
        public byte[] ImageSourceToBytes(BitmapEncoder encoder, ImageSource imageSource)
        {
            byte[] bytes = null;
            var bitmapSource = imageSource as BitmapSource;

            if (bitmapSource != null)
            {
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));

                using (var stream = new MemoryStream())
                {
                    encoder.Save(stream);
                    bytes = stream.ToArray();
                }
            }

            return bytes;
        }
        public static byte[] ImageToArray(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }

        public void CadastrarEspecs(int codEspec, int codPre)
        {
            ClasseConexao.Conexao();
            cmd = new OracleCommand("insert_espec_prod", ClasseConexao.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_espec", "NUMBER").Value = codEspec;
            cmd.Parameters.Add("p_cod_prod", "NUMBER").Value = CodProduto;
            cmd.Parameters.Add("p_valor_espec", "VARCHAR2").Value = "";
            cmd.Parameters.Add("p_cod_pre_valor", "NUMBER").Value = codPre;
            cmd.ExecuteNonQuery();
        }
        public void DeletarProduto(int codProd, int codfrete)
        {
            ClasseConexao.Conexao();
            cmd = new OracleCommand("DeleteProduto", ClasseConexao.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_produto", "NUMBER").Value = codProd;
            cmd.Parameters.Add("p_cod_frete", "NUMBER").Value = codfrete;
            cmd.ExecuteNonQuery();
        }
        public static int RetornarID(int tipo)
        {
            if (tipo == 0)
            {
                SQL = "SELECT valor FROM max_seq WHERE cod_seq = 1";
                int d = ClasseConexao.ExecutarComandoRetorno(SQL);
                return d + 1;
            }
            else if (tipo == 1)
            {
                SQL = "SELECT seq_produtos.NEXTVAL FROM dual";
                int d = ClasseConexao.ExecutarComandoRetorno(SQL);
                SQL = "UPDATE max_seq SET valor=" + d.ToString() + " WHERE nome= 'seq_produtos'";
                ClasseConexao con = new ClasseConexao();
                con.ExecutarComando(SQL);
                return d;
            }
            else
            {
                MessageBox.Show("Parâmetro do método RetornarProxID de BLL.Produtos incorreto. \nValores permitidos: 0 (motrar) e 1(cadastrar).");
                return 99999;
            }

        }
        public static void CarregarEspecs(int cod_artigo)
        {
            SQL = "SELECT ES.COD_ESPECIFICACAO AS COD_ESPEC, ES.DESCRICAO AS DESCRICAO, ES.TIPO AS TIPO " +
                  "FROM ESPECIFICACAO ES " +
                  "JOIN ESPECIFICACAO_ARTIGO EA " +
                  "ON EA.COD_ESPECIFICACAO = ES.COD_ESPECIFICACAO " +
                  "JOIN ARTIGO AR " +
                  "ON AR.COD_ARTIGO = EA.COD_ARTIGO_PRODUTO " +
                  "WHERE AR.COD_ARTIGO = " + cod_artigo.ToString();
            DataTable d = ClasseConexao.RetornarDataTable(SQL);
            dtEspecs = d;
        }
        public static void CarregarPreEspecValues(int cod_espec)
        {
            SQL = "SELECT PRE.COD_ESPEC_PRE_VALOR AS COD_PRE, PRE.VALOR AS VALOR " +
                  "FROM ESPECIFICACAO_PRE_VALORES PRE " +
                  "JOIN ESPECIFICACAO ES " +
                  "ON ES.COD_ESPECIFICACAO = PRE.COD_ESPECIFICACAO " +
                  "WHERE ES.COD_ESPECIFICACAO = " + cod_espec;
            DataTable d = ClasseConexao.RetornarDataTable(SQL);
            dtPreEspecs = d;
        }
        public DataTable PreencherTabela()
        {
            SQL = @"SELECT prod.cod_produto AS cod,  img.imagem as IMGPATH, prod.nome, art.descricao AS artigo, cat.descricao AS categoria,
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
                            ON prod.cod_produto = img.cod_produto ORDER BY prod.cod_produto";
            return ClasseConexao.RetornarDataTable(SQL);
        }

        public void AtualizarProduto()
        {
            ClasseConexao.Conexao();
            cmd = new OracleCommand("UpdateProduto", ClasseConexao.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_artigo", "NUMBER").Value = CodArtigo;
            cmd.Parameters.Add("p_cod_marca", "NUMBER").Value = CodMarca;
            cmd.Parameters.Add("p_cod_barras", "NUMBER").Value = CodBarras;
            cmd.Parameters.Add("p_nome", "VARCHAR2").Value = Nome;
            cmd.Parameters.Add("p_descricao", "VARCHAR2").Value = LocalDescricao;
            cmd.Parameters.Add("p_estoque", "NUMBER").Value = Estoque;
            cmd.Parameters.Add("p_estoque_min", "NUMBER").Value = EstoqueMin;
            cmd.Parameters.Add("p_estoque_max", "NUMBER").Value = EstoqueMax;
            cmd.Parameters.Add("p_ativo", "CHAR").Value = (CodStatus);
            cmd.Parameters.Add("p_online", "NUMBER").Value = Online;
            cmd.Parameters.Add("p_limitado", "NUMBER").Value = Limitado;
            cmd.Parameters.Add("p_cod_produto", "NUMBER").Value = CodProduto;
            cmd.ExecuteNonQuery();
            ClasseConexao.Conexao();
            cmd = new OracleCommand("insert_log_produto", ClasseConexao.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_produto", "NUMBER").Value = CodProduto;
            cmd.Parameters.Add("p_data", "VARCHAR2").Value = DateTime.Now.ToString();
            cmd.Parameters.Add("p_custo", "NUMBER").Value = Custo;
            cmd.Parameters.Add("p_preco", "NUMBER").Value = Preco;
            cmd.ExecuteNonQuery();
            ClasseConexao.Conexao();
            cmd = new OracleCommand("DeleteImagens", ClasseConexao.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_produto", "NUMBER").Value = CodProduto;
            cmd.ExecuteNonQuery();
            if (ImagemProduto.Rows != null)
            {
                foreach (DataRow r in ImagemProduto.Rows)
                {
                    ClasseConexao.Conexao();
                    cmd = new OracleCommand("insert_imagem_produto", ClasseConexao.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_cod_produto", OracleDbType.Int32).Value = CodProduto;
                    string test = r[1].ToString();
                    PngBitmapEncoder p = new PngBitmapEncoder();
                    byte[] blob = ImageSourceToBytes(p, r[1] as ImageSource);

                    cmd.Parameters.Add("p_imagem", OracleDbType.Blob).Value = blob;
                    cmd.Parameters.Add("p_descricao", OracleDbType.Varchar2).Value = "";
                    cmd.ExecuteNonQuery();
                }
            }
            ClasseConexao.Conexao();
            cmd = new OracleCommand("DeleteProdForn", ClasseConexao.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_produto", "NUMBER").Value = CodProduto;
            cmd.ExecuteNonQuery();
            foreach (DataRow r in Fornecedores.Rows)
            {
                ClasseConexao.Conexao();
                cmd = new OracleCommand("insert_produto_fornecedor", ClasseConexao.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_cod_prod", "NUMBER").Value = CodProduto;
                cmd.Parameters.Add("p_cod_fornecedor", "NUMBER").Value = Convert.ToInt32(r[0]);
                cmd.ExecuteNonQuery();
            }
            ClasseConexao.Conexao();
            cmd = new OracleCommand("DeleteEspecProd", ClasseConexao.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_produto", "NUMBER").Value = CodProduto;
            cmd.ExecuteNonQuery();
        }
        public int RetornarFrete(int codprod)
        {
            SQL = $"SELECT COD_FRETE FROM PRODUTOS WHERE COD_PRODUTO = {codprod}";
            return Convert.ToInt32(ClasseConexao.RetornarDataTable(SQL).Rows[0][0]);
        }
        public List<DataTable> PreCarregar()
        {
            List<DataTable> p = new List<DataTable>();
            SQL = $@"SELECT prod.COD_BARRAS, prod.NOME, prod.DESCRICAO, prod.ESTOQUE,
                        prod.ESTOQUE_MIN, prod.ESTOQUE_MAX, prod.ATIVO, prod.ON_LINE,
                        prod.LIMITADO,  prod.DATA_CADASTRO, prod.cod_artigo,
                        art.COD_CATEGORIA, prod.COD_MARCA, logp.CUSTO, logp.preco,  fr.PESO, fr.ALTURA,
                        fr.COMPRIMENTO, fr.LARGURA, fr.FRAGIL, fr.gratis, fr.COD_FRETE
                        FROM PRODUTOS prod
                        JOIN ARTIGO art
                        ON prod.cod_artigo = art.COD_ARTIGO
                        JOIN LOG_PRODUTO logp
                        ON logp.COD_PRODUTO = prod.COD_PRODUTO
                        JOIN FRETE fr
                        ON fr.COD_FRETE = prod.COD_FRETE
                        WHERE prod.COD_PRODUTO = {CodProduto}
                        ORDER BY logp.cod_log_prod desc";
            p.Add(ClasseConexao.RetornarDataTable(SQL));
            SQL = $@"SELECT prodf.cod_fornecedor, forn.nome
                        from produto_fornecedor prodf
                        JOIN fornecedor forn
                        ON prodf.cod_fornecedor = forn.cod_fornecedor
                        where prodf.cod_prod ={CodProduto}";
            p.Add(ClasseConexao.RetornarDataTable(SQL));
            SQL = $@"SELECT img.COD_PRODUTO, img.imagem
                        FROM IMAGEM_PRODUTO img
                        WHERE img.COD_PRODUTO = {CodProduto}";
            p.Add(ClasseConexao.RetornarDataTable(SQL));
            return p;
        }
        public int RetornarPreValor(int cod_espec, int cod_produto)
        {
            SQL = $@"SELECT ep.COD_PRE_VALOR
                        FROM ESPECIFICACAO_PRODUTO ep
                        WHERE ep.COD_PROD = {cod_produto}
                        AND ep.COD_ESPECIFICACAO = {cod_espec}" ;
            int x = Convert.ToInt32(ClasseConexao.RetornarDataTable(SQL).Rows[0][0].ToString());
            return x;
        }
    }
}
