namespace PCKY
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSentence = new System.Windows.Forms.TextBox();
            this.lVListTree = new System.Windows.Forms.ListView();
            this.no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.structures = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.tVTree = new System.Windows.Forms.TreeView();
            this.pnTextBoxMatrix = new System.Windows.Forms.Panel();
            this.btnExcute = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pnTree = new PCKY.ImagePanel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSentence
            // 
            this.txtSentence.Location = new System.Drawing.Point(74, 9);
            this.txtSentence.Name = "txtSentence";
            this.txtSentence.Size = new System.Drawing.Size(239, 20);
            this.txtSentence.TabIndex = 0;
            this.txtSentence.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // lVListTree
            // 
            this.lVListTree.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.no,
            this.structures});
            this.lVListTree.FullRowSelect = true;
            this.lVListTree.Location = new System.Drawing.Point(6, 19);
            this.lVListTree.Name = "lVListTree";
            this.lVListTree.Size = new System.Drawing.Size(262, 260);
            this.lVListTree.TabIndex = 4;
            this.lVListTree.UseCompatibleStateImageBehavior = false;
            this.lVListTree.View = System.Windows.Forms.View.Details;
            this.lVListTree.SelectedIndexChanged += new System.EventHandler(this.lVListTree_SelectedIndexChanged);
            // 
            // no
            // 
            this.no.Text = "No.";
            // 
            // structures
            // 
            this.structures.Text = "Structures";
            this.structures.Width = 400;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sentence:";
            // 
            // tVTree
            // 
            this.tVTree.Location = new System.Drawing.Point(6, 19);
            this.tVTree.Name = "tVTree";
            this.tVTree.Size = new System.Drawing.Size(202, 254);
            this.tVTree.TabIndex = 5;
            // 
            // pnTextBoxMatrix
            // 
            this.pnTextBoxMatrix.AutoScroll = true;
            this.pnTextBoxMatrix.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnTextBoxMatrix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnTextBoxMatrix.Location = new System.Drawing.Point(6, 19);
            this.pnTextBoxMatrix.Name = "pnTextBoxMatrix";
            this.pnTextBoxMatrix.Size = new System.Drawing.Size(496, 230);
            this.pnTextBoxMatrix.TabIndex = 6;
            // 
            // btnExcute
            // 
            this.btnExcute.Location = new System.Drawing.Point(334, 9);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(75, 23);
            this.btnExcute.TabIndex = 7;
            this.btnExcute.Text = "Excute";
            this.btnExcute.UseVisualStyleBackColor = true;
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lVListTree);
            this.groupBox1.Location = new System.Drawing.Point(8, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 285);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List form";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tVTree);
            this.groupBox2.Location = new System.Drawing.Point(302, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 285);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Treeview form";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pnTextBoxMatrix);
            this.groupBox3.Location = new System.Drawing.Point(8, 324);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(510, 255);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PCKY Table";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pnTree);
            this.groupBox4.Location = new System.Drawing.Point(524, 33);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(885, 546);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Graph";
            // 
            // pnTree
            // 
            this.pnTree.AutoScroll = true;
            this.pnTree.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnTree.Image = null;
            this.pnTree.Location = new System.Drawing.Point(6, 19);
            this.pnTree.Name = "pnTree";
            this.pnTree.Size = new System.Drawing.Size(873, 521);
            this.pnTree.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1424, 592);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnExcute);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSentence);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PCKY Algorithm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSentence;
        private ImagePanel pnTree;
        private System.Windows.Forms.ListView lVListTree;
        private System.Windows.Forms.ColumnHeader no;
        private System.Windows.Forms.ColumnHeader structures;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tVTree;
        private System.Windows.Forms.Panel pnTextBoxMatrix;
        private System.Windows.Forms.Button btnExcute;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

