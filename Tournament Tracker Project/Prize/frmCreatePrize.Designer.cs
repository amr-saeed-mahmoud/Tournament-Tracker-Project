namespace Tournament_Tracker_Project
{
    partial class frmCreatePrize
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
            this.components = new System.ComponentModel.Container();
            this.lbCreatePrize = new System.Windows.Forms.Label();
            this.txtPlaceNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPlaceName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrizeAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrizePercentage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCreatePrize = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCreatePrize
            // 
            this.lbCreatePrize.AutoSize = true;
            this.lbCreatePrize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.lbCreatePrize.Location = new System.Drawing.Point(11, 10);
            this.lbCreatePrize.Name = "lbCreatePrize";
            this.lbCreatePrize.Size = new System.Drawing.Size(135, 31);
            this.lbCreatePrize.TabIndex = 3;
            this.lbCreatePrize.Text = "Create Prize";
            // 
            // txtPlaceNumber
            // 
            this.txtPlaceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaceNumber.Location = new System.Drawing.Point(166, 94);
            this.txtPlaceNumber.Name = "txtPlaceNumber";
            this.txtPlaceNumber.Size = new System.Drawing.Size(204, 27);
            this.txtPlaceNumber.TabIndex = 22;
            this.txtPlaceNumber.Validating += new System.ComponentModel.CancelEventHandler(this.ValidNumber);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(24, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 22);
            this.label3.TabIndex = 23;
            this.label3.Text = "Place Number";
            // 
            // txtPlaceName
            // 
            this.txtPlaceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaceName.Location = new System.Drawing.Point(166, 145);
            this.txtPlaceName.Name = "txtPlaceName";
            this.txtPlaceName.Size = new System.Drawing.Size(204, 27);
            this.txtPlaceName.TabIndex = 24;
            this.txtPlaceName.Validating += new System.ComponentModel.CancelEventHandler(this.txtPlaceName_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(24, 146);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 22);
            this.label2.TabIndex = 25;
            this.label2.Text = "Place Name";
            // 
            // txtPrizeAmount
            // 
            this.txtPrizeAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrizeAmount.Location = new System.Drawing.Point(166, 194);
            this.txtPrizeAmount.Name = "txtPrizeAmount";
            this.txtPrizeAmount.Size = new System.Drawing.Size(204, 27);
            this.txtPrizeAmount.TabIndex = 26;
            this.txtPrizeAmount.TextChanged += new System.EventHandler(this.txtPrizeAmount_TextChanged);
            this.txtPrizeAmount.Validating += new System.ComponentModel.CancelEventHandler(this.txtPrizeAmount_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(24, 196);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 22);
            this.label4.TabIndex = 27;
            this.label4.Text = "Prize Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(241, 245);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 32);
            this.label6.TabIndex = 28;
            this.label6.Text = "-or-";
            // 
            // txtPrizePercentage
            // 
            this.txtPrizePercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrizePercentage.Location = new System.Drawing.Point(166, 299);
            this.txtPrizePercentage.Name = "txtPrizePercentage";
            this.txtPrizePercentage.Size = new System.Drawing.Size(204, 27);
            this.txtPrizePercentage.TabIndex = 29;
            this.txtPrizePercentage.TextChanged += new System.EventHandler(this.txtPrizePercentage_TextChanged);
            this.txtPrizePercentage.Validating += new System.ComponentModel.CancelEventHandler(this.txtPrizePercentage_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.label5.Location = new System.Drawing.Point(10, 299);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 22);
            this.label5.TabIndex = 30;
            this.label5.Text = "Prize Percentage";
            // 
            // btnCreatePrize
            // 
            this.btnCreatePrize.BackColor = System.Drawing.Color.White;
            this.btnCreatePrize.FlatAppearance.BorderSize = 2;
            this.btnCreatePrize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleTurquoise;
            this.btnCreatePrize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnCreatePrize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatePrize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreatePrize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnCreatePrize.Location = new System.Drawing.Point(129, 367);
            this.btnCreatePrize.Name = "btnCreatePrize";
            this.btnCreatePrize.Size = new System.Drawing.Size(156, 41);
            this.btnCreatePrize.TabIndex = 31;
            this.btnCreatePrize.Text = "Create Prize";
            this.btnCreatePrize.UseVisualStyleBackColor = false;
            this.btnCreatePrize.Click += new System.EventHandler(this.btnCreatePrize_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmCreatePrize
            // 
            this.AcceptButton = this.btnCreatePrize;
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(416, 445);
            this.Controls.Add(this.btnCreatePrize);
            this.Controls.Add(this.txtPrizePercentage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPrizeAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPlaceName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPlaceNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbCreatePrize);
            this.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmCreatePrize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Prize";
            this.Load += new System.EventHandler(this.frmCreatePrize_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCreatePrize;
        private System.Windows.Forms.TextBox txtPlaceNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPlaceName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrizeAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrizePercentage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCreatePrize;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}