﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITStoreApi.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public string ProductImg { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public int ProductAmount { get; set; }
    }
}
