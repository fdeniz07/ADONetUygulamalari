using System;
using System.Configuration;
using System.Data.SqlClient;

namespace OutputParametreliStoredProcedure
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("upAddEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name",txtEmployeeName.Text);
                cmd.Parameters.AddWithValue("@Gender",ddlGender.SelectedValue);
                cmd.Parameters.AddWithValue("@Salary",txtSalary.Text);
                cmd.Parameters.AddWithValue("@DepartmentId",ddlDepartmenId.SelectedValue);

                SqlParameter outParameter = new SqlParameter();
                outParameter.ParameterName = "@EmployeeId";
                outParameter.SqlDbType = System.Data.SqlDbType.Int;
                outParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outParameter);

                con.Open();
                cmd.ExecuteNonQuery();

                string EmpId = outParameter.Value.ToString();
                lblMessage.Text = "Employee Id = " + EmpId;
            }
        }
    }
}
