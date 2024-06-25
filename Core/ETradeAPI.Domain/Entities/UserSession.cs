using ETradeAPI.Domain.Entities.Common;
using ETradeAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Entities
{
    public class UserSession:BaseEntity
    {
        public int SessionId { get; set; }
        public string UserId { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
        public string IPAddress { get; set; }

        public virtual AppUser User { get; set; }
    }
}
