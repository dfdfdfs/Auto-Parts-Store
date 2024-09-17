using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoPartsStore.Tasks
{
    public partial class FT14 : Form
    {
        public FT14()
        {
            InitializeComponent();

            DataTask data = new DataTask();
            dataGridView1.Rows.Clear();
            List<Models.FT14> result = data.GetFT14();
            dataGridView1.AutoGenerateColumns = false;
            foreach (var r in result)
            {
                dataGridView1.Rows.Add(r.Code, r.DateSupply.ToShortDateString(), r.DateSale.ToShortDateString(), r.Day);
            }
        }
    }
}
