using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Common
{
    public class Participant
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string FamilyName { get; set; }  

        public string Comment { get; set; }

        public bool IsRegistered { get; set; }

        public IdDocument IdDocument { get; set; }

        public Address Address { get; set; }
    }
}
