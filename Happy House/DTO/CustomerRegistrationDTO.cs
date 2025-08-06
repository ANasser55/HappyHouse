using HappyHouse_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyHouse_Client.DTO
{
    public class CustomerRegistrationDTO
    {
        public Customer Customer { get; set; }
        public Installment Installment { get; set; }
        public Transaction Transaction { get; set; }
    }
}
