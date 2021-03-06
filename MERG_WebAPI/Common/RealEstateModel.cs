﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public abstract class RealEstateModel
    {

        public string Link { get; set; }
        public double Area { get; set; }
        public double PricePerSqM { get; set; }
        public int NumberOfRooms { get; set; }
        public string Floor { get; set; }
        public double Price { get; set; }
        public string MapLink { get; set; }
        public string Municipality { get; set; }
        public string Microdistrict { get; set; }
        public string Street { get; set; }
        public int BuildYear { get; set; }
        public string Image { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
