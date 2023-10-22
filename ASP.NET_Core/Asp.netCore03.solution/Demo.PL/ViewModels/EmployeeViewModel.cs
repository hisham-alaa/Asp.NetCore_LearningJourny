using Demo.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace Demo.PL.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Maximum length is 50!")]
        [MinLength(5, ErrorMessage = "Minimum length is 5!")]
        public string Name { get; set; }

        [Range(22, 30)]
        public int Age { get; set; }

        [RegularExpression("^[1-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}$"
            , ErrorMessage = "Address Must be in this form 123-street-city-country !")]
        public string Address { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public IFormFile ImageFile { get; set; }

        public string ImageName { get; set; }

        [EmailAddress]/*[DataType(DataType.EmailAddress)]*/
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Hiring Date")]
        public DateTime HireDate { get; set; }

        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
