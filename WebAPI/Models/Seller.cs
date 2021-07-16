﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Models
{
    public class Seller
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthName { get; set; }
        public double BaseSalary { get; set; }

        public Department Department { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

       public Seller()
        {
        }

        public Seller(long id, string name, string email, DateTime birthname, double basesalary, Department department)
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
