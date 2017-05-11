using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Product
{
    public partial class ProductsForm : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source =.; Initial Catalog = Products; Integrated Security = True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from tblProducts", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                conn.Close();
            }
        }

        protected void btn_Submit(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (SqlCommand cmd = new SqlCommand("insert into tblProducts values ('" + TextBox1.Text + "','" + DropDownList1.Text + "','" + Convert.ToInt32(TextBox3.Text) + "','" + Convert.ToInt32(TextBox4.Text) + "','" + TextBox5.Text + "')", conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    GridView1.DataBind();
                }

                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "test", "<script>alert('Successfully Inserted.....!');</script>");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "test", "<script>alert('Validation failed!');</script>");

            }

        }

        protected void btn_Reset(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            DropDownList1.SelectedIndex=0;
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
        }
    }
}