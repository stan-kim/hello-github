using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRCodePrint
{
    public partial class PopupMSG : Form
    {
        Form1 RefForm1;
        public PopupMSG(Form1 ReferenceForm)
        {
            InitializeComponent();
            this.RefForm1 = ReferenceForm;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        public void error_MSG_Display(string msg)
        {
            lb_ERROR_MSG.Text = msg;
        }
    }
}
