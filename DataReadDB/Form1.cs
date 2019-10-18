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

namespace DataReadDB
{
    
    public partial class Form1 : Form
    {
        DataTable sTable;
        SqlDataAdapter adapter = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void connect_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            
            SqlCommandBuilder sBuilder;
            SqlConnection cnn;
            
            string query = "";
            
            //string[] output_array = new string[7];
            
            DataSet ds;
            SqlCommand sCommand;
            connetionString = "Data Source=DESKTOP-3GEVC3B\\MSSQLSERVER_16;Initial Catalog=demodb;User ID=sa;Password=abc123";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                MessageBox.Show("Data successfully loaded! ");
                query = "select * from student_detail";
              
                sCommand = new SqlCommand(query, cnn);
                adapter = new SqlDataAdapter(sCommand);
                sBuilder = new SqlCommandBuilder(adapter);
                ds = new DataSet();
                adapter.Fill(ds, "student_details");
                sTable = ds.Tables["student_details"];
                cnn.Close();
                show_all_grid.DataSource = ds.Tables["student_details"];
                show_all_grid.ReadOnly = true;
                save_btn.Enabled = false;
                show_all_grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not load data.Please check your connection! ");
                Console.WriteLine(ex);
            }
        }

        private void show_all_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this row ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                show_all_grid.Rows.RemoveAt(show_all_grid.SelectedRows[0].Index);
                adapter.Update(sTable);
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save this row ?", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                adapter.Update(sTable);
                show_all_grid.ReadOnly = true;
                save_btn.Enabled = false;
                add_new_btn.Enabled = true;
                delete_btn.Enabled = true;

            }
        }
        private void add_new_btn_Click(object sender, EventArgs e)
        {
            show_all_grid.ReadOnly = false;
            save_btn.Enabled = true;
            add_new_btn.Enabled = false;
            delete_btn.Enabled = false;
        }
    }
}
