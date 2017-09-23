namespace finview
{
    partial class Dashboard
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgTransaction = new System.Windows.Forms.DataGridView();
            this.ChkColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TransactionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Narration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WithdrawalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepositAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClosingBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTransaction)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgTransaction, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.03738F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.96262F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(903, 535);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgTransaction
            // 
            this.dgTransaction.AllowUserToAddRows = false;
            this.dgTransaction.AllowUserToDeleteRows = false;
            this.dgTransaction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTransaction.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChkColumn,
            this.TransactionDate,
            this.Narration,
            this.WithdrawalAmount,
            this.DepositAmount,
            this.ClosingBalance,
            this.cbCategory});
            this.dgTransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTransaction.Location = new System.Drawing.Point(3, 3);
            this.dgTransaction.Name = "dgTransaction";
            this.dgTransaction.RowHeadersVisible = false;
            this.dgTransaction.Size = new System.Drawing.Size(897, 464);
            this.dgTransaction.TabIndex = 0;
            // 
            // ChkColumn
            // 
            this.ChkColumn.FillWeight = 20F;
            this.ChkColumn.HeaderText = "";
            this.ChkColumn.Name = "ChkColumn";
            // 
            // TransactionDate
            // 
            this.TransactionDate.DataPropertyName = "TransactionDate";
            this.TransactionDate.FillWeight = 89.26595F;
            this.TransactionDate.HeaderText = "TransactionDate";
            this.TransactionDate.Name = "TransactionDate";
            this.TransactionDate.ReadOnly = true;
            // 
            // Narration
            // 
            this.Narration.DataPropertyName = "Narration";
            this.Narration.FillWeight = 357.0638F;
            this.Narration.HeaderText = "Narration";
            this.Narration.Name = "Narration";
            this.Narration.ReadOnly = true;
            // 
            // WithdrawalAmount
            // 
            this.WithdrawalAmount.DataPropertyName = "WithdrawalAmount";
            this.WithdrawalAmount.FillWeight = 89.26595F;
            this.WithdrawalAmount.HeaderText = "WithdrawalAmount";
            this.WithdrawalAmount.Name = "WithdrawalAmount";
            this.WithdrawalAmount.ReadOnly = true;
            // 
            // DepositAmount
            // 
            this.DepositAmount.DataPropertyName = "DepositAmount";
            this.DepositAmount.FillWeight = 89.26595F;
            this.DepositAmount.HeaderText = "DepositAmount";
            this.DepositAmount.Name = "DepositAmount";
            this.DepositAmount.ReadOnly = true;
            // 
            // ClosingBalance
            // 
            this.ClosingBalance.DataPropertyName = "ClosingBalance";
            this.ClosingBalance.FillWeight = 89.26595F;
            this.ClosingBalance.HeaderText = "ClosingBalance";
            this.ClosingBalance.Name = "ClosingBalance";
            this.ClosingBalance.ReadOnly = true;
            // 
            // cbCategory
            // 
            this.cbCategory.DataPropertyName = "CategoryId";
            this.cbCategory.FillWeight = 89.26595F;
            this.cbCategory.HeaderText = "Category";
            this.cbCategory.Name = "cbCategory";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 473);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(897, 59);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 535);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTransaction)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dgTransaction;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ChkColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Narration;
        private System.Windows.Forms.DataGridViewTextBoxColumn WithdrawalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepositAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClosingBalance;
        private System.Windows.Forms.DataGridViewComboBoxColumn cbCategory;
    }
}