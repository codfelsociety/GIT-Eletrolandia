using Microsoft.Reporting.WinForms;
using ProjetoTCC.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace ProjetoTCC.Assets.Pages.InProducts
{
    /// <summary>
    /// Interação lógica para Reports.xam
    /// </summary>
    public partial class Reports : Page
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {

        }

        private void SimpleReport_Click(object sender, RoutedEventArgs e)
        {
            DAO.ClasseConexao.Conexao();
            string SQL = $@"SELECT prod.nome, logp.custo, logp.preco
                                    FROM produtos prod
                                    JOIN 
                                    (SELECT inn.* FROM (SELECT log2.*, (ROW_NUMBER() OVER(PARTITION BY cod_produto ORDER BY cod_log_prod DESC)) As Rank 
                                     FROM log_produto log2) inn WHERE inn.Rank=1) logp
                                     ON  prod.cod_produto = logp.cod_produto";

            DataTable dt = DAO.ClasseConexao.RetornarDataTable(SQL);
            var dadosRelatorio = new List<DataSet1.DataTable1DataTable>();
            foreach (DataRow r in dt.Rows)
            {
                string nome = r[0].ToString();
                decimal custo = System.Convert.ToDecimal(r[1]);
                decimal preco = System.Convert.ToDecimal(r[2]);
                dadosRelatorio.Add(new DataSet1.DataTable1DataTable() { Nome =nome , Custo = custo, Preco = preco });
            }


            var dataSource = new ReportDataSource("DataSet1", dadosRelatorio);
            ReportViewer.LocalReport.DataSources.Add(dataSource);
            ReportViewer.LocalReport.ReportEmbeddedResource = "ProjetoTCC.Reports.Report1.rdlc";

            ReportViewer.RefreshReport();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
