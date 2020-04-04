namespace UCLM_CCS_Equiment_Reservation_System
{
    partial class PopUpTransactionID
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopUpTransactionID));
            this.label19 = new System.Windows.Forms.Label();
            this.txtIDNumber = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnReturnedEquipment = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Purple;
            this.label19.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(135, 46);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(136, 36);
            this.label19.TabIndex = 64;
            this.label19.Text = "NUMBER";
            // 
            // txtIDNumber
            // 
            this.txtIDNumber.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDNumber.Location = new System.Drawing.Point(84, 107);
            this.txtIDNumber.Multiline = true;
            this.txtIDNumber.Name = "txtIDNumber";
            this.txtIDNumber.Size = new System.Drawing.Size(192, 25);
            this.txtIDNumber.TabIndex = 98;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBack.Location = new System.Drawing.Point(96, 152);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 31);
            this.btnBack.TabIndex = 99;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnReturnedEquipment
            // 
            this.btnReturnedEquipment.BackColor = System.Drawing.Color.Transparent;
            this.btnReturnedEquipment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReturnedEquipment.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnedEquipment.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReturnedEquipment.Location = new System.Drawing.Point(177, 152);
            this.btnReturnedEquipment.Name = "btnReturnedEquipment";
            this.btnReturnedEquipment.Size = new System.Drawing.Size(75, 31);
            this.btnReturnedEquipment.TabIndex = 100;
            this.btnReturnedEquipment.Text = "ENTER";
            this.btnReturnedEquipment.UseVisualStyleBackColor = false;
            this.btnReturnedEquipment.Click += new System.EventHandler(this.BtnReturnedEquipment_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(90, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 36);
            this.label3.TabIndex = 66;
            this.label3.Text = "ID";
            // 
            // PopUpTransactionID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(357, 205);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnReturnedEquipment);
            this.Controls.Add(this.txtIDNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label19);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PopUpTransactionID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PopUpTransactionID";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PopUpTransactionID_FormClosing);
            this.Load += new System.EventHandler(this.PopUpTransactionID_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnReturnedEquipment;
        private System.Windows.Forms.Label label3;
        protected internal System.Windows.Forms.TextBox txtIDNumber;
    }
}