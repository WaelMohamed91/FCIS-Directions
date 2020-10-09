namespace DXApplication1
{
    partial class update
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
            this.update_button = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.picture_box = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.text_location = new DevExpress.XtraEditors.TextEdit();
            this.text_name = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_lastname = new DevExpress.XtraEditors.TextEdit();
            this.label_last = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.text_location.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.text_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_lastname.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // update_button
            // 
            this.update_button.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.update_button.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update_button.Appearance.Options.UseBackColor = true;
            this.update_button.Appearance.Options.UseFont = true;
            this.update_button.Location = new System.Drawing.Point(991, 547);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(79, 40);
            this.update_button.TabIndex = 17;
            this.update_button.Text = "Save";
            this.update_button.Click += new System.EventHandler(this.update_button_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseBackColor = true;
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(906, 547);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(79, 40);
            this.simpleButton2.TabIndex = 16;
            this.simpleButton2.Text = "Done";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(346, 102);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(30, 22);
            this.simpleButton1.TabIndex = 15;
            this.simpleButton1.Text = "...";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(-13, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1096, 41);
            this.panel1.TabIndex = 14;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label5.Location = new System.Drawing.Point(1051, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 24);
            this.label5.TabIndex = 21;
            this.label5.Text = "X";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(25, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Update";
            // 
            // picture_box
            // 
            this.picture_box.BackgroundImage = global::DXApplication1.Properties.Resources.defaultMap;
            this.picture_box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_box.Location = new System.Drawing.Point(3, 152);
            this.picture_box.Name = "picture_box";
            this.picture_box.Size = new System.Drawing.Size(1067, 389);
            this.picture_box.TabIndex = 13;
            this.picture_box.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Location :";
            // 
            // text_location
            // 
            this.text_location.Location = new System.Drawing.Point(162, 104);
            this.text_location.Name = "text_location";
            this.text_location.Size = new System.Drawing.Size(182, 20);
            this.text_location.TabIndex = 11;
            // 
            // text_name
            // 
            this.text_name.Enabled = false;
            this.text_name.Location = new System.Drawing.Point(162, 58);
            this.text_name.Name = "text_name";
            this.text_name.Size = new System.Drawing.Size(182, 20);
            this.text_name.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Name  :";
            // 
            // txt_lastname
            // 
            this.txt_lastname.Enabled = false;
            this.txt_lastname.Location = new System.Drawing.Point(494, 60);
            this.txt_lastname.Name = "txt_lastname";
            this.txt_lastname.Size = new System.Drawing.Size(182, 20);
            this.txt_lastname.TabIndex = 19;
            this.txt_lastname.Visible = false;
            // 
            // label_last
            // 
            this.label_last.AutoSize = true;
            this.label_last.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_last.Location = new System.Drawing.Point(378, 58);
            this.label_last.Name = "label_last";
            this.label_last.Size = new System.Drawing.Size(110, 20);
            this.label_last.TabIndex = 18;
            this.label_last.Text = "Last Name  :";
            this.label_last.Visible = false;
            // 
            // update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 590);
            this.Controls.Add(this.txt_lastname);
            this.Controls.Add(this.label_last);
            this.Controls.Add(this.update_button);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picture_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_location);
            this.Controls.Add(this.text_name);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "update";
            this.Text = "update";
            this.Load += new System.EventHandler(this.update_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.text_location.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.text_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_lastname.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton update_button;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picture_box;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit text_location;
        private DevExpress.XtraEditors.TextEdit text_name;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txt_lastname;
        private System.Windows.Forms.Label label_last;
        private System.Windows.Forms.Label label5;
    }
}