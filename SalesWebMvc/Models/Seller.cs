using System;
using System.Collections.Generic;
using System.Linq;
using SalesWebMvc.Models.Enums;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BithDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public ICollection<SallesRecord> Salles { get; set; } = new List<SallesRecord>();

        public Seller()
        {

        }
        public Seller(int id, string name, string email, DateTime bithDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BithDate = bithDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SallesRecord sr)
        {
            Salles.Add(sr);
        }

        public void RemoveSales(SallesRecord sr)
        {
            Salles.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Salles.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
