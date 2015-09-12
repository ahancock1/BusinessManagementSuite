using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Framework.Data
{
    public class Email : Entity
    {
        public int EmailID { get; set; }

        public string Address { get; set; }


        public static bool Validate(Email email)
        {
            throw new NotImplementedException("Email validation is not yet implemented");
        }

    }
}
