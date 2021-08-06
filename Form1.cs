using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Інформаційна_система_з_технічного_обліку
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {



          
            if (textBox1.Text == "zv" && textBox2.Text == "12345")
            {
                Form3 f = new Form3();
                f.Show();
                this.Hide();
            }
            else
            {
                if (textBox1.Text == "admin" && textBox2.Text == "12345")
                {
                    Form2 f = new Form2();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    if (textBox1.Text != "admin" || textBox2.Text != "12345")
                    {

                        MessageBox.Show("Не правильний логін або пароль!!!");
                    }
                }
            }

            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(this.textBox1, "Введіть логін!");
            toolTip1.SetToolTip(this.textBox2, "Введіть пароль!");
            toolTip1.SetToolTip(this.button1, "Натисніть для входу ");
            toolTip1.SetToolTip(this.button2, "Вихід");
            
        }
    }
}
