using CrmBL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUi
{
    public partial class ModelForm : Form
    {
        ShopComputerModel model = new ShopComputerModel();
        List<CashBoxView> cashDeskes;
        public ModelForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cashDeskes = new List<CashBoxView>();
            for (int i = 0; i < model.CashDesks.Count; i++)
            {
                var box = new CashBoxView(model.CashDesks[i], i, 10, 26 * i);
                cashDeskes.Add(box);
                Controls.Add(box.CashDeskName);
                Controls.Add(box.Price);
                Controls.Add(box.QueueLength);
                Controls.Add(box.LeaveCoustomersCount);
            }
            model.Start();
        }

        private void ModelForm_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = model.CustomerSpeed;
            numericUpDown2.Value = model.CustomerSpeed;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            model.CashDeskSpeed = (int)numericUpDown2.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            model.CustomerSpeed = (int)numericUpDown1.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            model.Stop();
            for (int i = 0; i < model.CashDesks.Count; i++)
            {
                Controls.Remove(cashDeskes[i].CashDeskName);
                Controls.Remove(cashDeskes[i].Price);
                Controls.Remove(cashDeskes[i].QueueLength);
                Controls.Remove(cashDeskes[i].LeaveCoustomersCount);
            }
        }

        private void ModelForm_FormClosing(object sender, FormClosingEventArgs e)
        {            
            button2_Click(sender, e);
        }
    }
}
