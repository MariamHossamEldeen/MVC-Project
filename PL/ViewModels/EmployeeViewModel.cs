using DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace PL.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        [MaxLength(50, ErrorMessage = "Max Length Is Required")]
        [MinLength(5, ErrorMessage = "Min Length Is Required")]
        public string Name { get; set; }
        [Range(22, 30, ErrorMessage = "Age Must Be Between 22,30")]
        public int? Age { get; set; }
        [RegularExpression(@"[0-9]{1,5000}-[a-zA-Z]{1,10}-[a-zA-Z]{1,10}-[a-zA-Z]{1,10}$",
            ErrorMessage = "Address Must Be Like 123-Street-City-Country")]
        public string Address { get; set; }
        [DataType(DataType.Currency)]
        [Range(4000, 8000)]
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; } // int => Not Allow Null
        // Navigational Property [One]
        public Department Department { get; set; }
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }

    }
}
