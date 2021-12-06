using System;
using System.Collections.Generic;

#nullable disable

namespace DataBase_Final.Models
{
    public partial class Stock
    {
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public int StockAmount { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Product Product { get; set; }
    }
}
