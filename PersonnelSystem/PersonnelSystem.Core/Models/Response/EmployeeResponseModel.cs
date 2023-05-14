using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelSystem.Core.Models.Response
{
    public class EmployeeResponseModel
    {
        public int Id { get; set; }
        public int? ManagerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Roles { get; set; }
    }
}
