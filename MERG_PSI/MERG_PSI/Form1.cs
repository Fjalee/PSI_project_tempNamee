﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MERG_PSI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // webBrowser2.Navigate("http://maps.google.com/maps?q=Lietuva%22");
            //  webBrowser2.ScriptErrorsSuppressed = true;
            var tekstas = "";
            var Data = (new Data()).SampleData;
            foreach (var eilute in Data)
            {
                tekstas = tekstas + eilute;
            }
            richTextBox1.Text = tekstas;
        }

        #region TextBox Input 
        private void municipality_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ch = e.KeyChar;
            if (!char.IsControl(ch) && !char.IsLetter(ch) && !char.IsWhiteSpace(ch) && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void street_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ch = e.KeyChar;
            if (!char.IsControl(ch) && !char.IsLetter(ch) && !char.IsWhiteSpace(ch) && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void priceFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void priceTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void areaFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void areaTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion
        #region Prompt text

        private void priceFrom_Enter(object sender, EventArgs e)
        {
            if (priceFrom.Text == "Nuo")
            {
                priceFrom.Text = "";
                priceFrom.ForeColor = Color.Black;
            }
        }

        private void priceFrom_Leave(object sender, EventArgs e)
        {
            if (priceFrom.Text == "")
            {
                priceFrom.Text = "Nuo";
                priceFrom.ForeColor = Color.Silver;
            }
        }

        private void priceTo_Enter(object sender, EventArgs e)
        {
            if (priceTo.Text == "Iki")
            {
                priceTo.Text = "";
                priceTo.ForeColor = Color.Black;
            }
        }

        private void priceTo_Leave(object sender, EventArgs e)
        {
            if (priceTo.Text == "")
            {
                priceTo.Text = "Iki";
                priceTo.ForeColor = Color.Silver;
            }
        }

        private void areaFrom_Enter(object sender, EventArgs e)
        {
            if (areaFrom.Text == "Nuo")
            {
                areaFrom.Text = "";
                areaFrom.ForeColor = Color.Black;
            }
        }

        private void areaFrom_Leave(object sender, EventArgs e)
        {
            if (areaFrom.Text == "")
            {
                areaFrom.Text = "Nuo";
                areaFrom.ForeColor = Color.Silver;
            }
        }

        private void areaTo_Enter(object sender, EventArgs e)
        {
            if (areaTo.Text == "Iki")
            {
                areaTo.Text = "";
                areaTo.ForeColor = Color.Black;
            }
        }

        private void areaTo_Leave(object sender, EventArgs e)
        {
            if (areaTo.Text == "")
            {
                areaTo.Text = "Iki";
                areaTo.ForeColor = Color.Silver;
            }
        }

        #endregion



        private void search_Click(object sender, EventArgs e)
        {
            var Inspection = new Inspection();
            var filtersValues = new List<String> { priceFrom.Text, priceTo.Text, areaFrom.Text, areaTo.Text, municipality.Text, street.Text };
            var ListOfRealEstate = new Data().SampleData;
            richTextBox1.Text = ListToDisplay(Inspection.GetFilteredList(ListOfRealEstate, filtersValues));

            /*var town = municipality.Text;
            var streetName = street.Text;
            webBrowser2.ScriptErrorsSuppressed = true;
            try
            {
                var location = new StringBuilder("http://maps.google.com/maps?q=%22");
                if (town != string.Empty)
                {
                    location.Append(town + "," + "+");
                }
                if (streetName != string.Empty)
                {
                    location.Append(streetName + "," + "+");
                }
                webBrowser2.Navigate(location.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "error");
            }
            */
        }

        private String ListToDisplay(List<RealEstate> RealEstateList)
        {
            var tekstas = "";
            foreach (var eilute in RealEstateList)
            {
                tekstas = tekstas + eilute;
            }
            return tekstas;
        }
        
        /*
        private void showAdList_Click(object sender, EventArgs e)
        {
            this.Hide();
            var openForm2 = new Form2();
            openForm2.ShowDialog();
            this.Close();
        }
        */
    }
}
