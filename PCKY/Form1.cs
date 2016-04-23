using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCKY {
    public partial class Form1 : Form {
        const string TRAINING_FILE = "training.txt";
        List<Rule1> rules1 = new List<Rule1>();
        List<Rule2> rules2 = new List<Rule2>();
        List<Cell>[,] cellMatrix;
        public Form1() {
            InitializeComponent();
            getRulesFromFile(rules1, rules2);
        }
        private void getRulesFromFile(List<Rule1> rules1, List<Rule2> rules2) {
            //Read content from the training file to a string
            string[] content = System.IO.File.ReadAllLines(TRAINING_FILE);

            //create rule1 from training content
            foreach (var line in content) {
                string[] strRule = line.Split(':');

                //if current rule is rule1
                if (strRule.GetValue(0) as string == "rule1") {
                    Rule1 currRule = new Rule1();
                    currRule.Term = (string)strRule.GetValue(1);
                    currRule.Alter_terms = (strRule.GetValue(2) as string).Split(' ').ToList();
                    currRule.Pro = Decimal.Parse(strRule.GetValue(3).ToString());
                    rules1.Add(currRule);
                } else//rule2
                  {
                    Rule2 currRule = new Rule2();
                    currRule.Term = (string)strRule.GetValue(1);
                    currRule.Alter_term = (strRule.GetValue(2) as string);
                    currRule.Pro = Decimal.Parse(strRule.GetValue(3).ToString());
                    rules2.Add(currRule);
                }
            }
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            //enter key
            if (e.KeyChar == 13) {

                //get and split sentences based on space
                string[] testingSentence = this.textBox1.Text.Split(' ');

                //init matrix
                cellMatrix = new List<Cell>[testingSentence.Length, testingSentence.Length];

                //init for each cell in cellMatrix;
                for (int i = 0; i < testingSentence.Length; i++) {
                    for (int j = 0; j < testingSentence.Length; j++) {
                        cellMatrix[i, j] = new List<Cell>();
                    }
                }

                //assign label(rule) for terminal term
                for (int i = 0; i < testingSentence.Length; i++) {
                    foreach (var item in rules2) {
                        if (item.Alter_term.ToUpper().CompareTo(testingSentence[i].ToUpper()) == 0) {
                            Cell newCell = new Cell();
                            newCell.Rule = item;
                            cellMatrix[i, i].Add(newCell);
                        }
                    }
                }

                //i column
                for (int i = 1; i < testingSentence.Length; i++) {
                    for (int row = i - 1; row >= 0; row--) {
                        for (int col = row; col < i; col++) {
                            if (cellMatrix[row, col].Count != 0) {
                                if (cellMatrix[col + 1, i].Count != 0) {
                                    foreach (var item in rules1) {
                                        for (int k_rule1 = 0; k_rule1 < cellMatrix[row, col].Count; k_rule1++) {
                                            for (int k_rule2 = 0; k_rule2 < cellMatrix[col + 1, i].Count; k_rule2++) {
                                                if (item.Alter_terms[0].ToUpper().CompareTo(cellMatrix[row, col][k_rule1].Rule.Term.ToUpper()) == 0 &&
                                                    item.Alter_terms[1].ToUpper().CompareTo(cellMatrix[col + 1, i][k_rule2].Rule.Term.ToUpper()) == 0) {
                                                    Rule1 newItem = new Rule1();
                                                    newItem.Alter_terms = item.Alter_terms;
                                                    newItem.P = item.P;
                                                    newItem.Pro = item.Pro * cellMatrix[row, col][0].Rule.Pro * cellMatrix[col + 1, i][0].Rule.Pro;
                                                    newItem.Term = item.Term;
                                                    Cell newCell = new Cell();
                                                    newCell.Rule = newItem;
                                                    newCell.X_cell1 = row;
                                                    newCell.Y_cell1 = col;
                                                    newCell.X_cell2 = col + 1;
                                                    newCell.Y_cell2 = i;
                                                    newCell.Index_rule1 = k_rule1;
                                                    newCell.Index_rule2 = k_rule2;
                                                    cellMatrix[row, i].Add(newCell);
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }

                }
                foreach (var item in cellMatrix[0, testingSentence.Length - 1]) {
                    if (item.Rule.Term.ToUpper().CompareTo("S") == 0) {
                        MessageBox.Show("OK babe" + item.Rule.Pro);
                    }
                }                    
            }
        }
    }
}
