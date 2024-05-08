using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class Addbooks : Form
    {
        public Addbooks()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text != "" && txtAuthor.Text != "" && txtPublication.Text != "" && txtPrice.Text != "" && txtQuantity.Text != "")
            {




                String bname = txtBookName.Text;
                String bauthor = txtAuthor.Text;
                String publication = txtPublication.Text;
                String pdate = dateTimePicker1.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                Int64 quan = Int64.Parse(txtQuantity.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=DESKTOP-17VA34K;database=Library;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();

                //cmd.CommandText = "insert into  NewBook (bName,bAuthor,bPubl,bPDate,bPrice,bQuan) values (@bname, @bauthor, @publication, @pdate, @price, @quan)";

                // Use SqlParameter to prevent SQL injection and ensure data safety
                // cmd.Parameters.AddWithValue("@bname", bname);
                //cmd.Parameters.AddWithValue("@bauthor", bauthor);
                //cmd.Parameters.AddWithValue("@publication", publication);
                //cmd.Parameters.AddWithValue("@pdate", pdate);
                //cmd.Parameters.AddWithValue("@price", price);
                //cmd.Parameters.AddWithValue("@quan", quan);

                cmd.CommandText = "insert into  NewBook (bName,bAuthor,bPubl,bPDate,bPrice,bQuan) values ('" + bname + "','" + bauthor + "','" + publication + "','" + pdate + "'," + price + "," + quan + ")";
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occured :" + ex.Message);
                }
                con.Close();

                MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBookName.Clear();
                txtAuthor.Clear();
                txtPublication.Clear();
                txtPrice.Clear();
                txtQuantity.Clear();






            }
            else
            {
                MessageBox.Show("Empty TextField not allowed","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will delete ur unsaved data", "Are u Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {


                this.Close();
            }

        }
    }
}
