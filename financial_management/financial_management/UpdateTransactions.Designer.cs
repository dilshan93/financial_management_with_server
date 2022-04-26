namespace financial_management
{
    partial class UpdateTransactions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateTransactions));
            this.comTransCategory = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkWeekly = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTransDate = new System.Windows.Forms.DateTimePicker();
            this.btnAddTransaction = new System.Windows.Forms.Button();
            this.txtTransAmount = new System.Windows.Forms.TextBox();
            this.comTransType = new System.Windows.Forms.ComboBox();
            this.txtTransName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comTransCategory
            // 
            this.comTransCategory.FormattingEnabled = true;
            this.comTransCategory.Location = new System.Drawing.Point(171, 173);
            this.comTransCategory.Name = "comTransCategory";
            this.comTransCategory.Size = new System.Drawing.Size(121, 24);
            this.comTransCategory.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Amount";
            // 
            // chkWeekly
            // 
            this.chkWeekly.AutoSize = true;
            this.chkWeekly.Location = new System.Drawing.Point(171, 288);
            this.chkWeekly.Name = "chkWeekly";
            this.chkWeekly.Size = new System.Drawing.Size(75, 20);
            this.chkWeekly.TabIndex = 23;
            this.chkWeekly.Text = "Weekly";
            this.chkWeekly.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Repete";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Choose Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Choose Date";
            // 
            // dtpTransDate
            // 
            this.dtpTransDate.CustomFormat = "dd-MM-yyyy";
            this.dtpTransDate.Location = new System.Drawing.Point(171, 32);
            this.dtpTransDate.Name = "dtpTransDate";
            this.dtpTransDate.Size = new System.Drawing.Size(191, 22);
            this.dtpTransDate.TabIndex = 17;
            // 
            // btnAddTransaction
            // 
            this.btnAddTransaction.Location = new System.Drawing.Point(421, 60);
            this.btnAddTransaction.Name = "btnAddTransaction";
            this.btnAddTransaction.Size = new System.Drawing.Size(103, 85);
            this.btnAddTransaction.TabIndex = 16;
            this.btnAddTransaction.Text = "Submit";
            this.btnAddTransaction.UseVisualStyleBackColor = true;
            this.btnAddTransaction.Click += new System.EventHandler(this.Update_Transaction);
            // 
            // txtTransAmount
            // 
            this.txtTransAmount.Location = new System.Drawing.Point(171, 233);
            this.txtTransAmount.Name = "txtTransAmount";
            this.txtTransAmount.Size = new System.Drawing.Size(160, 22);
            this.txtTransAmount.TabIndex = 15;
            this.txtTransAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateAmountFeild);
            // 
            // comTransType
            // 
            this.comTransType.FormattingEnabled = true;
            this.comTransType.Items.AddRange(new object[] {
            "Income",
            "Expense"});
            this.comTransType.Location = new System.Drawing.Point(171, 126);
            this.comTransType.Name = "comTransType";
            this.comTransType.Size = new System.Drawing.Size(121, 24);
            this.comTransType.TabIndex = 14;
            // 
            // txtTransName
            // 
            this.txtTransName.Location = new System.Drawing.Point(171, 78);
            this.txtTransName.Name = "txtTransName";
            this.txtTransName.Size = new System.Drawing.Size(191, 22);
            this.txtTransName.TabIndex = 13;
            // 
            // UpdateTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 346);
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
            this.Name = "UpdateTransactions";
            this.Text = "Update Transactions";
            this.Load += new System.EventHandler(this.UpdateTransactions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comTransCategory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkWeekly;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTransDate;
        private System.Windows.Forms.Button btnAddTransaction;
        private System.Windows.Forms.TextBox txtTransAmount;
        private System.Windows.Forms.ComboBox comTransType;
        private System.Windows.Forms.TextBox txtTransName;
    }
}