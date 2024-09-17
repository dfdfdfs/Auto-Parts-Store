using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoPartsStore.Tasks
{
    public partial class FT1 : Form
    {
        public FT1()
        {
            InitializeComponent();

            DataTask data = new DataTask();
            dataGridView1.Rows.Clear();
            List<Models.FT5> result = data.GetFT1(2);
            dataGridView1.AutoGenerateColumns = false;
            foreach (var r in result)
            {
                dataGridView1.Rows.Add(r.Name);
            }

            label1.Text = "Oбщее количество поставщиков,\n" +
                "поставляющих 'Детали для ТО': " + dataGridView1.Rows.Count;
        }
    }
}
