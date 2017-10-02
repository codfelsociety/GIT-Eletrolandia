using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Confirmacao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Id");
        dt.Columns.Add("Nome");
        dt.Columns.Add("Preço");
        dt.Columns.Add("Quantidade");

        dt.Rows.Add(1, "Computador 4gb", 1999.99, 1);
        dt.Rows.Add(2, "iPhone X", 850.50, 2);
        dt.Rows.Add(3, "Headset", 350.00, 1);
        dt.Rows.Add(4, "Webcam", 200.50, 1);



        GridView1.DataSource = dt.DefaultView;
        GridView1.DataBind();

    }
}