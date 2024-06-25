using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Entities
{
    public class CustomerPreference : BaseEntity
    {
        public int CustomerId { get; set; }
        public string PreferenceType { get; set; }
        public string PreferenceValue { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual Customer Customer { get; set; }
    }

    public class LoyaltyProgram : BaseEntity
    {
        public int CustomerId { get; set; }
        public int Points { get; set; }
        public string Tier { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
