using CrmBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUi
{
    public class CashBoxView
    {
        CashDesk cashDesk;
        public Label CashDeskName { get; set; }
        public NumericUpDown Price { get; set; }
        public ProgressBar QueueLength { get; set; }
        public Label LeaveCoustomersCount { get; set; }
        public CashBoxView(CashDesk cashDesk, int number, int x, int y)
        {
            this.cashDesk = cashDesk;
            CashDeskName = new Label();
            Price = new NumericUpDown();
            QueueLength = new ProgressBar();
            LeaveCoustomersCount = new Label();

            CashDeskName.AutoSize = true;
            CashDeskName.Location = new System.Drawing.Point(x, y);
            CashDeskName.Name = "label" + number;
            CashDeskName.Size = new System.Drawing.Size(35, 13);
            CashDeskName.TabIndex = number;
            CashDeskName.Text = cashDesk.ToString();

            Price.Location = new System.Drawing.Point(x + 70, y);
            Price.Name = "numericUpDown" + number;
            Price.Size = new System.Drawing.Size(120, 20);
            Price.TabIndex = number;
            Price.Maximum = 10000000000000;

            QueueLength.Location = new System.Drawing.Point(x + 250, y);
            QueueLength.Maximum = cashDesk.MaxQueueLenght;
            QueueLength.Name = "progressBar" + number;
            QueueLength.Size = new System.Drawing.Size(100, 23);
            QueueLength.TabIndex = number;
            QueueLength.Value = 0;

            LeaveCoustomersCount.AutoSize = true;
            LeaveCoustomersCount.Location = new System.Drawing.Point(x + 400, y);
            LeaveCoustomersCount.Name = "label2" + number;
            LeaveCoustomersCount.Size = new System.Drawing.Size(35, 13);
            LeaveCoustomersCount.TabIndex = number;
            LeaveCoustomersCount.Text = "";

            cashDesk.CheckCloesed += CashDesk_CheckCloesed;

        }

        private void CashDesk_CheckCloesed(object sender, Check e)
        {
            Price.Invoke((Action)delegate
            { 
                Price.Value += e.Price;
                QueueLength.Value = cashDesk.Count;
                LeaveCoustomersCount.Text = cashDesk.ExitCustomer.ToString();
            });
        }
    }
}
