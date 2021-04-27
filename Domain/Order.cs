﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Description { get; set; }
        public string Customer { get; set; }
        public string  Product { get; set; }
        public Confirmation  Confirmation  { get; set; }
        public Project Project  { get; set; }
        public Status  Status  { get; set; }
        public List<OperatorAcc> Operators  { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }






    }
}
