using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataSetCaching
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLoadData_Click(object sender, EventArgs e)
        {
            if (Cache["Data"] == null)
            {
                string CS = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from tblProduct", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    Cache["Data"] = ds;

                    gvProducts.DataSource = ds;
                    gvProducts.DataBind();
                }
                lblMessage.Text = "Data loaded from the database";
            }
            else
            {
                gvProducts.DataSource = (DataSet)Cache["Data"];
                gvProducts.DataBind();
                lblMessage.Text = "Data loaded from the cache";
            }            
        }

        protected void btnClearCache_Click(object sender, EventArgs e)
        {
            if (Cache["Data"]!=null)
            {
                Cache.Remove("Data");
                lblMessage.Text = "The Dataset is removed from the cache";
                gvProducts.DataSource = (DataSet)Cache["Data"];
                gvProducts.DataBind();
            }
            else
            {
                lblMessage.Text = "There is nothing in the cache to be removed";
            }
        }
    }
}