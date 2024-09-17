using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoPartsStore.Tasks
{
    public partial class FT4 : Form
    {
        public FT4()
        {
            InitializeComponent();

            DataTask data = new DataTask();

            dataGridView1.Rows.Clear();
            List<Models.FT4> result = data.GetFT4();
            dataGridView1.AutoGenerateColumns = false;
            foreach (var r in result)
            {
                dataGridView1.Rows.Add(r.Name, r.Amount, r.StockCell);
            }
        }
    }
}
