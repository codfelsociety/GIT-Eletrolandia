using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Collections.ObjectModel;
using Util;
namespace BLL
{
    public class Search
    {
        public List<SearchItem> SearchItens(string pesquisa)
        {
            List<SearchItem> nice = new List<SearchItem>();
            string SQL = $@"SELECT prod.COD_PRODUTO, prod.NOME, prod.COD_BARRAS, logprod.PRECO, img.IMAGEM
                         FROM PRODUTOS prod JOIN 
                         (SELECT inn.* FROM (SELECT log2.*, (ROW_NUMBER() OVER(PARTITION BY cod_produto ORDER BY cod_log_prod DESC)) As Rank 
                         FROM log_produto log2) inn WHERE inn.Rank=1) logprod
                         ON  prod.cod_produto = logprod.cod_produto
                         LEFT JOIN
                         (SELECT inn.* FROM (SELECT img2.*, (ROW_NUMBER() OVER(PARTITION BY cod_produto ORDER BY cod_produto DESC)) As Rank 
                         FROM imagem_produto img2) inn WHERE inn.Rank=1) img
                         ON prod.cod_produto = img.cod_produto
                         WHERE upper(prod.nome) LIKE upper('%{pesquisa}%')";
            ClasseConexao.Conexao();
            DataTable dt =  ClasseConexao.RetornarDataTable(SQL);
            nice = (from DataRow r in dt.Rows
                    select new SearchItem
                    (Convert.ToInt32(r["COD_PRODUTO"]),
                     r["NOME"].ToString(),
                     Convert.ToDecimal(r["PRECO"].ToString()),
                     Convert.ToInt32(r["COD_BARRAS"]),
                     IConvert.ToImageSource((r["IMAGEM"]))
                     )).ToList();
            return nice;
        }
    }
}
