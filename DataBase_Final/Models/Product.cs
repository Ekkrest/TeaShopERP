using System;
using System.Collections.Generic;

#nullable disable

namespace DataBase_Final.Models
{
    public partial class Product
    {
        public Product()
        {
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
            SalesOrderDetails = new HashSet<SalesOrderDetail>();
            Stocks = new HashSet<Stock>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public int ProductCategoryId { get; set; }
        public byte[] ProductPicture { get; set; }
        public string ProductDescription { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
