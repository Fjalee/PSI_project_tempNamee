﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MERG_BackEnd
{
    public class Tools
    {
       public void OpenLinks(double lat, double lng, List<RealEstate> data)
        {
            var links = data.Where(x => x.Latitude == lat && x.Longitude == lng).Select(x => x.Link);

            foreach (var link in links)
            {
                System.Diagnostics.Process.Start(link);
            }
        }
    }
}
