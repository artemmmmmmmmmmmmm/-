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
    public partial class Про_автора4 : Form
    {
        public Про_автора4()
        {
            InitializeComponent();
        }

        private void Про_автора4_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

           

            label1.Text = "Дану програму розробив ";
            label2.Text = "студент 4 курсу бакалавра";
            label3.Text = "Риженко Артем Сергійович!";

        }

        
    }
}
