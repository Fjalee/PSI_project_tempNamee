﻿
using System;

namespace App
{
    class FiltersValue
    {
        public Tuple<bool,int> PriceFrom { get; }
        public Tuple<bool, int> PriceTo { get; }
        public Tuple<bool, int> AreaTo { get; }
        public Tuple<bool, int> AreaFrom { get; }
        public Tuple<bool, int> BuildYearFrom { get; }
        public Tuple<bool, int> BuildYearTo { get; }
        public Tuple<bool, int> NumberOfRoomsFrom { get; }
        public Tuple<bool, int> NumberOfRoomsTo { get;}

        public FiltersValue (Tuple<bool, int> priceFrom, Tuple<bool,int> priceTo , Tuple<bool,int> areaFrom , Tuple<bool,int> areaTo , Tuple<bool,int> buildYearFrom , Tuple<bool,int> buildYearTo , Tuple<bool,int> numberOfRoomsFrom , Tuple<bool,int> numberOfRoomsTo )
        {
            PriceFrom = priceFrom;
            PriceTo = priceTo;
            AreaFrom = areaFrom;
            AreaTo = areaTo;
            BuildYearFrom = buildYearFrom;
            BuildYearTo = buildYearTo;
            NumberOfRoomsFrom = numberOfRoomsFrom;
            NumberOfRoomsTo = numberOfRoomsTo;
        }
    }
}