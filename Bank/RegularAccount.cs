using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class RegularAccount : Account
    {
        public RegularAccount(Person owner, Money amount) : base(owner, amount)
        {

        }
    }
}
