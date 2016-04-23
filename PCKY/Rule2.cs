using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCKY {
    class Rule2 : Rule {
        //private string term;
        private float p;
        private string alter_term;



        public string Alter_term {
            get {
                return alter_term;
            }

            set {
                alter_term = value;
            }
        }

        public float P {
            get {
                return p;
            }

            set {
                p = value;
            }
        }

        public Rule2() {
            this.Term = "";
            this.P = 0;
            this.Alter_term = "";
            this.Type = 2;
        }
    }
}
