using System;
using System.Collections.Generic;

#nullable disable

namespace DataBase_Final.Models
{
    public partial class SalesOrderDetail
    {
        public int SalesOrderDetailId { get; set; }
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual SalesOrderHeader SalesOrder { get; set; }
    }
}
