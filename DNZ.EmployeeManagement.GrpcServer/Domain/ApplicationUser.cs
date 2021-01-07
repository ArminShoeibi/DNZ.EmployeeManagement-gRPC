using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNZ.EmployeeManagement.GrpcServer.Domain
{
    public class ApplicationUser
    {
        public int ApplicationUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
