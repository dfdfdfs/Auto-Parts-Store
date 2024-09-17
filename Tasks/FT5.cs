using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoPartsStore.Tasks
{
    public partial class FT5 : Form
    {
        public FT5()
        {
            InitializeComponent();

            DataTask data = new DataTask();
            dataGridView1.Rows.Clear();
            List<Models.FT5> result = data.GetFT5();
            dataGridView1.AutoGenerateColumns = false;
            foreach (var r in result)
            {
                dataGridView1.Rows.Add(r.Name, r.Count);
            }

            dataGridView2.Rows.Clear();
            List<Models.FT5> result2 = data.GetFT51();
            dataGridView2.AutoGenerateColumns = false;
            foreach (var r in result2)
            {
                dataGridView2.Rows.Add(r.Name);
            }
        }
    }
}
