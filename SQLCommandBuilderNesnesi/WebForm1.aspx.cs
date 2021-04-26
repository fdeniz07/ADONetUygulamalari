using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SQLCommandBuilderNesnesi
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetStudent_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            string sqlQuery = "select * from tblStudents where ID = " + txtStudentID.Text;
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Students");

            ViewState["SQL_QUERY"] = sqlQuery;
            ViewState["DATASET"] = ds;

            if (ds.Tables["Students"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["Students"].Rows[0];
                txtStudentName.Text = dr["Name"].ToString();
                txtTotalMarks.Text = dr["TotalMarks"].ToString();
                ddlGender.SelectedValue = dr["Gender"].ToString();
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "No Student record with ID = " + txtStudentID.Text;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter((string)ViewState["SQL_QUERY"], con);

            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            DataSet ds = (DataSet)ViewState["DATASET"];

            if (ds.Tables["Students"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["Students"].Rows[0];
                dr["Name"] = txtStudentName.Text;
                dr["Gender"] = ddlGender.SelectedValue;
                dr["TotalMarks"] = txtTotalMarks.Text;
            }
            int rowsUpdated = da.Update(ds, "Students");
            if (rowsUpdated > 0)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = rowsUpdated.ToString() + " row(s) updates";
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = rowsUpdated.ToString() + "No row updated";
            }
        }
    }
}