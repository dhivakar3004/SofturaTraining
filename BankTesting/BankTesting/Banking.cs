using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitEg
{
    public class Banking
    {
        public double balance { get; set; }
        public string msg { get; set; }
        public void DepositAmt(int amt)
        {
            if (amt < 0)
            {
                balance = balance;
            }
            else
            {
                balance += amt;
            }
        }
        public string WithdrawAmt(int amt)
        {

            if (balance > amt)
            {
                balance = -amt;
                msg = "success";
                return msg;
            }
            else
            {
                msg = "Sorry!Not Enough Balance";
                return msg;
            }
        }
    }
}