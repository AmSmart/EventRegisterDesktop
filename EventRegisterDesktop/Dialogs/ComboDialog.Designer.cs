namespace EventRegisterDesktop.Dialogs
{
    partial class ComboDialog
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
            this.btnOkay = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.textName = new System.Windows.Forms.TextBox();
            this.radioDyanmic = new System.Windows.Forms.RadioButton();
            this.radioStatic = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textLink = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOkay
            // 
            this.btnOkay.Location = new System.Drawing.Point(15, 121);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(75, 23);
            this.btnOkay.TabIndex = 4;
            this.btnOkay.Text = "Okay";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(105, 121);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(38, 20);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(100, 20);
            this.textName.TabIndex = 0;
            this.textName.TextChanged += new System.EventHandler(this.textName_TextChanged);
            // 
            // radioDyanmic
            // 
            this.radioDyanmic.AutoSize = true;
            this.radioDyanmic.Location = new System.Drawing.Point(38, 69);
            this.radioDyanmic.Name = "radioDyanmic";
            this.radioDyanmic.Size = new System.Drawing.Size(66, 17);
            this.radioDyanmic.TabIndex = 3;
            this.radioDyanmic.TabStop = true;
            this.radioDyanmic.Text = "Dynamic";
            this.radioDyanmic.UseVisualStyleBackColor = true;
            this.radioDyanmic.CheckedChanged += new System.EventHandler(this.radioDyanmic_CheckedChanged);
            // 
            // radioStatic
            // 
            this.radioStatic.AutoSize = true;
            this.radioStatic.Location = new System.Drawing.Point(38, 46);
            this.radioStatic.Name = "radioStatic";
            this.radioStatic.Size = new System.Drawing.Size(52, 17);
            this.radioStatic.TabIndex = 2;
            this.radioStatic.TabStop = true;
            this.radioStatic.Text = "Static";
            this.radioStatic.UseVisualStyleBackColor = true;
            this.radioStatic.CheckedChanged += new System.EventHandler(this.radioStatic_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(46, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter name here";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textLink
            // 
            this.textLink.Enabled = false;
            this.textLink.Location = new System.Drawing.Point(38, 95);
            this.textLink.Name = "textLink";
            this.textLink.Size = new System.Drawing.Size(100, 20);
            this.textLink.TabIndex = 6;
            this.textLink.TextChanged += new System.EventHandler(this.textLink_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(46, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Enter link here";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // ComboDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(198, 154);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textLink);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioStatic);
            this.Controls.Add(this.radioDyanmic);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOkay);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComboDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configure";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.RadioButton radioDyanmic;
        private System.Windows.Forms.RadioButton radioStatic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textLink;
        private System.Windows.Forms.Label label2;
    }
}