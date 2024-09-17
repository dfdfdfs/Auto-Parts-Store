using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoPartsStore.Tasks
{
    public partial class FT10 : Form
    {
        public FT10()
        {
            InitializeComponent();

            DataTask data = new DataTask();
            dataGridView1.Rows.Clear();
            List<Models.FT10> result = data.GetFT10();
            dataGridView1.AutoGenerateColumns = false;
            foreach (var r in result)
            {
                dataGridView1.Rows.Add(r.Code, r.Manuf);
            }

            label1.Text = "Oбщее количество бракованного товара: " + dataGridView1.Rows.Count;
        }
    }
}
