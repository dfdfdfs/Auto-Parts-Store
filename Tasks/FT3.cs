using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoPartsStore.Tasks
{
    public partial class FT3 : Form
    {
        private readonly DataTask data = new DataTask();

        public FT3()
        {
            InitializeComponent();

            DateTime sDate = new DateTime(2024, 5, 1);
            DateTime eDate = new DateTime(2024, 5, 31);

            dataGridView1.Rows.Clear();
            List<Models.FT3> result = data.GetFT3(2, sDate, eDate);
            dataGridView1.AutoGenerateColumns = false;
            foreach (var r in result)
            {
                dataGridView1.Rows.Add(r.FIO);
            }

            label1.Text = "Всего покупателей: " + dataGridView1.Rows.Count;
        }
    }
}
