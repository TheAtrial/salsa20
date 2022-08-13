namespace WindowsFormsApplication2
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
            this.encrypt_button = new System.Windows.Forms.Button();
            this.upload_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.key_textBox = new System.Windows.Forms.TextBox();
            this.nonce_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.input_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // encrypt_button
            // 
            this.encrypt_button.Location = new System.Drawing.Point(167, 161);
            this.encrypt_button.Name = "encrypt_button";
            this.encrypt_button.Size = new System.Drawing.Size(143, 23);
            this.encrypt_button.TabIndex = 0;
            this.encrypt_button.Text = "Encrypt/Decrypt";
            this.encrypt_button.UseVisualStyleBackColor = true;
            this.encrypt_button.Click += new System.EventHandler(this.encrypt_button_Click);
            // 
            // upload_button
            // 
            this.upload_button.Location = new System.Drawing.Point(12, 161);
            this.upload_button.Name = "upload_button";
            this.upload_button.Size = new System.Drawing.Size(149, 23);
            this.upload_button.TabIndex = 1;
            this.upload_button.Text = "Open input file";
            this.upload_button.UseVisualStyleBackColor = true;
            this.upload_button.Click += new System.EventHandler(this.upload_button_Click);
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(316, 161);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(142, 23);
            this.save_button.TabIndex = 2;
            this.save_button.Text = "Save result file";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // key_textBox
            // 
            this.key_textBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.key_textBox.Location = new System.Drawing.Point(12, 66);
            this.key_textBox.MaxLength = 64;
            this.key_textBox.Multiline = true;
            this.key_textBox.Name = "key_textBox";
            this.key_textBox.Size = new System.Drawing.Size(447, 36);
            this.key_textBox.TabIndex = 3;
            this.key_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key_textBox_KeyPress);
            // 
            // nonce_textBox
            // 
            this.nonce_textBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nonce_textBox.Location = new System.Drawing.Point(12, 130);
            this.nonce_textBox.MaxLength = 16;
            this.nonce_textBox.Name = "nonce_textBox";
            this.nonce_textBox.Size = new System.Drawing.Size(446, 20);
            this.nonce_textBox.TabIndex = 4;
            this.nonce_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key_textBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Key (HEX, 16, 32 bytes)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nonce (HEX, 8 bytes)";
            // 
            // input_textBox
            // 
            this.input_textBox.Location = new System.Drawing.Point(12, 27);
            this.input_textBox.Name = "input_textBox";
            this.input_textBox.ReadOnly = true;
            this.input_textBox.Size = new System.Drawing.Size(446, 20);
            this.input_textBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Input file ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 194);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.input_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nonce_textBox);
            this.Controls.Add(this.key_textBox);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.upload_button);
            this.Controls.Add(this.encrypt_button);
            this.MaximumSize = new System.Drawing.Size(487, 233);
            this.MinimumSize = new System.Drawing.Size(487, 233);
            this.Name = "Form1";
            this.Text = "Salsa20";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button encrypt_button;
        private System.Windows.Forms.Button upload_button;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.TextBox key_textBox;
        private System.Windows.Forms.TextBox nonce_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox input_textBox;
        private System.Windows.Forms.Label label3;
    }
}

