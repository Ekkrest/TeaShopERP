using System;
using System.Collections.Generic;

#nullable disable

namespace DataBase_Final.Models
{
    public partial class PurchaseOrderHeader
    {
        public PurchaseOrderHeader()
        {
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
        }

        public int PurchaseOrderId { get; set; }
        public int AdministratorId { get; set; }
        public string Supplier { get; set; }
        public decimal PurchaseTotal { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Administrator PurchaseOrder { get; set; }
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}
