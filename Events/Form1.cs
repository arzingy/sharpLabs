using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace events
{
    public partial class autonumbers : Form
    {
        public autonumbers()
        {
            InitializeComponent();
        }
        Demonstrator demonstrator;
        Calculator calculator;

        private void autonumbers_Load(object sender, EventArgs e)
        {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(relaxbox, "Введите натуральное число милисекунд (от 100 до 5000)");
        }

        public void Display(object sender, DemonstrateEventArgs e)
        {
            if (tb_numbers.InvokeRequired)
                tb_numbers.Invoke(new Action<string>((s) => tb_numbers.Text = s + tb_numbers.Text), e.Text + Environment.NewLine + Environment.NewLine);
            else tb_numbers.Text = tb_numbers.Text + e.Text + Environment.NewLine + Environment.NewLine;
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(relaxbox.Text);
            tb_numbers.Clear();
            demonstrator = new Demonstrator();
            calculator = new Calculator(a);
            calculator.CalculateEventIsFinished += demonstrator.CalculatingIsFinished;
            demonstrator.StartCalculatingEvent += calculator.Start_calculations;
            demonstrator.StopCalculatingEvent += calculator.Stop_calculations;
            demonstrator.DemonstrateEvent += Display;
            demonstrator.to_Demonstrate();
            bt_start.Enabled = false;
            bt_stop.Enabled = true;
            relaxbox.Enabled = false;
        }

        private void autonumbers_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (demonstrator != null)
                calculator.t.Abort();
        }

        private void bt_stop_Click(object sender, EventArgs e)
        {
            bt_start.Enabled = true;
            bt_stop.Enabled = false;
            relaxbox.Enabled = true;
            demonstrator.Stop_Demontrating();
        }

        private void WrongBox()
        {
            bt_start.Enabled = false;
            ToolTip wrongtip = new ToolTip();
            wrongtip.Show("Введите целое число от 100 до 5000!", relaxbox, 1500);
        }

        private void relaxbox_TextChanged(object sender, EventArgs e)
        {
            int text;
            string str = relaxbox.Text;
            if (str.Length > 4)
            {
                WrongBox();
                return;
            }
            try
            {
                text = Convert.ToInt32(str);
            }
            catch (FormatException)
            {
                text = 0;
            }
            if (text < 100 || text > 5000)
                WrongBox();
            else
            {
                bt_start.Enabled = true;
                lb_relax.ForeColor = Color.Black;
            }
        }
    }
}
