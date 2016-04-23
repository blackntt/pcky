using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCKY
{
    class Rule1:Rule
    {
        //private string term;
        private float p;
        private List<string> alter_terms;

        public float P
        {
            get
            {
                return p;
            }

            set
            {
                p = value;
            }
        }

        public List<string> Alter_terms
        {
            get
            {
                return alter_terms;
            }

            set
            {
                alter_terms = value;
            }
        }

        public Rule1()
        {
            Term = "";
            Alter_terms = null;
            P = 0;
        }
    }
}
