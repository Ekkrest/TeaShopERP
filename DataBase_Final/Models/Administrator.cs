using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DataBase_Final.Models
{
    public partial class Administrator
    {
        public Administrator()
        {
            SalesOrderHeaders = new HashSet<SalesOrderHeader>();
        }

        public int AdministratorId { get; set; }

        [Required]
        [Display(Name = "使用者帳戶")]
        public string AdministratorName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [NotMapped]
        public bool Approval { get; set; }

        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual PurchaseOrderHeader PurchaseOrderHeader { get; set; }
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
    }
}
