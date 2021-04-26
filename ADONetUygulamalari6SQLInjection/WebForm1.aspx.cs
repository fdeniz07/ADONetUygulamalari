using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ADONetUygulamalari6SQLInjection
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string Command = "select * from tblProduct where Name like '" + TextBox1.Text + "%'";

                /*Acik birakilan sql sorgusu, kötü niyetli kisilerce suistimal edilerek tablolarimiz klonlanabilir ya da silinebilir. Buraya cok dikkat etmek lazim. 
                  SQL Injektion saldirisi textbox'u kullaniciya actigimiz zaman sizma islemi gerceklesiyor.
                  Sql dilinde yorum satiri -- ile saglandigi icin kötü niyetli kisi su kodu yazabilir:
                ip'; Delete from tblProduct --
                */

                SqlCommand cmd = new SqlCommand(Command, con);
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }
    }
}