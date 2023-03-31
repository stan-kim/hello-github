namespace QRCodePrint
{
    partial class PopupMSG
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
            this.lb_ERROR_MSG = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_ERROR_MSG
            // 
            this.lb_ERROR_MSG.Font = new System.Drawing.Font("굴림", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_ERROR_MSG.ForeColor = System.Drawing.Color.Red;
            this.lb_ERROR_MSG.Location = new System.Drawing.Point(-1, 0);
            this.lb_ERROR_MSG.Name = "lb_ERROR_MSG";
            this.lb_ERROR_MSG.Size = new System.Drawing.Size(532, 146);
            this.lb_ERROR_MSG.TabIndex = 0;
            this.lb_ERROR_MSG.Text = "Error MSG";
            this.lb_ERROR_MSG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.Color.White;
            this.btn_OK.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_OK.Location = new System.Drawing.Point(403, 149);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(116, 41);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "확 인";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // PopupMSG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(532, 198);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.lb_ERROR_MSG);
            this.Name = "PopupMSG";
            this.Text = "PopupMSG";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_ERROR_MSG;
        private System.Windows.Forms.Button btn_OK;
    }
}