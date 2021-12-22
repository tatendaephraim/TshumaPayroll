using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TshumaPayroll.Models
{
    public class Employee
    {

        [Key]
        public int EmployeeId { get; set; }

        [Display(Name = " First Name")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Display(Name = " Surname")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        [Display(Name = " Gender")]
        [StringLength(50, MinimumLength = 3)]
        public string Gender { get; set; }

        [Display(Name = " Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateBirth { get; set; }

        [Display(Name = " Date Employed")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateJoined { get; set; }

        [Display(Name = "Cellphone Numbers ")]
        [StringLength(50)]
        public string ContactDetails { get; set; }

        [EmailAddress]
        [Display(Name = "Emails ")]
        [StringLength(100)]
        public string EmailAddress { get; set; }

        [Display(Name = "Residential Address ")]
        public string EmployeeAddress { get; set; }

        [Display(Name = "Job Position")]
        public string JobRole { get; set; }

        [Display(Name = "Salary Grade ")]
        public SalaryGrade Grade { get; set; }

        //One to Many Relationships with Person/Target
        //Salaries Annual - An employee can have multiple salaries Max 12 per month
        public ICollection<Salary> Salaries { get; set; }
    }
    public enum SalaryGrade
    {
        One, Two, Three, Four, Five, Six
    }
}
