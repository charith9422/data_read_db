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
                CreateGridColumnNames();
                while (dataReader.Read()) {
                   

                    //Output = Output + dataReader.GetValue(0) + " " + dataReader.GetValue(1) + " " + dataReader.GetValue(2) + " " + dataReader.GetValue(3) + " " + dataReader.GetValue(4) + " " + dataReader.GetValue(5) + " " + dataReader.GetValue(6) + "\n";

                    Output = dataReader.GetValue(1)+" "+dataReader.GetValue(2) + " " + dataReader.GetValue(3) + " " + dataReader.GetValue(4) + " " + dataReader.GetValue(5) + " " + dataReader.GetValue(6) + " ";
                    CreateGridColumnNames(dataReader.GetValue(0).ToString(), dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString(), dataReader.GetValue(3).ToString(), dataReader.GetValue(4).ToString(), dataReader.GetValue(5).ToString(), dataReader.GetValue(6).ToString());
                    Console.WriteLine(Output);
                }
                cnn.Close();
                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
                Console.WriteLine(ex);
            }
        }
        public void CreateGridColumnNames()
        {

            show_all_grid.Columns.Add("col1", "Student Reg No");
            show_all_grid.Columns.Add("col2", "Name");
            show_all_grid.Columns.Add("col3", "Age");
            show_all_grid.Columns.Add("col4", "District");
            show_all_grid.Columns.Add("col5", "Province");
            show_all_grid.Columns.Add("col6", "Course Code");
            show_all_grid.Columns.Add("col7", "Course");
        }
        public void CreateGridColumnNames(string reg_no, string name, string age, string district, string province, string course_code, string course)
        {

            show_all_grid.Rows[0].Cells[0].Value = reg_no;
            show_all_grid.Rows[0].Cells[1].Value = name;
            show_all_grid.Rows[0].Cells[2].Value = age;
            show_all_grid.Rows[0].Cells[3].Value = district;
            show_all_grid.Rows[0].Cells[4].Value = province;
            show_all_grid.Rows[0].Cells[5].Value = course_code;
            show_all_grid.Rows[0].Cells[6].Value = course;

            

            

            /*show_all_grid.Columns[1].Name = name;
            show_all_grid.Columns[2].Name = age;
            show_all_grid.Columns[3].Name = district;
            show_all_grid.Columns[4].Name = province;
            show_all_grid.Columns[5].Name = course_code;
            show_all_grid.Columns[6].Name = course;
            */

        }
    }
}
