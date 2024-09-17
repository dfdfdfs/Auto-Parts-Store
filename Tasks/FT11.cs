using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoPartsStore.Tasks
{
    public partial class FT11 : Form
    {
        public FT11()
        {
            InitializeComponent();

            DataTask data = new DataTask();
            DateTime date = new DateTime(2024, 5, 5);
            dataGridView1.Rows.Clear();
            List<Models.FT11> result = data.GetFT11(date);
            dataGridView1.AutoGenerateColumns = false;
            foreach (var r in result)
            {
                dataGridView1.Rows.Add(r.Code, r.Amount, r.Price);
            }
            label1.Text = "Товар релизованный за " + date.ToShortDateString();
        }
    }
}
