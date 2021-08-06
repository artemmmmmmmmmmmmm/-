using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DGVPrinterHelper;
using System.IO;


namespace Інформаційна_система_з_технічного_обліку
{
    public partial class Журнал_обладнання : Form
    {
        private SqlConnection con;
        SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
        //private SqlDataAdapter adapter;


        public Журнал_обладнання()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Постанова_на_облік_обладнання_журнал f = new Постанова_на_облік_обладнання_журнал();
            f.Show();
            //this.Hide();
        }

       

        private void Журнал_обладнання_Load(object sender, EventArgs e)
        {
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
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(this.button1, "Натисніть для оновлення даних в таблиці!");
            toolTip1.SetToolTip(this.button2, "Натисніть для друку даних з журналу!");
            toolTip1.SetToolTip(this.button4, "Натисніть для постановки на облік техніки!");
                   }

        private void button1_Click(object sender, EventArgs e)
        {
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

        private void button2_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Звіт";
            printer.SubTitle = String.Format("Date:{0}",DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "foxline";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);
            
        }
        

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "Output.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dataGridView1.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[dataGridView1.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; i < dataGridView1.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }

                            File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string q = "SELECT        журнал_обладнання.idПереміщення, журнал_обладнання.Дата_оренди, техніка.Ідентифікаційний_номер_техніки, техніка.Назва_техніки, техніка.Модель, кафедри.Назва_Кафедри, факультет.Назва_Факультету, джерело.Назва_джерела, матеріально_відповідальний.ПІБ FROM джерело INNER JOIN журнал_обладнання ON джерело.idДжерела = журнал_обладнання.idДжерела INNER JOIN матеріально_відповідальний ON журнал_обладнання.idМатеріально_відповідального = матеріально_відповідальний.idматеріально_відповідального INNER JOIN техніка ON журнал_обладнання.Ідентифікаційний_номер_техніки = техніка.ідентифікаційний_номер_техніки INNER JOIN кафедри ON матеріально_відповідальний.idКафедри = кафедри.idкафедри INNER JOIN факультет ON кафедри.idФакультет = факультет.idфакультет where журнал_обладнання.Дата_оренди = '" + textBox1.Text + "'";
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string q = "SELECT        журнал_обладнання.idПереміщення, журнал_обладнання.Дата_оренди, техніка.Ідентифікаційний_номер_техніки, техніка.Назва_техніки, техніка.Модель, кафедри.Назва_Кафедри, факультет.Назва_Факультету, джерело.Назва_джерела, матеріально_відповідальний.ПІБ FROM джерело INNER JOIN журнал_обладнання ON джерело.idДжерела = журнал_обладнання.idДжерела INNER JOIN матеріально_відповідальний ON журнал_обладнання.idМатеріально_відповідального = матеріально_відповідальний.idматеріально_відповідального INNER JOIN техніка ON журнал_обладнання.Ідентифікаційний_номер_техніки = техніка.ідентифікаційний_номер_техніки INNER JOIN кафедри ON матеріально_відповідальний.idКафедри = кафедри.idкафедри INNER JOIN факультет ON кафедри.idФакультет = факультет.idфакультет where журнал_обладнання.idПереміщення = '" + textBox2.Text + "'";
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

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string q = "SELECT        журнал_обладнання.idПереміщення, журнал_обладнання.Дата_оренди, техніка.Ідентифікаційний_номер_техніки, техніка.Назва_техніки, техніка.Модель, кафедри.Назва_Кафедри, факультет.Назва_Факультету, джерело.Назва_джерела, матеріально_відповідальний.ПІБ FROM джерело INNER JOIN журнал_обладнання ON джерело.idДжерела = журнал_обладнання.idДжерела INNER JOIN матеріально_відповідальний ON журнал_обладнання.idМатеріально_відповідального = матеріально_відповідальний.idматеріально_відповідального INNER JOIN техніка ON журнал_обладнання.Ідентифікаційний_номер_техніки = техніка.ідентифікаційний_номер_техніки INNER JOIN кафедри ON матеріально_відповідальний.idКафедри = кафедри.idкафедри INNER JOIN факультет ON кафедри.idФакультет = факультет.idфакультет where техніка.Назва_техніки like '" + textBox3.Text + "%'";
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

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string q = "SELECT        журнал_обладнання.idПереміщення, журнал_обладнання.Дата_оренди, техніка.Ідентифікаційний_номер_техніки, техніка.Назва_техніки, техніка.Модель, кафедри.Назва_Кафедри, факультет.Назва_Факультету, джерело.Назва_джерела, матеріально_відповідальний.ПІБ FROM джерело INNER JOIN журнал_обладнання ON джерело.idДжерела = журнал_обладнання.idДжерела INNER JOIN матеріально_відповідальний ON журнал_обладнання.idМатеріально_відповідального = матеріально_відповідальний.idматеріально_відповідального INNER JOIN техніка ON журнал_обладнання.Ідентифікаційний_номер_техніки = техніка.ідентифікаційний_номер_техніки INNER JOIN кафедри ON матеріально_відповідальний.idКафедри = кафедри.idкафедри INNER JOIN факультет ON кафедри.idФакультет = факультет.idфакультет where кафедри.Назва_Кафедри like '" + textBox4.Text + "%'";
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

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string q = "SELECT        журнал_обладнання.idПереміщення, журнал_обладнання.Дата_оренди, техніка.Ідентифікаційний_номер_техніки, техніка.Назва_техніки, техніка.Модель, кафедри.Назва_Кафедри, факультет.Назва_Факультету, джерело.Назва_джерела, матеріально_відповідальний.ПІБ FROM джерело INNER JOIN журнал_обладнання ON джерело.idДжерела = журнал_обладнання.idДжерела INNER JOIN матеріально_відповідальний ON журнал_обладнання.idМатеріально_відповідального = матеріально_відповідальний.idматеріально_відповідального INNER JOIN техніка ON журнал_обладнання.Ідентифікаційний_номер_техніки = техніка.ідентифікаційний_номер_техніки INNER JOIN кафедри ON матеріально_відповідальний.idКафедри = кафедри.idкафедри INNER JOIN факультет ON кафедри.idФакультет = факультет.idфакультет where факультет.Назва_Факультету like '" + textBox5.Text + "%'";
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

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string q = "SELECT        журнал_обладнання.idПереміщення, журнал_обладнання.Дата_оренди, техніка.Ідентифікаційний_номер_техніки, техніка.Назва_техніки, техніка.Модель, кафедри.Назва_Кафедри, факультет.Назва_Факультету, джерело.Назва_джерела, матеріально_відповідальний.ПІБ FROM джерело INNER JOIN журнал_обладнання ON джерело.idДжерела = журнал_обладнання.idДжерела INNER JOIN матеріально_відповідальний ON журнал_обладнання.idМатеріально_відповідального = матеріально_відповідальний.idматеріально_відповідального INNER JOIN техніка ON журнал_обладнання.Ідентифікаційний_номер_техніки = техніка.ідентифікаційний_номер_техніки INNER JOIN кафедри ON матеріально_відповідальний.idКафедри = кафедри.idкафедри INNER JOIN факультет ON кафедри.idФакультет = факультет.idфакультет where джерело.Назва_джерела like '" + textBox6.Text + "%'";
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

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string q = "SELECT        журнал_обладнання.idПереміщення, журнал_обладнання.Дата_оренди, техніка.Ідентифікаційний_номер_техніки, техніка.Назва_техніки, техніка.Модель, кафедри.Назва_Кафедри, факультет.Назва_Факультету, джерело.Назва_джерела, матеріально_відповідальний.ПІБ FROM джерело INNER JOIN журнал_обладнання ON джерело.idДжерела = журнал_обладнання.idДжерела INNER JOIN матеріально_відповідальний ON журнал_обладнання.idМатеріально_відповідального = матеріально_відповідальний.idматеріально_відповідального INNER JOIN техніка ON журнал_обладнання.Ідентифікаційний_номер_техніки = техніка.ідентифікаційний_номер_техніки INNER JOIN кафедри ON матеріально_відповідальний.idКафедри = кафедри.idкафедри INNER JOIN факультет ON кафедри.idФакультет = факультет.idфакультет where техніка.Ідентифікаційний_номер_техніки = '" + textBox7.Text + "'";
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

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string q = "SELECT        журнал_обладнання.idПереміщення, журнал_обладнання.Дата_оренди, техніка.Ідентифікаційний_номер_техніки, техніка.Назва_техніки, техніка.Модель, кафедри.Назва_Кафедри, факультет.Назва_Факультету, джерело.Назва_джерела, матеріально_відповідальний.ПІБ FROM джерело INNER JOIN журнал_обладнання ON джерело.idДжерела = журнал_обладнання.idДжерела INNER JOIN матеріально_відповідальний ON журнал_обладнання.idМатеріально_відповідального = матеріально_відповідальний.idматеріально_відповідального INNER JOIN техніка ON журнал_обладнання.Ідентифікаційний_номер_техніки = техніка.ідентифікаційний_номер_техніки INNER JOIN кафедри ON матеріально_відповідальний.idКафедри = кафедри.idкафедри INNER JOIN факультет ON кафедри.idФакультет = факультет.idфакультет where  матеріально_відповідальний.ПІБ like '" + textBox8.Text + "%'";
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text))
            {
                string Delstr = "DELETE FROM журнал_обладнання WHERE idПереміщення = '" + textBox9.Text + "'";
                SqlCommand com = new SqlCommand(Delstr, con);
                SqlDataReader reader = com.ExecuteReader();
                reader.Close();
                MessageBox.Show("Запис видалено");

            }
            else
            {
                MessageBox.Show("Введіть № Запису");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrWhiteSpace(textBox11.Text))
            {
                string Delstr = "update техніка set Коментар =  '" + textBox10.Text + "' WHERE Ідентифікаційний_номер_техніки = '" + textBox11.Text + "'";
                SqlCommand com = new SqlCommand(Delstr, con);
                SqlDataReader reader = com.ExecuteReader();
                reader.Close();
                MessageBox.Show("Коментар додано");

            }
            else
            {
                MessageBox.Show("Введіть id Техніки");
            }
        }
    }
}
