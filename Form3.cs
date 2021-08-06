using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using DGVPrinterHelper;

namespace Інформаційна_система_з_технічного_обліку
{
    public partial class Form3 : Form
    {
        private SqlConnection con;
        SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
        public Form3()
        {
            InitializeComponent();
        }

        private void проАвтораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Про_автора f = new Про_автора();
            f.Show();
            //this.Hide();
        }

        private void переглядТехнікиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Перегляд_техніки_Зав_кафедри f = new Перегляд_техніки_Зав_кафедри();
            f.Show();
            //this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
           
            toolTip1.SetToolTip(this.button3, "Натисніть для повернення в меню авторизації");

            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = @".\SQLEXPRESS";
            connectionStringBuilder.InitialCatalog = "БД_інвентаризація";
            connectionStringBuilder.UserID = "artem";
            connectionStringBuilder.Password = "12345";
            con = new SqlConnection(connectionStringBuilder.ConnectionString);
            con.Open();

            dataGridView1.Rows.Clear();
            string q = "SELECT        журнал_обладнання.idПереміщення, журнал_обладнання.Дата_оренди, техніка.Ідентифікаційний_номер_техніки, техніка.Назва_техніки, техніка.Модель, кафедри.Назва_Кафедри, факультет.Назва_Факультету, джерело.Назва_джерела, матеріально_відповідальний.ПІБ FROM джерело INNER JOIN журнал_обладнання ON джерело.idДжерела = журнал_обладнання.idДжерела INNER JOIN матеріально_відповідальний ON журнал_обладнання.idМатеріально_відповідального = матеріально_відповідальний.idматеріально_відповідального INNER JOIN техніка ON журнал_обладнання.Ідентифікаційний_номер_техніки = техніка.ідентифікаційний_номер_техніки INNER JOIN кафедри ON матеріально_відповідальний.idКафедри = кафедри.idкафедри INNER JOIN факультет ON кафедри.idФакультет = факультет.idфакультет";
            SqlCommand com = new SqlCommand(q, con);
            SqlDataReader reader = com.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7], reader[8]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Звіт";
            printer.SubTitle = String.Format("Date:{0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "foxline";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);
        }
    }
}
