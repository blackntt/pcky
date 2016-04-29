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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lVListTree = new System.Windows.Forms.ListView();
            this.no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.structures = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.tVTree = new System.Windows.Forms.TreeView();
            this.pnTree = new PCKY.ImageBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(74, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(239, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // lVListTree
            // 
            this.lVListTree.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.no,
            this.structures});
            this.lVListTree.FullRowSelect = true;
            this.lVListTree.Location = new System.Drawing.Point(12, 38);
            this.lVListTree.Name = "lVListTree";
            this.lVListTree.Size = new System.Drawing.Size(339, 156);
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
            this.tVTree.Location = new System.Drawing.Point(12, 200);
            this.tVTree.Name = "tVTree";
            this.tVTree.Size = new System.Drawing.Size(339, 324);
            this.tVTree.TabIndex = 5;
            // 
            // pnTree
            // 
            this.pnTree.AutoScroll = true;
            this.pnTree.AutoSize = true;
            this.pnTree.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnTree.Image = null;
            this.pnTree.Location = new System.Drawing.Point(357, 38);
            this.pnTree.Name = "pnTree";
            this.pnTree.Size = new System.Drawing.Size(634, 623);
            this.pnTree.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1444, 631);
            this.Controls.Add(this.tVTree);
            this.Controls.Add(this.lVListTree);
            this.Controls.Add(this.pnTree);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "PCKY Algorithm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private ImageBox pnTree;
        private System.Windows.Forms.ListView lVListTree;
        private System.Windows.Forms.ColumnHeader no;
        private System.Windows.Forms.ColumnHeader structures;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tVTree;
    }
}

