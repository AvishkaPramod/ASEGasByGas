﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace gasbygas.lb.dbcontex.tables.Models
{
    public partial class delivery
    {
        public int DeliveryID { get; set; }
        public int StockID { get; set; }
        public int UserID { get; set; }
        public string GasType { get; set; }
        public int? FullCylinderCount { get; set; }
        public DateTime? GasStockDeliveryDate { get; set; }
        public DateTime? ArrivalAtOutlet { get; set; }
        public string DeliveryStatus { get; set; }
        public string OutletRecipient { get; set; }
        public int? EmptyCylinderCount { get; set; }
        public DateTime? EmptyCylinderDeliveryDate { get; set; }
        public DateTime? ArrivalAtGasStock { get; set; }
        public string ReturnStatus { get; set; }
        public string StockRecipient { get; set; }
        public int? OutletStockID { get; set; }

        public virtual outletstock OutletStock { get; set; }
        public virtual gasstock Stock { get; set; }
        public virtual user User { get; set; }
    }
}