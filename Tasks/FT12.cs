using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoPartsStore.Tasks
{
    public partial class FT12 : Form
    {
        public FT12()
        {
            InitializeComponent();

            DataTask data = new DataTask();

            DateTime sDate = new DateTime(2024, 5, 1);
            DateTime eDate = new DateTime(2024, 5, 31);

            dataGridView1.Rows.Clear();
            List<Models.FT12> result = data.GetFT12(sDate, eDate);
            dataGridView1.AutoGenerateColumns = false;
            foreach (var r in result)
            {
                dataGridView1.Rows.Add(r.Date.ToShortDateString(), r.Income, r.Expense);
            }

            label1.Text = "Кассовый отчет за период: \n" + sDate.ToShortDateString() + " - " + eDate.ToShortDateString();
        }
    }
}
