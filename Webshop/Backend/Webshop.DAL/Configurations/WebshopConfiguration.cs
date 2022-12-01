﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.DAL.Configurations
{
    public class WebshopConfiguration
    {
        public int MaxUploadSize { get; set; } = 25;

        public int MaxUploadCount { get; set; } = 5;

        public string StaticFilePath { get; set; } = string.Empty;
    }
}
