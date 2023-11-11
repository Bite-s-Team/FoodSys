using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSys.Application.DTO.Response.Customer
{
    public class AddCustomerResponse
    {
        public virtual Guid? Id { get; set; }
        public virtual String Name { get; set; }
        public virtual String Email { get; set; }
        public virtual String Token { get; set; }
    }
}
