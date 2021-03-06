﻿using Xamarin.Forms.Maps;

namespace Xamarin_UI.Services
{
    public class CustomPin : Pin
    {
        public string Link { get; set; }
        public double Area { get; set; }
        public double PricePerSqM { get; set; }
        public int NumberOfRooms { get; set; }
        public string Floor { get; set; }
        public double Price { get; set; }
        public string Municipality { get; set; }
        public string Microdistrict { get; set; }
        public string Street { get; set; }
        public int BuildYear { get; set; }
        public string Image { get; set; }
    }
}