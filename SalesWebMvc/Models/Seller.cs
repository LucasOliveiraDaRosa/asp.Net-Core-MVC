﻿using System;
using System.Collections.Generic;
using System.Linq;
using SalesWebMvc.Models.Enums;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Data de aniversário")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BithDate { get; set; }
        [Display(Name = "Salário")]
        [DisplayFormat( DataFormatString ="{0:F2}")]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        [Display(Name = "Departamento")]
        public int DepartmentId { get; set; }
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
