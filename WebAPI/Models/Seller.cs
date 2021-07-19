using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebAPI.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} required")] // {0}, nome do atributo
        [StringLength(60, MinimumLength = 2, ErrorMessage = "{0} size should be between {2} and {1}")] //{2} minimo {1} maximo
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)] //Annotations que formatam o formato das propriedades
        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string Email { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] // 0 -> indica o valor do atributo
        [Required(ErrorMessage = "{0} required")]
        public DateTime BirthName { get; set; }

        [Display(Name = "Base Salary")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "{0} required")]
        [Range(1000.00, 50000.00, ErrorMessage = "{0} must be from {1} to {2}")]
        public double BaseSalary { get; set; }

        public Department Department { get; set; }

        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

       public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthname, double basesalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthName = birthname;
            BaseSalary = basesalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }
        
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(saleRecord => saleRecord.Date >= initial && saleRecord.Date <= final).Sum(saleRecord => saleRecord.Amount);
        }



    }
}
