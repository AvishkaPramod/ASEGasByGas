﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace gasbygas.lb.dbcontex.tables.Models
{
    public partial class gasstock
    {
        public gasstock()
        {
            deliveries = new HashSet<delivery>();
        }

        public int StockID { get; set; }
        public string GasType { get; set; }
        public int DistributedQTY { get; set; }
        public int? QuantityAvailable { get; set; }
        public double? UnitPrice { get; set; }
        public int? StockQuantity { get; set; }
        public string StockStatus { get; set; }
        public int? RecoveredemptyQTY { get; set; }
        public int? UserID { get; set; }

        public virtual user User { get; set; }
        public virtual ICollection<delivery> deliveries { get; set; }
    }
}