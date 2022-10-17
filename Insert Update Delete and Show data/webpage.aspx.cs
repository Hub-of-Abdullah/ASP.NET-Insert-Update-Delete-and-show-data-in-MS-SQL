using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace Insert_Update_Delete_and_Show_data
{
    public partial class webpage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\studentInfomation.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open) { con.Close(); } 
            con.Open();
            DisplayData();
        }

        protected void btnStudentInfoSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO studentTable VALUES('"+ studentFirstName.Text+ "','"+ studentLastName.Text+"','"+ studentClassName.Text +"','"+Convert.ToInt32(studentRollNo.Text)+"','"+Convert.ToDouble(studentResult.Text)+"')";
            cmd.ExecuteNonQuery();
            studentFirstName.Text = "";
            studentLastName.Text = "";
            studentClassName.Text = "";
            studentRollNo.Text = "";
            studentResult.Text = "";

            DisplayData();
        }
        public void DisplayData()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT id AS ID, firstName AS FirstName, lastName As LastName, className AS Class, rollNo AS RollNo, Result AS Result  FROM studentTable";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
           
            StudentInfoDisplayGrid.DataSource = dt;
            StudentInfoDisplayGrid.DataBind();
            
        }

        protected void btnStudentInfoShow_Click(object sender, EventArgs e)
        {

            DisplayDataEachClassGrid();
        }

        public void DisplayDataEachClassGrid(int flag )
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM studentTable WHERE className = '" + classForShow.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            EachClassGrid.DataSource = dt;
            EachClassGrid.DataBind();

            classForShow.Text = "";
        }

        protected void btnStudentInfoDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM studentTable WHERE id = '" + Convert.ToInt32(UpdateDeleteTextBox.Text) + "'";
            cmd.ExecuteNonQuery();
            classForShow.Text = "";
            DisplayData();
            /// DisplayDataEachClassGrid(2);//For update EachClass Grid
            UpdateDeleteTextBox.Text = "";
        }

        protected void btnStudentInfoUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE studentTable SET firstName= '"+ studentFirstName.Text + "', lastName = '"+ studentLastName.Text + "', className = '"+ studentClassName.Text +"', rollNo ='"+Convert.ToInt32(studentRollNo.Text) + "', Result = '"+Convert.ToDouble(studentResult.Text)+"'  WHERE id = '" + Convert.ToInt32(UpdateDeleteTextBox.Text) + "'";
            cmd.ExecuteNonQuery();
            DisplayData();
           /// DisplayDataEachClassGrid(2);//For update EachClass Grid

            studentFirstName.Text = "";
            studentLastName.Text = "";
            studentClassName.Text = "";
            studentRollNo.Text = "";
            studentResult.Text = "";
            UpdateDeleteTextBox.Text = "";
        }
    }
}