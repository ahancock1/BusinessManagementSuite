using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Framework.Data.Establishments.Payroll
{
    public class ExpenseClaim
    {
        public int ExpenseClaimID { get; set; }

        public float Total { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public Employee Employee { get; set; }

        public List<Receipt> Receipts { get; set; }
    }
}
