using System;
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
        [Required(ErrorMessage ="{0} required")]
        [StringLength(60,MinimumLength = 3,ErrorMessage = "{0} size should be between {2} and {1}.")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage ="Enter a valid email")]
        public string Email { get; set; }
        [Display(Name = "Data de aniversário")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "{0} required")]
        public DateTime BithDate { get; set; }
        [Display(Name = "Salário")]
        [DisplayFormat( DataFormatString ="{0:F2}")]
        [Range(100.00,5000.0,ErrorMessage ="{0} must be from {1} to {2}")]
        [Required(ErrorMessage = "{0} required")]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        [Display(Name = "Departamento")]
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Salles { get; set; } = new List<SalesRecord>();

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

        public void AddSales(SalesRecord sr)
        {
            Salles.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Salles.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Salles.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
