using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharp1.domain
{
    class AccountDTO
    {
        private string accountNo;
        private string accountName;
        private double balance;

        public string AccountNo { get => accountNo; set => accountNo = value; }
        public string AccountName { get => accountName; set => accountName = value; }
        public double Balance { get => balance; set => balance = value; }
    }
}
