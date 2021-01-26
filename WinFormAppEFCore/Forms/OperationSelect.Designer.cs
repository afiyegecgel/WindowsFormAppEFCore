namespace WinFormAppEFCore
{
    partial class OperationSelect
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnProductOperations = new System.Windows.Forms.Button();
            this.btnCategoryOperations = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(75, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Click on the option you want to manage.";
            // 
            // btnProductOperations
            // 
            this.btnProductOperations.Location = new System.Drawing.Point(78, 68);
            this.btnProductOperations.Name = "btnProductOperations";
            this.btnProductOperations.Size = new System.Drawing.Size(222, 23);
            this.btnProductOperations.TabIndex = 0;
            this.btnProductOperations.Text = "Products";
            this.btnProductOperations.UseVisualStyleBackColor = true;
            this.btnProductOperations.Click += new System.EventHandler(this.btnProductOperations_Click);
            // 
            // btnCategoryOperations
            // 
            this.btnCategoryOperations.Location = new System.Drawing.Point(78, 97);
            this.btnCategoryOperations.Name = "btnCategoryOperations";
            this.btnCategoryOperations.Size = new System.Drawing.Size(222, 23);
            this.btnCategoryOperations.TabIndex = 1;
            this.btnCategoryOperations.Text = "Categories";
            this.btnCategoryOperations.UseVisualStyleBackColor = true;
            this.btnCategoryOperations.Click += new System.EventHandler(this.btnCategoryOperations_Click);
            // 
            // OperationSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 162);
            this.Controls.Add(this.btnCategoryOperations);
            this.Controls.Add(this.btnProductOperations);
            this.Controls.Add(this.label1);
            this.Name = "OperationSelect";
            this.Text = "OperationSelect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProductOperations;
        private System.Windows.Forms.Button btnCategoryOperations;
    }
}