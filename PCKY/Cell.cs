using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCKY {
    class Cell {
        Rule rule;
        int x_cell1;
        int y_cell1;
        int x_cell2;
        int y_cell2;
        int index_rule1;
        int index_rule2;

        public Cell() {
            X_cell1 = -1;
            Y_cell1= -1;
            X_cell2 = -1;
            Y_cell2 = -1;
            Index_rule1 = -1;
            Index_rule2 = -1;
        }

        public Rule Rule {
            get {
                return rule;
            }

            set {
                rule = value;
            }
        }

        public int X_cell1 {
            get {
                return x_cell1;
            }

            set {
                x_cell1 = value;
            }
        }

        public int X_cell2 {
            get {
                return x_cell2;
            }

            set {
                x_cell2 = value;
            }
        }

        public int Y_cell2 {
            get {
                return y_cell2;
            }

            set {
                y_cell2 = value;
            }
        }

        public int Y_cell1 {
            get {
                return y_cell1;
            }

            set {
                y_cell1 = value;
            }
        }

        public int Index_rule1 {
            get {
                return index_rule1;
            }

            set {
                index_rule1 = value;
            }
        }

        public int Index_rule2 {
            get {
                return index_rule2;
            }

            set {
                index_rule2 = value;
            }
        }
    }
}
