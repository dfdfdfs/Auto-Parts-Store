using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoPartsStore.Tasks
{
    public partial class FT2 : Form
    {
        private readonly DataTask data = new DataTask();

        public FT2()
        {
            InitializeComponent();

            dataGridView1.Rows.Clear();
            List<Models.FT2> result = data.GetFT2(2);
            dataGridView1.AutoGenerateColumns = false;
            foreach (var r in result)
            {
                dataGridView1.Rows.Add(r.Date.ToShortDateString(), r.Price, r.Manuf);
            }
        }
    }
}
