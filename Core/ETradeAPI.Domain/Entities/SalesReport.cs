using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Entities
{
    public class SalesReport:BaseEntity
    {
        public string ReportType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Data { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class CustomerAnalytics : BaseEntity
    {
        public int CustomerId { get; set; }
        public int VisitCount { get; set; }
        public int PurchaseCount { get; set; }
        public DateTime LastVisit { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
