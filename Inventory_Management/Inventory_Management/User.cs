using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Order> OrderHistory { get; set; }
        public User(string userId, string name, string email)
        {
            Id = userId;
            Name = name;
            Email = email;
            OrderHistory = new List<Order>();
        }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Email: {Email}";
        }
    }
}
