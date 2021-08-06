using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Інформаційна_система_з_технічного_обліку
{
    public partial class Постанова_на_облік_обладнання_журнал : Form
    {
        SqlDataAdapter adap;
    
        DataSet ds;
        private SqlConnection con;
        SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
        public Постанова_на_облік_обладнання_журнал()
        {
            InitializeComponent();
        }
      


        private void Постанова_на_облік_обладнання_журнал_Load(object sender, EventArgs e)
        {
            textBox1.Text = monthCalendar1.SelectionStart.ToShortDateString();
            

            con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-SMDOH9I\SQLEXPRESS;Initial Catalog=БД_інвентаризація;Persist Security Info=True;User ID=artem;Password=12345";
            con.Open();


            //для матеріально_відповідального
            string q1 = "SELECT ПІБ from матеріально_відповідальний";
            SqlCommand com1 = new SqlCommand(q1, con);
            SqlDataReader reader1 = com1.ExecuteReader();
            try
            {
                while (reader1.Read())
                {
                    for (int i = 0; i < reader1.FieldCount; i++)
                    {
                        comboBox1.Items.Add(reader1[i]);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader1.Close();
            }

            //для типу операцій
            string q2 = "SELECT Назва_типу_операції from тип_операції";
            SqlCommand com2 = new SqlCommand(q2, con);
            SqlDataReader reader2 = com2.ExecuteReader();

            try
            {
                while (reader2.Read())
                {
                    for (int i = 0; i < reader2.FieldCount; i++)
                    {
                        comboBox2.Items.Add(reader2[i]);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader2.Close();
            }
            //для техніки
            string q3 = "SELECT Ідентифікаційний_номер_техніки from техніка";
            SqlCommand com3 = new SqlCommand(q3, con);
            SqlDataReader reader3 = com3.ExecuteReader();

            try
            {
                while (reader3.Read())
                {
                    for (int i = 0; i < reader3.FieldCount; i++)
                    {
                        comboBox3.Items.Add(reader3[i]);
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

            //для джерела
            string q4 = "SELECT Назва_джерела from Джерело";
            SqlCommand com4 = new SqlCommand(q4, con);
            SqlDataReader reader4 = com4.ExecuteReader();

            try
            {
                while (reader4.Read())
                {
                    for (int i = 0; i < reader4.FieldCount; i++)
                    {
                        comboBox4.Items.Add(reader4[i]);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader4.Close();
            }



            //try
            //{
               
            //    adap = new SqlDataAdapter("SELECT idТипу_операції,Назва_типу_операції FROM тип_операції", con);
            //    ds = new System.Data.DataSet();
            //    adap.Fill(ds);
            //    dataGridView2.DataSource = ds.Tables[0];
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


            try
            {
                
                adap = new SqlDataAdapter("SELECT Ідентифікаційний_номер_техніки,Назва_техніки,Модель FROM техніка", con);
                ds = new System.Data.DataSet();
                adap.Fill(ds);
                dataGridView3.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //try
            //{

            //    adap = new SqlDataAdapter("SELECT idМатеріально_відповідального,ПІБ FROM матеріально_відповідальний", con);
            //    ds = new System.Data.DataSet();
            //    adap.Fill(ds);
            //    dataGridView1.DataSource = ds.Tables[0];
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            //try
            //{
               
            //    adap = new SqlDataAdapter("SELECT IdДжерела,Назва_джерела FROM Джерело", con);
            //    ds = new System.Data.DataSet();
            //    adap.Fill(ds);
            //    dataGridView4.DataSource = ds.Tables[0];
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            ToolTip toolTip1 = new ToolTip();
            
            toolTip1.SetToolTip(this.textBox1, "Введіть дату оренди наприклад <<25.08.2021>>!");
            //toolTip1.SetToolTip(this.textBox3, "Введіть Прізвище ім'я та по-батькові !");
            //toolTip1.SetToolTip(this.textBox2, "Введіть ідентифікаційний номер техінки!");
            toolTip1.SetToolTip(this.button1, "Натисніть для постановки на облік техніки !");
           
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string q = "Insert into журнал_обладнання(Дата_оренди,idМатеріально_відповідального,idТипу_операції,Ідентифікаційний_номер_техніки,idДжерела)" +
            //                "values('" + textBox1.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "');";
            //    SqlCommand com = new SqlCommand(q, con);
            //    com.ExecuteNonQuery();

            //    MessageBox.Show("Запис додано");

            //}
            //catch (Exception ex) { MessageBox.Show(ex.ToString()); }



            try
            {
                string q = "Insert into журнал_обладнання(Дата_оренди,idМатеріально_відповідального,idТипу_операції,Ідентифікаційний_номер_техніки,idДжерела)" +
                            "values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox3.Text + "','" + textBox4.Text + "');";
                SqlCommand com = new SqlCommand(q, con);
                com.ExecuteNonQuery();

                MessageBox.Show("Запис додано");

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string q3 = "SELECT idМатеріально_відповідального from матеріально_відповідальний where ПІБ =  '" + comboBox1.Text + "' GROUP BY idМатеріально_відповідального";
            SqlCommand com3 = new SqlCommand(q3, con);
            SqlDataReader reader3 = com3.ExecuteReader();

            try
            {
                while (reader3.Read())
                {
                    for (int i = 0; i < reader3.FieldCount; i++)
                    {
                        textBox2.Clear();
                        textBox2.Text = reader3[i].ToString();
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string q3 = "SELECT idТипу_операції from тип_операції where Назва_типу_операції =  '" + comboBox2.Text + "' GROUP BY idТипу_операції";
            SqlCommand com3 = new SqlCommand(q3, con);
            SqlDataReader reader3 = com3.ExecuteReader();

            try
            {
                while (reader3.Read())
                {
                    for (int i = 0; i < reader3.FieldCount; i++)
                    {
                        textBox3.Clear();
                        textBox3.Text = reader3[i].ToString();
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

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string q3 = "SELECT IdДжерела from Джерело where Назва_джерела =  '" + comboBox4.Text + "' GROUP BY IdДжерела";
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
