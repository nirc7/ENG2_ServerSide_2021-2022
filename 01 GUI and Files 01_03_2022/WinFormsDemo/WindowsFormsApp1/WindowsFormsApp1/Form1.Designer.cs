
namespace WindowsFormsApp1
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
            this.btnSayHello = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.cmbNumbers = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSayHello
            // 
            this.btnSayHello.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSayHello.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnSayHello.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSayHello.Location = new System.Drawing.Point(116, 95);
            this.btnSayHello.Name = "btnSayHello";
            this.btnSayHello.Size = new System.Drawing.Size(140, 41);
            this.btnSayHello.TabIndex = 0;
            this.btnSayHello.Text = "Say Hello";
            this.btnSayHello.UseVisualStyleBackColor = false;
            this.btnSayHello.Click += new System.EventHandler(this.btnSayHello_Click);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtName.Location = new System.Drawing.Point(116, 58);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(140, 26);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "insert ur name";
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(51, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "NAME:";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblResult.Location = new System.Drawing.Point(116, 163);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(21, 20);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "...";
            // 
            // cmbNumbers
            // 
            this.cmbNumbers.FormattingEnabled = true;
            this.cmbNumbers.Items.AddRange(new object[] {
            "One",
            "Two",
            "Three"});
            this.cmbNumbers.Location = new System.Drawing.Point(116, 248);
            this.cmbNumbers.Name = "cmbNumbers";
            this.cmbNumbers.Size = new System.Drawing.Size(121, 21);
            this.cmbNumbers.TabIndex = 4;
            this.cmbNumbers.SelectedIndexChanged += new System.EventHandler(this.cmbNumbers_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbNumbers);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnSayHello);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSayHello;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ComboBox cmbNumbers;
    }
}

