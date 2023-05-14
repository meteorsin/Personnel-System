using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using PersonnelSystem.Core.Entities;

namespace PersonnelSystem.Core.Models.Request
{
    public class EmployeeRequestModel
    {
        [Required]
        public int? ManagerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Roles { get; set; }

    }
}
