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
    public partial class ReturnBooks : Form
    {
        public ReturnBooks()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-17VA34K; database = Library; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from IRBook2 where std_enroll='" + txtEnterEnroll.Text + "' and book_return_date IS NULL";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count!=0)
            {
                DataGridView.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Invalid ID or No Book Issued", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void ReturnBooks_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
            txtEnterEnroll.Clear();

        }

        String bname;
        String bdate;
        Int64 rowid;

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel3.Visible = true;

            if (DataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value !=null)
            {
                rowid = Int64.Parse(DataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                bname = DataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
                bdate = DataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();

            }
            txtBookName.Text = bname;
            txtBookIssueDate.Text = bdate;


        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-17VA34K; database = Library; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            con.Open();
            cmd.CommandText="update IRBook2 set book_return_date='"+dateTimePicker1.Text+"' where std_enroll='"+txtEnterEnroll.Text+"' and id="+rowid+"";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Return Successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReturnBooks_Load(this, null);


        }

        private void txtEnterEnroll_TextChanged(object sender, EventArgs e)
        {
            if(txtEnterEnroll.Text==" ")
            {
                panel3.Visible = false;
                DataGridView.DataSource = null;

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnterEnroll.Clear();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;

        }
    }
}


