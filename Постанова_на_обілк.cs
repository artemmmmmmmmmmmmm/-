using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Інформаційна_система_з_технічного_обліку
{
    public partial class Постанова_на_обілк : Form
    {
        private SqlConnection con;
        SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
        public Постанова_на_обілк()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       

        private void Постанова_на_обілк_Load(object sender, EventArgs e)
        {


            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = @".\SQLEXPRESS";
            connectionStringBuilder.InitialCatalog = "БД_інвентаризація";
            connectionStringBuilder.UserID = "artem";
            connectionStringBuilder.Password = "12345";
            con = new SqlConnection(connectionStringBuilder.ConnectionString);
            con.Open();

            dataGridView1.Rows.Clear();
            string q = "SELECT    техніка.*,типи_техніки.назва_типу from техніка,типи_техніки where техніка.idТипу_техніки = типи_техніки.idТипу_техніки";
            SqlCommand com = new SqlCommand(q, con);
            SqlDataReader reader = com.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4]);
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


            string q3 = "SELECT Назва_типу from типи_техніки";
            SqlCommand com3 = new SqlCommand(q3, con);
            SqlDataReader reader3 = com3.ExecuteReader();

            try
            {
                while (reader3.Read())
                {
                    for (int i = 0; i < reader3.FieldCount; i++)
                    {
                        comboBox1.Items.Add(reader3[i]);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader3.Close();
            }
            ToolTip toolTip1 = new ToolTip();
     
            toolTip1.SetToolTip(this.textBox1, "Введіть ідентифікаційний номер техінки");
            toolTip1.SetToolTip(this.textBox2, "Введіть назву техінки");
            toolTip1.SetToolTip(this.textBox3, "Введіть модель техінки");
            toolTip1.SetToolTip(this.textBox4, "Введіть id типу техніки");
            toolTip1.SetToolTip(this.button1, "Натисніть для створення нового запису техніки");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string q = "Insert into техніка(Ідентифікаційний_номер_техніки,Назва_техніки,Модель,idТипу_техніки)" +
                            "values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "');";
                SqlCommand com = new SqlCommand(q, con);
                com.ExecuteNonQuery();

                MessageBox.Show("Запис додано");

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string q = "SELECT    техніка.*,типи_техніки.назва_типу from техніка,типи_техніки where техніка.idТипу_техніки = типи_техніки.idТипу_техніки";
            SqlCommand com = new SqlCommand(q, con);
            SqlDataReader reader = com.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4]);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string q3 = "SELECT idТипу_техніки from типи_техніки where Назва_типу =  '" + comboBox1.Text + "' GROUP BY idТипу_техніки";
            SqlCommand com3 = new SqlCommand(q3, con);
            SqlDataReader reader3 = com3.ExecuteReader();

            try
            {
                while (reader3.Read())
                {
                    for (int i = 0; i < reader3.FieldCount; i++)
                    {
                        textBox4.Clear();
                        textBox4.Text = reader3[i].ToString();
                        //comboBox4.Items.Add(reader3[i]);

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader3.Close();
            }
        }
    }
}
