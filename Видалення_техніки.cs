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
   
    public partial class Видалення_техніки : Form
    {
       
        SqlConnection con;
        SqlDataAdapter adap;
        DataSet ds;
        SqlCommandBuilder comdl;
        SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
        public Видалення_техніки()
        {
            InitializeComponent();
           

        }

        public void Clear(DataGridView dataGridView)
        {
            dataGridView1.Columns.Clear();

        }


        private void Видалення_техніки_Load(object sender, EventArgs e)
        {

            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = @".\SQLEXPRESS";
            connectionStringBuilder.InitialCatalog = "БД_інвентаризація";
            connectionStringBuilder.UserID = "artem";
            connectionStringBuilder.Password = "12345";
            con = new SqlConnection(connectionStringBuilder.ConnectionString);
            con.Open();

            try
            {
                Clear(dataGridView1);
                adap = new SqlDataAdapter("select * from техніка", con);
                ds = new System.Data.DataSet();
                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(this.textBox1, "Введіть Id техніки");
            toolTip1.SetToolTip(this.button1, "Натисніть для пергляду техніки");
            toolTip1.SetToolTip(this.button2, "Натисніть для Видалення техніки");
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                string Delstr = "DELETE FROM техніка WHERE Ідентифікаційний_номер_техніки = '" + textBox1.Text + "'";
                SqlCommand com = new SqlCommand(Delstr, con);
                SqlDataReader reader = com.ExecuteReader();
                reader.Close();
                MessageBox.Show("Запис видалено\n", "Оновлено", MessageBoxButtons.OK, MessageBoxIcon.Information);
               

            }
            else
            {
                MessageBox.Show("Введіть id техніки\n", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Clear(dataGridView1);
                adap = new SqlDataAdapter("select * from техніка", con);
                ds = new System.Data.DataSet();
                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




            //dataGridView1.Rows.Clear();
            //string q = "SELECT    техніка.*,типи_техніки.назва_типу from техніка,типи_техніки where техніка.idТипу_техніки = типи_техніки.idТипу_техніки";
            //SqlCommand com = new SqlCommand(q, con);
            //SqlDataReader reader = com.ExecuteReader();
            //try
            //{
            //    while (reader.Read())
            //    {
            //        dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4]);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    reader.Close();
            //}
        }
    }
}
