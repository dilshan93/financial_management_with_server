namespace financial_management
{
    partial class Transactions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transactions));
            this.txtTransName = new System.Windows.Forms.TextBox();
            this.comTransType = new System.Windows.Forms.ComboBox();
            this.txtTransAmount = new System.Windows.Forms.TextBox();
            this.btnAddTransaction = new System.Windows.Forms.Button();
            this.dtpTransDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkWeekly = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comTransCategory = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtTransName
            // 
            this.txtTransName.Location = new System.Drawing.Point(165, 101);
            this.txtTransName.Name = "txtTransName";
            this.txtTransName.Size = new System.Drawing.Size(191, 22);
            this.txtTransName.TabIndex = 1;
            // 
            // comTransType
            // 
            this.comTransType.FormattingEnabled = true;
            this.comTransType.Items.AddRange(new object[] {
            "Income",
            "Expense"});
            this.comTransType.Location = new System.Drawing.Point(165, 149);
            this.comTransType.Name = "comTransType";
            this.comTransType.Size = new System.Drawing.Size(121, 24);
            this.comTransType.TabIndex = 1;
            // 
            // txtTransAmount
            // 
            this.txtTransAmount.Location = new System.Drawing.Point(165, 256);
            this.txtTransAmount.Name = "txtTransAmount";
            this.txtTransAmount.Size = new System.Drawing.Size(160, 22);
            this.txtTransAmount.TabIndex = 2;
            this.txtTransAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateAmountFeild);
            // 
            // btnAddTransaction
            // 
            this.btnAddTransaction.Location = new System.Drawing.Point(415, 83);
            this.btnAddTransaction.Name = "btnAddTransaction";
            this.btnAddTransaction.Size = new System.Drawing.Size(103, 85);
            this.btnAddTransaction.TabIndex = 3;
            this.btnAddTransaction.Text = "Submit";
            this.btnAddTransaction.UseVisualStyleBackColor = true;
            this.btnAddTransaction.Click += new System.EventHandler(this.Submit_Transaction);
            // 
            // dtpTransDate
            // 
            this.dtpTransDate.CustomFormat = "dd-MM-yyyy";
            this.dtpTransDate.Location = new System.Drawing.Point(165, 55);
            this.dtpTransDate.Name = "dtpTransDate";
            this.dtpTransDate.Size = new System.Drawing.Size(191, 22);
            this.dtpTransDate.TabIndex = 0;
            this.dtpTransDate.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Choose Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name";
            this.label2.Click += new System.EventHandler(this.Submit_Transaction);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Choose Category";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Repete";
            // 
            // chkWeekly
            // 
            this.chkWeekly.AutoSize = true;
            this.chkWeekly.Location = new System.Drawing.Point(165, 311);
            this.chkWeekly.Name = "chkWeekly";
            this.chkWeekly.Size = new System.Drawing.Size(75, 20);
            this.chkWeekly.TabIndex = 10;
            this.chkWeekly.Text = "Weekly";
            this.chkWeekly.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Amount";
            // 
            // comTransCategory
            // 
            this.comTransCategory.FormattingEnabled = true;
            this.comTransCategory.Location = new System.Drawing.Point(165, 196);
            this.comTransCategory.Name = "comTransCategory";
            this.comTransCategory.Size = new System.Drawing.Size(121, 24);
            this.comTransCategory.TabIndex = 12;
            // 
            // Transactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 409);
            this.Controls.Add(this.comTransCategory);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkWeekly);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpTransDate);
            this.Controls.Add(this.btnAddTransaction);
            this.Controls.Add(this.txtTransAmount);
            this.Controls.Add(this.comTransType);
            this.Controls.Add(this.txtTransName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Transactions";
            this.Text = "Add New Transactions";
            this.Load += new System.EventHandler(this.Load_Categories);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTransName;
        private System.Windows.Forms.ComboBox comTransType;
        private System.Windows.Forms.TextBox txtTransAmount;
        private System.Windows.Forms.Button btnAddTransaction;
        private System.Windows.Forms.DateTimePicker dtpTransDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkWeekly;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comTransCategory;
    }
}