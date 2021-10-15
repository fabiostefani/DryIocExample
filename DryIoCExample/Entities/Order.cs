using System;
namespace DryIoCExample.Entities
{
    public class Order
    {
        public Order(Guid id, decimal total, DateTime issueDate)
        {
            Id = id;
            Total = total;
            IssueDate = issueDate;
        }

        public Guid Id { get; set; }        
        public decimal Total { get; set; }        
        public DateTime IssueDate { get;  set; }        
    }
}