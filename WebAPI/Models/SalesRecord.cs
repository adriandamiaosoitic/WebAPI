using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [DataType(DataType.Currency)]
        public Double Amount { get; set; }
        public SaleStatus Status { get; set; }

        public Seller Seller { get; set; }

        public SalesRecord()
        {

        }
                public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
