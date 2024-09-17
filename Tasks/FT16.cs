using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace AutoPartsStore.Tasks
{
    public partial class FT16 : Form
    {
        public FT16()
        {
            InitializeComponent();

            DataTask data = new DataTask();
            dataGridView1.Rows.Clear();
            List<Models.FT16> result = data.GetFT16();
            dataGridView1.AutoGenerateColumns = false;
            foreach (var r in result)
            {
                dataGridView1.Rows.Add(r.Client, r.Code, r.Price);
            }

            label1.Text = "Oбщее количество заявок : " + dataGridView1.Rows.Count + " на сумму " + result.Sum(x => x.Price) + ".руб";
        }
    }
}
