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
            this.label1 = new System.Windows.Forms.Label();
            this.lbTreesListForm = new System.Windows.Forms.Label();
            this.pnTree = new PCKY.ImageBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(239, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Trees (list-form):";
            // 
            // lbTreesListForm
            // 
            this.lbTreesListForm.AutoSize = true;
            this.lbTreesListForm.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbTreesListForm.Location = new System.Drawing.Point(356, 15);
            this.lbTreesListForm.Name = "lbTreesListForm";
            this.lbTreesListForm.Size = new System.Drawing.Size(0, 13);
            this.lbTreesListForm.TabIndex = 2;
            // 
            // pnTree
            // 
            this.pnTree.AutoScroll = true;
            this.pnTree.AutoSize = true;
            this.pnTree.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnTree.Image = null;
            this.pnTree.Location = new System.Drawing.Point(12, 38);
            this.pnTree.Name = "pnTree";
            this.pnTree.Size = new System.Drawing.Size(655, 411);
            this.pnTree.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(679, 461);
            this.Controls.Add(this.pnTree);
            this.Controls.Add(this.lbTreesListForm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTreesListForm;
        private ImageBox pnTree;
    }
}

