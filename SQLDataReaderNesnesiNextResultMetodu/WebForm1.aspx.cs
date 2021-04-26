using System;
using System.Configuration;
using System.Data.SqlClient;

namespace SQLDataReaderNesnesiNextResultMetodu
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from tblProduct; Select * from tblProductCategories", con);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    ProductGridView.DataSource = rdr;
                    ProductGridView.DataBind();
                    while (rdr.NextResult())
                    {
                        CategoriesGridView.DataSource = rdr;
                        CategoriesGridView.DataBind();
                    }
                }
            }
        }
    }
}