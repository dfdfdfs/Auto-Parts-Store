using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoPartsStore.Tasks;

namespace AutoPartsStore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrands_Click(object sender, EventArgs e)
        {
            FBrands fBrands = new FBrands();
            fBrands.Show();
        }

        private void btnModels_Click(object sender, EventArgs e)
        {
            FModels fModels = new FModels();
            fModels.Show();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            FCategory fCategory = new FCategory();
            fCategory.Show();
        }

        private void btnManuf_Click(object sender, EventArgs e)
        {
            FManuf fManuf = new FManuf();
            fManuf.Show();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            FStock fStock = new FStock();
            fStock.Show();
        }

        private void btnCellsStock_Click(object sender, EventArgs e)
        {
            FCellsStocks fCellsStocks = new FCellsStocks();
            fCellsStocks.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            FSpareParts fSpareParts = new FSpareParts();
            fSpareParts.Show();
        }

        private void btnSupplies_Click(object sender, EventArgs e)
        {
            FSupplies fSupplies = new FSupplies();
            fSupplies.Show();
        }

        private void btnSparePartStock_Click(object sender, EventArgs e)
        {
            FSparePartStock fSparePartStock = new FSparePartStock();
            fSparePartStock.Show();
        }

        private void btnDefective_Click(object sender, EventArgs e)
        {
            FDefective fDefective = new FDefective();
            fDefective.Show();
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            FClients fClients = new FClients();
            fClients.Show();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            FSales fSales = new FSales();
            fSales.Show();
        }

        private void btnApplications_Click(object sender, EventArgs e)
        {
            FApplications fApplications = new FApplications();
            fApplications.Show();
        }

        private void btnFT1_Click(object sender, EventArgs e)
        {
            FT1 form = new FT1();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FT2 form = new FT2();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FT3 form = new FT3();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FT4 form = new FT4();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FT5 form = new FT5();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTask data = new DataTask();
            Models.FT5 result = data.GetFT6(1, 5);
            MessageBox.Show(
                    "Среднее число продаж на месяц МАЙ: " + result.Name + " объем " + result.Count,
                    "Результат запроса",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataTask data = new DataTask();
            decimal result = data.GetFT8();
            MessageBox.Show(
                    "Накладные расходы в процентах от\n" +
                    "объема продаж: " + Math.Round(result, 2) + "%",
                    "Результат запроса",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataTask data = new DataTask();
            Models.FT7 result = data.GetFT7();
            MessageBox.Show(
                    "Доля товара Bremi поставщика в процентах " + result.Percent + ", деньгах " + result.Price +
                    ", единицах " + result.Ed + "/n" + "от всего оборота магазина за указанный период",
                    "Результат запроса",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FT9 form = new FT9();
            form.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FT10 form = new FT10();
            form.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FT11 form = new FT11();
            form.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FT12 form = new FT12();
            form.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            FT13 form = new FT13();
            form.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            FT15 form = new FT15();
            form.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            FT16 form = new FT16();
            form.Show();
        }


        private void button13_Click(object sender, EventArgs e)
        {
            FT14 form = new FT14();
            form.Show();
        }
    }
}
