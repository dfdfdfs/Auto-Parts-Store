using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoPartsStore.Tasks
{
    public partial class FT9 : Form
    {
        public FT9()
        {
            InitializeComponent();

            DataTask data = new DataTask();
            dataGridView1.Rows.Clear();
            List<Models.FT9> result = data.GetFT9();
            int countAll = data.GetCountSparePartStock();
            dataGridView1.AutoGenerateColumns = false;
            foreach (var r in result)
            {
                dataGridView1.Rows.Add(r.Code);
            }
            int countGrid = dataGridView1.Rows.Count;
            label1.Text = "Oбщее количество непроданного товара на складе : " + countGrid + ".\n" +
                "Его объем от общего товара: " + countAll / countGrid * 100 + "%";
        }
    }
}
