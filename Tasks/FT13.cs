using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoPartsStore.Tasks
{
    public partial class FT13 : Form
    {
        public FT13()
        {
            InitializeComponent();

            DataTask data = new DataTask();

            dataGridView1.Rows.Clear();
            List<Models.FT13> result = data.GetFT13();
            dataGridView1.AutoGenerateColumns = false;
            foreach (var r in result)
            {
                dataGridView1.Rows.Add(r.Code, r.Price, r.StockCell, r.Amount, r.TotalPrice);
            }
        }
    }
}
