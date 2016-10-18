namespace RenameMails
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
            this.renameAll = new System.Windows.Forms.Button();
            this.rename = new System.Windows.Forms.Button();
            this.move = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // renameAll
            // 
            this.renameAll.Location = new System.Drawing.Point(182, 4);
            this.renameAll.Name = "renameAll";
            this.renameAll.Size = new System.Drawing.Size(128, 23);
            this.renameAll.TabIndex = 0;
            this.renameAll.Text = "remove whitespace";
            this.renameAll.UseVisualStyleBackColor = true;
            this.renameAll.Click += new System.EventHandler(this.RenameAllClick);
            // 
            // rename
            // 
            this.rename.Location = new System.Drawing.Point(182, 31);
            this.rename.Name = "rename";
            this.rename.Size = new System.Drawing.Size(128, 23);
            this.rename.TabIndex = 3;
            this.rename.Text = "replace umlauts";
            this.rename.UseVisualStyleBackColor = true;
            this.rename.Click += new System.EventHandler(this.RenameClick);
            // 
            // move
            // 
            this.move.Location = new System.Drawing.Point(182, 57);
            this.move.Name = "move";
            this.move.Size = new System.Drawing.Size(128, 23);
            this.move.TabIndex = 5;
            this.move.Text = "organize attachments";
            this.move.UseVisualStyleBackColor = true;
            this.move.Click += new System.EventHandler(this.MoveClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Move all attachments to folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Remove only umlauts";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Remove all whitespaces";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 88);
            this.Controls.Add(this.move);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rename);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.renameAll);
            this.Name = "Form1";
            this.Text = "PM tool for mails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button renameAll;
        private System.Windows.Forms.Button rename;
        private System.Windows.Forms.Button move;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

