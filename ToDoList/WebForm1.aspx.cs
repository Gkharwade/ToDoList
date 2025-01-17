using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace ToDoList
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            getbind();
            

        }
        protected void ADD_btn(object sender, EventArgs e)
        {
            try
            {
                string TaskName= Task.Value;
                string Date = txtDate.Text;
                string query = "Insert into ToDo ( Task,TaskDate) values (@taskname,@tskdate) ";
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@taskname",TaskName );
                cmd.Parameters.AddWithValue("@tskdate", Date);
                int RowsAffected= cmd.ExecuteNonQuery();
                conn.Close();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("inserted");
                    getbind();
                }
                else
                {
                    MessageBox.Show("not inserted");
                }
                        
                        

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getbind()
        {
            try
            {
                string querry = "select * from ToDo WHERE TaskStat='Pending'";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd =new SqlCommand(querry, con);
                con.Open();
                SqlDataAdapter adapter= new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                 
                if(dataSet.Tables.Count >= 0)
                {
                    if(dataSet.Tables[0].Rows.Count >= 0)
                    {
                        GridView1.DataSource = dataSet.Tables[0];
                         GridView1.DataBind();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int TID=0 ;
            try
            {
                GridViewRow selectrow = GridView1.SelectedRow;
                
                if (selectrow !=null)
                {
                    Literal LiteralID = (Literal)selectrow.FindControl("TASKNO");
                    TID = Convert.ToInt32(LiteralID.Text.Trim());
                   
                }
                SqlConnection con = new SqlConnection(connectionString);
                string querry = "update ToDo set TaskStat='DONE' WHERE TaskID=@TaskID ";
                SqlCommand cmd = new SqlCommand(querry, con);
                con.Open();
                cmd.Parameters.AddWithValue("@TaskID" ,TID);
                int RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("YOUR TASK IS COMPLEDTED");
                    getbind();
                }
                else

                {
                    MessageBox.Show("TASK NOT COMPLETED");
                }

            }
            catch(Exception Ex) {
            MessageBox.Show(Ex.Message);
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                // Get the TaskID (primary key) of the selected row
                int TaskID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

                // SQL query to delete the row from the database
                string query = "DELETE FROM ToDo WHERE TaskID = @TaskID";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@TaskID", TaskID);

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();

                        // Display success message and refresh the GridView
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Task deleted successfully.");
                            getbind(); // Rebind the GridView
                        }
                        else
                        {
                            MessageBox.Show("Task not found or could not be deleted.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }

}