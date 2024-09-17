using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoPartsStore.Tasks
{
    public partial class FT15 : Form
    {
        public FT15()
        {
            InitializeComponent();

            DataTask data = new DataTask();
            dataGridView1.Rows.Clear();
            List<Models.FT15> result = data.GetFT15();
            dataGridView1.AutoGenerateColumns = false;
            foreach (var r in result)
            {
                dataGridView1.Rows.Add(r.Name, r.Cell, r.Count);
            }
        }
    }
}
