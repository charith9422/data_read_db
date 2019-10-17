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
            SqlDataAdapter adapter = null;
            SqlConnection cnn;
            string query , Output = "";
            SqlCommand cmd;
            string[] output_array = new string[7];
            SqlDataReader dataReader;
            DataSet ds = new DataSet();
            connetionString = "Data Source=DESKTOP-3GEVC3B\\MSSQLSERVER_16;Initial Catalog=demodb;User ID=sa;Password=abc123";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                MessageBox.Show("Connection Open ! ");
                query = "select * from student_detail";
                cmd = new SqlCommand(query, cnn);
                dataReader = cmd.ExecuteReader();
                //CreateGridColumnNames();
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                show_all_grid.DataSource = dt;
                
                cnn.Close();
                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
                Console.WriteLine(ex);
            }
        }
        
    }
}
