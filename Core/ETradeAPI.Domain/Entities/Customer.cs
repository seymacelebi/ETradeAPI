﻿using ETradeAPI.Domain.Entities.Common;

namespace ETradeAPI.Domain.Entities;

public class Customer :BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Adress { get; set; }
    public ICollection<Order> Orders { get; set; }
}
