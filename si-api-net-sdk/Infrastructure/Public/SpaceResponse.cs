﻿using System;
namespace SpaceInvoices
{
    public class SpaceResponse
    {
        public string ResponseJson { get; set; }
        public string ObjectJson { get; set; }
        //public string RequestId { get; set; }
        public DateTime RequestDate { get; set; }
    }
}