using System;
using System.Collections.Generic;

#nullable disable

namespace DataBase_Final.Models
{
    public partial class SalesOrderHeader
    {
        public SalesOrderHeader()
        {
            SalesOrderDetails = new HashSet<SalesOrderDetail>();
        }

        public int SalesOrderId { get; set; }
        public int AdministratorId { get; set; }
        public string Customer { get; set; }
        public string SalesTotal { get; set; }
        public DateTime SalesDate { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Administrator Administrator { get; set; }
        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
    }
}
