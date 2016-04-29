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
        Bitmap bt;
        int h_distance = 90;
        int v_distance = 90;

        string currSentence = "";

        TextBox[,] textBoxMatrix;

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

                this.lVListTree.Items.Clear();
                this.tVTree.Nodes.Clear();
                this.pnTree.Image = null;
                //get and split sentences based on space
                if (currSentence != "") {
                    string[] currSentences = currSentence.Split(' ');
                    if (textBoxMatrix != null)
                    {
                        for (int i = 0; i < currSentences.Length + 1; i++)
                        {
                            for (int j = 0; j < currSentences.Length + 1; j++)
                            {
                                this.Controls.Remove(textBoxMatrix[i, j]);
                            }
                        }
                    }
                }
                currSentence = this.textBox1.Text;
                string[] testingSentence = this.textBox1.Text.Split(' ');

                      

                //init matrix
                cellMatrix = new List<Cell>[testingSentence.Length, testingSentence.Length];

                textBoxMatrix = new TextBox[testingSentence.Length + 1, testingSentence.Length + 1];

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

                int x_start_button= 1100;
                int y_start_button= 50;
                int width_textbox = 50;
                int height_textbox = 10;
                int textbox_cell_distance_h = 0;
                int textbox_cell_distance_v = 10;

                textBoxMatrix[0, 0] = new TextBox();
                textBoxMatrix[0, 0].Size = new Size(width_textbox, height_textbox);
                textBoxMatrix[0, 0].Location = new Point(x_start_button, y_start_button);
                textBoxMatrix[0, 0].Text = "0";
                this.Controls.Add(textBoxMatrix[0, 0]);

                for (int j = 0; j < testingSentence.Length; j++) {
                    textBoxMatrix[0, j + 1] = new TextBox();
                    textBoxMatrix[0, j + 1].Size = new Size(width_textbox, height_textbox);
                    textBoxMatrix[0, j + 1].Location = new Point(x_start_button + (width_textbox + textbox_cell_distance_h) * (j+1), y_start_button );
                    textBoxMatrix[0, j + 1].Text = testingSentence[j] + "--" + (j+1);
                    this.Controls.Add(textBoxMatrix[0, j + 1]);
                }
                for (int i = 0; i < testingSentence.Length; i++) {
                    textBoxMatrix[i + 1, 0] = new TextBox();
                    textBoxMatrix[i + 1, 0].Size = new Size(width_textbox, height_textbox);
                    textBoxMatrix[i + 1, 0].Location = new Point(x_start_button, y_start_button + (height_textbox + textbox_cell_distance_v) * (i+1));
                    textBoxMatrix[i + 1, 0].Text = i.ToString();
                    this.Controls.Add(textBoxMatrix[i + 1, 0]);
                }
                for (int i = 0; i < testingSentence.Length; i++) {
                    for (int j = 0; j < testingSentence.Length; j++) {
                        string result = "";
                        for (int k = 0; k < cellMatrix[i,j].Count; k++) {
                            result += cellMatrix[i, j][k].Rule.Term + " ";
                        }
                        textBoxMatrix[i + 1, j + 1] = new TextBox();
                        textBoxMatrix[i + 1, j + 1].Size = new Size(width_textbox, height_textbox);
                        textBoxMatrix[i + 1, j + 1].Location = new Point(x_start_button + (width_textbox + textbox_cell_distance_h) * (j + 1), y_start_button + (height_textbox + textbox_cell_distance_v) * (i + 1));
                        textBoxMatrix[i + 1, j + 1].Text = result;
                        this.Controls.Add(textBoxMatrix[i + 1, j + 1]);
                    }
                }

                for (int i = 0; i < cellMatrix[0, testingSentence.Length - 1].Count; i++) {
                    if (cellMatrix[0, testingSentence.Length - 1][i].Rule.Term.ToUpper().CompareTo("S") == 0) {
                        //bt = new Bitmap(testingSentence.Length * (h_distance + 10), countHeightOfTree(0, testingSentence.Length - 1, i, cellMatrix) * (v_distance + 10));
                        //bt = new Bitmap(testingSentence.Length * (h_distance + 10)*4, countHeightOfTree(0, testingSentence.Length - 1, i, cellMatrix) * (v_distance + 10));
                        //this.lbTreesListForm.Text += cellMatrix[0, testingSentence.Length - 1][i].Rule.Pro + " " + buildTree(0, testingSentence.Length - 1, i, cellMatrix) + "\n";


                        string[] tempItem = new string[5];
                        tempItem[0] = i.ToString();
                        tempItem[1] = cellMatrix[0, testingSentence.Length - 1][i].Rule.Pro + " " + buildTree(0, testingSentence.Length - 1, i, cellMatrix);

                        this.lVListTree.Items.Add(new ListViewItem(tempItem));

                        //drawTree(0, testingSentence.Length - 1, i, cellMatrix,bt.Size.Width/2, 10);

                        //this.pnTree.Image = bt;


                        this.tVTree.Nodes.Add(drawTreeView(0, testingSentence.Length - 1, i, cellMatrix));
                    }
                }
                if (this.lVListTree.Items.Count != 0) {
                    this.lVListTree.Items[0].Focused = true;
                    this.lVListTree.Items[0].Selected = true;
                }
            }
        }

        private int countWidthOfTree(int x_index, int y_index, int k_rule, List<Cell>[,] cellMatrix)
        {
            Cell cell = cellMatrix[x_index, y_index][k_rule];
            if (cell.Index_rule1 == -1)
            {
                return 1;
            }
            else
            {
                int left = countWidthOfTree(cell.X_cell1, cell.Y_cell1, cell.Index_rule1, cellMatrix);
                int right = countWidthOfTree(cell.X_cell2, cell.Y_cell2, cell.Index_rule2, cellMatrix);
                return left + right;
            }
        }

        private int countHeightOfTree(int x_index, int y_index, int k_rule, List<Cell>[,] cellMatrix) {
            Cell cell = cellMatrix[x_index, y_index][k_rule];
            if (cell.Index_rule1 == -1) {
                string[] testingSentence = this.textBox1.Text.Split(' ');
                return 1;
            } else {
                int left = countHeightOfTree(cell.X_cell1, cell.Y_cell1, cell.Index_rule1, cellMatrix);
                int right = countHeightOfTree(cell.X_cell2, cell.Y_cell2, cell.Index_rule2, cellMatrix);
                int max = left > right ? left : right;
                return 1 + max;
            }
        }

        private string buildTree(int x_index, int y_index, int k_rule, List<Cell>[,] cellMatrix) {
            Cell cell = cellMatrix[x_index, y_index][k_rule];
            if (cell.Index_rule1 == -1) {
                string[] testingSentence = this.textBox1.Text.Split(' ');
                return "(" + cell.Rule.Term + " " + testingSentence[x_index] + ")";
            } else {
                return "(" + cell.Rule.Term + " " + buildTree(cell.X_cell1, cell.Y_cell1, cell.Index_rule1, cellMatrix) + " " + buildTree(cell.X_cell2, cell.Y_cell2, cell.Index_rule2, cellMatrix) + ")";
            }
        }

        private TreeNode drawTreeView(int x_index, int y_index, int k_rule, List<Cell>[,] cellMatrix) {
            Cell cell = cellMatrix[x_index, y_index][k_rule];
            if (cell.Index_rule1 == -1) {
                TreeNode newNode = new TreeNode(cell.Rule.Term + "(" + x_index + ", " + (y_index + 1) + ")");
                string[] testingSentence = this.textBox1.Text.Split(' ');
                newNode.Nodes.Add(testingSentence[x_index]);
                return newNode;
            } else {
                TreeNode newNode = new TreeNode(cell.Rule.Term + "(" + x_index + ", " + (y_index + 1) + ")");
                newNode.Nodes.Add(drawTreeView(cell.X_cell1, cell.Y_cell1, cell.Index_rule1, cellMatrix));
                newNode.Nodes.Add(drawTreeView(cell.X_cell2, cell.Y_cell2, cell.Index_rule2, cellMatrix));
                return newNode;
            }
        }

        private void drawTree(int x_index, int y_index, int k_rule, List<Cell>[,] cellMatrix, int x_draw, int y_draw) {
            Graphics gr = Graphics.FromImage(bt);
            Cell cell = cellMatrix[x_index, y_index][k_rule];
            Font drawFont = new Font("Arial", 13);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            if (cell.Index_rule1 == -1) {
                string[] testingSentence = this.textBox1.Text.Split(' ');
                //gr.DrawString(cell.Rule.Term + "("+ x_index + ", "+ (y_index +1) + ")", drawFont, drawBrush, new Point(x_draw, y_draw));
                gr.DrawString(cell.Rule.Term , drawFont, drawBrush, new Point(x_draw, y_draw));
                gr.DrawLine(Pens.Black,new Point(x_draw,y_draw), new Point(x_draw, y_draw + v_distance));
                gr.DrawString(testingSentence[x_index], drawFont, drawBrush, new Point(x_draw, y_draw+ v_distance));
                
            } else {
                //gr.DrawString(cell.Rule.Term + "(" + x_index + ", " + (y_index + 1) + ")", drawFont, drawBrush, new Point(x_draw, y_draw));
                gr.DrawString(cell.Rule.Term , drawFont, drawBrush, new Point(x_draw, y_draw));

                int withTree = countWidthOfTree(x_index, y_index, k_rule, cellMatrix);

                //int leftTree = countWidthOfTree(cell.X_cell1, cell.Y_cell1, cell.Index_rule1, cellMatrix);
                //int rightTree = countWidthOfTree(cell.X_cell2, cell.Y_cell2, cell.Index_rule2, cellMatrix);


                gr.DrawLine(Pens.Black, new Point(x_draw, y_draw), new Point(x_draw - h_distance * (withTree / 2), y_draw + v_distance));
                gr.DrawLine(Pens.Black, new Point(x_draw, y_draw), new Point(x_draw + h_distance * (withTree / 2), y_draw + v_distance));
                drawTree(cell.X_cell1, cell.Y_cell1, cell.Index_rule1, cellMatrix, x_draw - h_distance * (withTree / 2), y_draw + v_distance);
                drawTree(cell.X_cell2, cell.Y_cell2, cell.Index_rule2, cellMatrix, x_draw + h_distance * (withTree / 2), y_draw + v_distance);

                //gr.DrawLine(Pens.Black, new Point(x_draw, y_draw), new Point(x_draw - h_distance * leftTree, y_draw + v_distance));
                //gr.DrawLine(Pens.Black, new Point(x_draw, y_draw), new Point(x_draw + h_distance * rightTree, y_draw + v_distance));
                //drawTree(cell.X_cell1, cell.Y_cell1, cell.Index_rule1, cellMatrix, x_draw - h_distance * leftTree, y_draw + v_distance);
                //drawTree(cell.X_cell2, cell.Y_cell2, cell.Index_rule2, cellMatrix, x_draw + h_distance * rightTree, y_draw + v_distance);

                //gr.DrawLine(Pens.Black, new Point(x_draw, y_draw), new Point(x_draw - h_distance, y_draw + v_distance));
                //gr.DrawLine(Pens.Black, new Point(x_draw, y_draw), new Point(x_draw + h_distance, y_draw + v_distance));
                //drawTree(cell.X_cell1, cell.Y_cell1, cell.Index_rule1, cellMatrix, x_draw - h_distance, y_draw + v_distance);
                //drawTree(cell.X_cell2, cell.Y_cell2, cell.Index_rule2, cellMatrix, x_draw + h_distance, y_draw + v_distance);

                //gr.DrawLine(Pens.Black, new Point(x_draw, y_draw), new Point(x_draw, y_draw + v_distance));
                //gr.DrawLine(Pens.Black, new Point(x_draw, y_draw), new Point(x_draw + h_distance, y_draw + v_distance));
                //drawTree(cell.X_cell1, cell.Y_cell1, cell.Index_rule1, cellMatrix, x_draw, y_draw + v_distance);
                //drawTree(cell.X_cell2, cell.Y_cell2, cell.Index_rule2, cellMatrix, x_draw + h_distance, y_draw + v_distance);
            }
        }

        private void pnTree_Paint(object sender, PaintEventArgs e) {
            e.Graphics.TranslateTransform(pnTree.AutoScrollPosition.X, pnTree.AutoScrollPosition.Y);
            if (this.textBox1.Text != "") {
                string[] testingSentence = this.textBox1.Text.Split(' ');
                for (int i = 0; i < cellMatrix[0, testingSentence.Length - 1].Count; i++) {
                    if (cellMatrix[0, testingSentence.Length - 1][i].Rule.Term.ToUpper().CompareTo("S") == 0) {
                        drawTree(0, testingSentence.Length - 1, i, cellMatrix, 200, 10);
                    }
                }
            }
        }

        private void lVListTree_SelectedIndexChanged(object sender, EventArgs e) {
            if(this.tVTree.Nodes.Count != 0 && this.lVListTree.SelectedItems.Count != 0) {
                this.tVTree.Nodes[this.lVListTree.SelectedIndices[0]].ExpandAll();
                this.pnTree.Image = null;
                string[] testingSentence = this.textBox1.Text.Split(' ');
                //bt = new Bitmap(testingSentence.Length * (h_distance + 10), countHeightOfTree(0, testingSentence.Length - 1, this.lVListTree.SelectedIndices[0], cellMatrix) * (v_distance + 10));
                bt = new Bitmap(testingSentence.Length * (h_distance + 10) * 4, countHeightOfTree(0, testingSentence.Length - 1, this.lVListTree.SelectedIndices[0], cellMatrix) * (v_distance + 10));
                //drawTree(0, testingSentence.Length - 1, this.lVListTree.SelectedIndices[0], cellMatrix, 10, 10);
                drawTree(0, testingSentence.Length - 1, this.lVListTree.SelectedIndices[0], cellMatrix, bt.Size.Width / 2, 10);
                //this.pnTree.Image = bt;



                //int leftTree = countWidthOfTree(cellMatrix[0, testingSentence.Length - 1][this.lVListTree.SelectedIndices[0]].X_cell1, cellMatrix[0, testingSentence.Length - 1][this.lVListTree.SelectedIndices[0]].Y_cell1, cellMatrix[0, testingSentence.Length - 1][this.lVListTree.SelectedIndices[0]].Index_rule1, cellMatrix);
                //int startDraw = h_distance * leftTree + 20;


                //drawTree(0, testingSentence.Length - 1, i, cellMatrix,bt.Size.Width/2, 10);
                //drawTree(0, testingSentence.Length - 1, this.lVListTree.SelectedIndices[0], cellMatrix, startDraw, 10);

                this.pnTree.Image = bt;
                this.pnTree.HorizontalScroll.Value = this.HorizontalScroll.Minimum+(this.HorizontalScroll.Maximum -this.HorizontalScroll.Minimum / 2);
                
                //this.pnTree.AutoScrollPosition = new Point(-this.HorizontalScroll.Maximum / 2, this.VerticalScroll.Maximum / 2);
                //this.pnTree.PerformLayout();
            }
        }
    }

    //REF: http://stackoverflow.com/questions/4305011/c-sharp-panel-for-drawing-graphics-and-scrolling
    class ImageBox : Panel {
            public ImageBox() {
                this.AutoScroll = true;
                this.DoubleBuffered = true;
            }
            private Image mImage;
            public Image Image {
                get { return mImage; }
                set {
                    mImage = value;
                    if (value == null) this.AutoScrollMinSize = new Size(0, 0);
                    else {
                        var size = value.Size;
                        using (var gr = this.CreateGraphics()) {
                            size.Width = (int)(size.Width * gr.DpiX / value.HorizontalResolution);
                            size.Height = (int)(size.Height * gr.DpiY / value.VerticalResolution);
                        }
                        this.AutoScrollMinSize = size;
                    }
                    this.Invalidate();
                }
            }
            protected override void OnPaint(PaintEventArgs e) {
                e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
                if (mImage != null) e.Graphics.DrawImage(mImage, 0, 0);
                base.OnPaint(e);
            }
        }
}


