namespace Donation_Management_System
{
    partial class ForgotPwd
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
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            label2 = new Label();
            textBox2 = new TextBox();
            button2 = new Button();
            label3 = new Label();
            label4 = new Label();
            textBox3 = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label14 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(154, 200);
            label1.Name = "label1";
            label1.Size = new Size(70, 25);
            label1.TabIndex = 0;
            label1.Text = "UserId";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(360, 192);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(349, 33);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(218, 500);
            button1.Name = "button1";
            button1.Size = new Size(132, 55);
            button1.TabIndex = 2;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(154, 264);
            label2.Name = "label2";
            label2.Size = new Size(558, 25);
            label2.TabIndex = 3;
            label2.Text = "Security Question: To whom did you donate for the first time?";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(360, 316);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(349, 33);
            textBox2.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(651, 500);
            button2.Name = "button2";
            button2.Size = new Size(119, 55);
            button2.TabIndex = 6;
            button2.Text = "Back";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(154, 324);
            label3.Name = "label3";
            label3.Size = new Size(157, 25);
            label3.TabIndex = 4;
            label3.Text = "Security Answer";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(154, 389);
            label4.Name = "label4";
            label4.Size = new Size(151, 25);
            label4.TabIndex = 7;
            label4.Text = "Reset Password";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(360, 381);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(349, 33);
            textBox3.TabIndex = 8;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.IndianRed;
            label5.Location = new Point(67, 57);
            label5.Name = "label5";
            label5.Size = new Size(897, 22);
            label5.TabIndex = 9;
            label5.Text = "In case you forgot your password, type your userId and security answer you provided while creating the account.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.IndianRed;
            label6.Location = new Point(98, 88);
            label6.Name = "label6";
            label6.Size = new Size(833, 22);
            label6.TabIndex = 10;
            label6.Text = "Then reset your password. If your security answer matches, your password will be reset and you will be";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.IndianRed;
            label7.Location = new Point(297, 119);
            label7.Name = "label7";
            label7.Size = new Size(427, 22);
            label7.TabIndex = 11;
            label7.Text = "logged into your account after you press login button.";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Red;
            label8.Location = new Point(715, 384);
            label8.Name = "label8";
            label8.Size = new Size(0, 20);
            label8.TabIndex = 12;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(308, 417);
            label14.Name = "label14";
            label14.Size = new Size(437, 20);
            label14.TabIndex = 32;
            label14.Text = "(Password must contain !, @ or # and at least 8 characters)";
            // 
            // ForgotPwd
            // 
            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1078, 644);
            Controls.Add(label14);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "ForgotPwd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ForgotPwd";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Label label2;
        private TextBox textBox2;
        private Button button2;
        private Label label3;
        private Label label4;
        private TextBox textBox3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label14;
    }
}