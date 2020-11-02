﻿using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace App
{
    public partial class Form1 : Form
    {
        private readonly GMapOverlay _markOverlay = new GMapOverlay("marker");
        public Form1()
        {
            InitializeComponent();
            var data = (new Data()).SampleData;
            MapLoad();
            LoadMarkers(data);

        }

        private void MapLoad()
        {
            map.ShowCenter = false;
            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.GoogleMap;
            map.Position = new PointLatLng(55.233400, 23.894970);
        }

        private void LoadMarkers(List<RealEstate> filteredList)
        {
            _markOverlay.Markers.Clear();
            foreach (var ad in filteredList)
            {
                var marker = new GMarkerGoogle(new PointLatLng(SplitCoordinates(ad.MapCoords)[0], SplitCoordinates(ad.MapCoords)[1]), GMarkerGoogleType.red);
                marker.ToolTip = new GMapRoundedToolTip(marker);
                marker.ToolTipText = ad.ToString();
                marker.ToolTip.Fill = Brushes.Black;
                marker.ToolTip.Foreground = Brushes.White;
                marker.ToolTip.Stroke = Pens.Black;
                marker.ToolTip.TextPadding = new Size(20, 20);
                _markOverlay.Markers.Add(marker);
            }
            map.Overlays.Add(_markOverlay);
        }

        private double[] SplitCoordinates(string coords)
        {
            var darray = new double[2];
            var latAndLong = coords.Split(',');
            darray[0] = double.Parse(latAndLong[0], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo);
            darray[1] = double.Parse(latAndLong[1], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo);
            return darray;
        }


        #region TextBox Input 
        private void Municipality_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigitLetter(e);
        }

        private void Street_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigitLetter(e);
        }

        private void PriceFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigit(e);
        }

        private void PriceTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigit(e);
        }

        private void AreaFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigit(e);
        }

        private void AreaTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigit(e);
        }

        private void PricePerSqMFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigit(e);
        }

        private void PricePerSqMTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigit(e);
        }

        private void BuildYearFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigit(e);
        }

        private void BuildYearTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigit(e);
        }

        private void NumberOfRoomsFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigit(e);
        }

        private void NumberOfRoomsTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyKeysControlDigit(e);
        }

        private void AllowOnlyKeysControlDigit(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AllowOnlyKeysControlDigitLetter(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }


        #endregion
        #region Prompt text

        private void PriceFrom_Enter(object sender, EventArgs e)
        {
            SetupTextBoxIf(priceFrom, "Nuo", "", Color.Black);
        }

        private void PriceFrom_Leave(object sender, EventArgs e)
        {
            SetupTextBoxIf(priceFrom, "", "Nuo", Color.Silver);
        }

        private void PriceTo_Enter(object sender, EventArgs e)
        {
            SetupTextBoxIf(priceTo, "Iki", "", Color.Black);
        }

        private void PriceTo_Leave(object sender, EventArgs e)
        {
            SetupTextBoxIf(priceTo, "", "Iki", Color.Silver);
        }

        private void PricePerSqMFrom_Enter(object sender, EventArgs e)
        {
            SetupTextBoxIf(pricePerSqMFrom, "Nuo", "", Color.Black);
        }

        private void PricePerSqMFrom_Leave(object sender, EventArgs e)
        {
            SetupTextBoxIf(pricePerSqMFrom, "", "Nuo", Color.Silver);
        }

        private void PricePerSqMTo_Enter(object sender, EventArgs e)
        {
            SetupTextBoxIf(pricePerSqMTo, "Iki", "", Color.Black);
        }

        private void PricePerSqMTo_Leave(object sender, EventArgs e)
        {
            SetupTextBoxIf(pricePerSqMTo, "", "Iki", Color.Silver);
        }

        private void BuildYearFrom_Enter(object sender, EventArgs e)
        {
            SetupTextBoxIf(buildYearFrom, "Nuo", "", Color.Black);
        }

        private void BuildYearFrom_Leave(object sender, EventArgs e)
        {
            SetupTextBoxIf(buildYearFrom, "", "Nuo", Color.Silver);
        }

        private void BuildYearTo_Enter(object sender, EventArgs e)
        {
            SetupTextBoxIf(buildYearTo, "Iki", "", Color.Black);
        }

        private void BuildYearTo_Leave(object sender, EventArgs e)
        {
            SetupTextBoxIf(buildYearTo, "", "Iki", Color.Silver);
        }

        private void NumberOfRoomsFrom_Enter(object sender, EventArgs e)
        {
            SetupTextBoxIf(numberOfRoomsFrom, "Nuo", "", Color.Black);
        }

        private void NumberOfRoomsFrom_Leave(object sender, EventArgs e)
        {
            SetupTextBoxIf(numberOfRoomsFrom, "", "Nuo", Color.Silver);
        }

        private void NumberOfRoomsTo_Enter(object sender, EventArgs e)
        {
            SetupTextBoxIf(numberOfRoomsTo, "Iki", "", Color.Black);
        }

        private void NumberOfRoomsTo_Leave(object sender, EventArgs e)
        {
            SetupTextBoxIf(numberOfRoomsTo, "", "Iki", Color.Silver);
        }

        private void AreaFrom_Enter(object sender, EventArgs e)
        {
            SetupTextBoxIf(areaFrom, "Nuo", "", Color.Black);
        }

        private void AreaFrom_Leave(object sender, EventArgs e)
        {
            SetupTextBoxIf(areaFrom, "", "Nuo", Color.Silver);
        }

        private void AreaTo_Enter(object sender, EventArgs e)
        {
            SetupTextBoxIf(areaTo, "Iki", "", Color.Black);
        }

        private void AreaTo_Leave(object sender, EventArgs e)
        {
            SetupTextBoxIf(areaTo, "", "Iki", Color.Silver);
        }
        private void SetupTextBoxIf(TextBox textBox, string ifText, string textToSet, Color color)
        {
            if (textBox.Text == ifText)
            {
                textBox.Text = textToSet;
                textBox.ForeColor = color;
            }
        }

        #endregion


        private void Search_Click(object sender, EventArgs e)
        {
            var inspection = new Inspection();
            //var filtersValues = new List<string> { priceFrom.Text, priceTo.Text, areaFrom.Text, areaTo.Text, municipality.Text, street.Text, pricePerSqMFrom.Text, pricePerSqMTo.Text, buildYearFrom.Text, buildYearTo.Text, numberOfRoomsFrom.Text, numberOfRoomsTo.Text };
            //var listOfRealEstate = new Data().SampleData;
            //var noInfoBuild = noInfoBuildYear.Checked;
            //var noInfoRooms = noInfoRoomNumber.Checked;
            //var filteredList = inspection.GetFilteredListOFRealEstate(listOfRealEstate, filtersValues, noInfoBuild, noInfoRooms);
           

           
            var filtersValue = GetFiltersValue();
            //LoadMarkers(filteredList);
        }

        private Tuple<bool, int> ConvertToInt(string text)
        {

            var succes = int.TryParse(text, out var number);
            if (succes)
            {
                return new Tuple<bool, int>(succes, number);
            }
            return new Tuple<bool, int>(succes, 0);

        }
        private FiltersValue GetFiltersValue ()
        {
            return new FiltersValue(priceFrom: ConvertToInt(priceFrom.Text), priceTo: ConvertToInt(priceTo.Text), 
              areaFrom: ConvertToInt(areaFrom.Text), areaTo: ConvertToInt(areaTo.Text), 
              buildYearFrom: ConvertToInt(buildYearFrom.Text), buildYearTo: ConvertToInt(buildYearTo.Text), 
              numberOfRoomsFrom: ConvertToInt(numberOfRoomsFrom.Text), numberOfRoomsTo: ConvertToInt(numberOfRoomsTo.Text));
        }
    }
}