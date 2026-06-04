namespace DonationManagementSystem
{
    partial class DonationHistory
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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            label1 = new Label();
            hScrollBar1 = new HScrollBar();
            vScrollBar1 = new VScrollBar();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 63);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1154, 557);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(974, 649);
            button1.Name = "button1";
            button1.Size = new Size(132, 52);
            button1.TabIndex = 1;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.BackColor = SystemColors.GrayText;
            label1.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(1154, 51);
            label1.TabIndex = 2;
            label1.Text = "YOUR DONATION HISTORY";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // hScrollBar1
            // 
            hScrollBar1.Location = new Point(12, 592);
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(1154, 28);
            hScrollBar1.TabIndex = 3;
            // 
            // vScrollBar1
            // 
            vScrollBar1.Location = new Point(1141, 63);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(25, 529);
            vScrollBar1.TabIndex = 4;
            // 
            // DonationHistory
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1182, 753);
            Controls.Add(vScrollBar1);
            Controls.Add(hScrollBar1);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "DonationHistory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DonationHistory";
            Load += DonationHistory_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Label label1;
        private HScrollBar hScrollBar1;
        private VScrollBar vScrollBar1;
    }
}