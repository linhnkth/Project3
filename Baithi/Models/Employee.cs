using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Baithi.Models
{
    public class Employee
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public int Salary { get; set; }
    }
}