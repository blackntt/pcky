using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCKY
{
    public partial class Form1 : Form
    {
        const string TRAINING_FILE = "training.txt";
        List<Rule1> rules1 = new List<Rule1>();
        List<Rule2> rules2 = new List<Rule2>();
        Rule[,] matrix;
        public Form1()
        {
            InitializeComponent();
            getRulesFromFile(rules1, rules2);
            this.Click += Form1_Click;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
      
        }

        private void getRulesFromFile(List<Rule1> rules1, List<Rule2> rules2)
        {
            //Read content from the training file to a string
            string[] content = System.IO.File.ReadAllLines(TRAINING_FILE);

            //create rule1 from training content
            foreach (var line in content)
            {
                string[] strRule = line.Split(':');

                //if current rule is rule1
                if (strRule.GetValue(0) as string == "rule1")
                {
                    Rule1 currRule = new Rule1();
                    currRule.Term = (string)strRule.GetValue(1);
                    currRule.Alter_terms = (strRule.GetValue(2) as string).Split(' ').ToList();
                    currRule.Pro = Decimal.Parse(strRule.GetValue(3).ToString());
                    rules1.Add(currRule);
                }
                else//rule2
                {
                    Rule2 currRule = new Rule2();
                    currRule.Term = (string)strRule.GetValue(1);
                    currRule.Alter_term = (strRule.GetValue(2) as string);
                    currRule.Pro = Decimal.Parse(strRule.GetValue(3).ToString());
                    rules2.Add(currRule);
                }
            }
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //enter key
            if (e.KeyChar == 13)
            {
                string[] testingSentence = this.textBox1.Text.Split(' ');
                matrix = new Rule[testingSentence.Length, testingSentence.Length];

                for (int i = 0; i < testingSentence.Length; i++)
                {
                    foreach (var item in rules2)
                    {
                        if (item.Alter_term.ToUpper().CompareTo(testingSentence[i].ToUpper()) == 0)
                        {
                            matrix[i, i] = item;
                        }
                    }
                }
                //i column
                for (int i = 1; i < testingSentence.Length; i++)
                {
                    for (int row = i -1;row >=0;row--)
                    {
                        for (int col = row; col < i; col++)
                        {
                            //matrix[row, col];
                            //matrix[col,i]
                            if (matrix[row, col]!=null )
                            {
                                if (matrix[col+1, i] != null)
                                {
                                    foreach (var item in rules1)
                                    {
                                        if (item.Alter_terms[0].ToUpper().CompareTo(matrix[row, col].Term.ToUpper()) == 0 &&
                                            item.Alter_terms[1].ToUpper().CompareTo(matrix[col+1, i].Term.ToUpper()) == 0)
                                        {
                                            Rule1 newItem = new Rule1();
                                            newItem.Alter_terms = item.Alter_terms;
                                            newItem.P = item.P;
                                            newItem.Pro = item.Pro* matrix[row, col].Pro* matrix[col + 1, i].Pro;
                                            newItem.Term = item.Term;
                                            matrix[row, i] = newItem;
                                        }
                                    }
                                }
                            }
                        }
                    }
                 
                }
                if (matrix[0, testingSentence.Length-1].Term.ToUpper().CompareTo("S") == 0)
                    MessageBox.Show("OK babe"+ matrix[0, testingSentence.Length - 1].Pro);
            }
        }
    }
}
