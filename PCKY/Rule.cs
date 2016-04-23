using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCKY
{
    class Rule
    {
        protected string term;

        public string Term
        {
            get
            {
                return term;
            }

            set
            {
                term = value;
            }
        }

        public decimal Pro
        {
            get
            {
                return pro;
            }

            set
            {
                pro = value;
            }
        }

        protected decimal pro;

    }
}
