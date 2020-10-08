﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using AngleSharp.Text;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Windows;

namespace MERG_PSI{
    public partial class Form1 : Form{
        private List<string> kampasAdsLinks = new List<string>();

        public Form1(){
            InitializeComponent();
        }
        public async void button1_Click(object sender, EventArgs e){
            adCardLinkScraper ws = new adCardLinkScraper("https://www.kampas.lt", "https://www.kampas.lt", "k-ad-card-wide");
            await ws.scrapeUrlsAsync();
            kampasAdsLinks = ws.getUrls();

            foreach (var link in kampasAdsLinks){
                insideAdScraper ias = new insideAdScraper(link, "k-classified-icon-item");
                await ias.scrapeBuildingInfoAsync();
                temp(link, ias);
            }
        }

        private void temp(string link, insideAdScraper ias){
            richTextBox1.AppendText(link);
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText(ias.size);
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText(ias.eurPerSq);
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText(ias.rooms);
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText(ias.floor);
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText(ias.construction);
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText(ias.isEquipped);
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText(ias.heating);
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText(ias.buildYear);
            richTextBox1.AppendText("\n\n*\n*\n*\n");
        }
    }
}

