﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace gasbygas.lb.dbcontex.tables.Models
{
    /// <summary>
    /// All End Customer Details
    /// </summary>
    public partial class customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NIC { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string CustomerType { get; set; }
        public string RegistrationDate { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}