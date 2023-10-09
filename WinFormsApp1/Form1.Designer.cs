namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public EventHandler newLoad { get; private set; }
        public SizeF newAutoScaleDimensions { get; private set; }
        public AutoScaleMode newAutoScaleMode { get; private set; }
        public Size newClientSize { get; private set; }
        public string newName { get; private set; }
        public string newText { get; private set; }

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            numericUpDownLines = new NumericUpDown();
            numericUpDownRectangles = new NumericUpDown();
            numericUpDownEllipses = new NumericUpDown();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button2 = new Button();
            menuStrip1 = new MenuStrip();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLines).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRectangles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEllipses).BeginInit();
            SuspendLayout();
            // 
            // numericUpDownLines
            // 
            numericUpDownLines.Location = new Point(12, 51);
            numericUpDownLines.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownLines.Name = "numericUpDownLines";
            numericUpDownLines.Size = new Size(120, 23);
            numericUpDownLines.TabIndex = 0;
            numericUpDownLines.ValueChanged += numericUpDownLines_ValueChanged;
            // 
            // numericUpDownRectangles
            // 
            numericUpDownRectangles.Location = new Point(154, 51);
            numericUpDownRectangles.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownRectangles.Name = "numericUpDownRectangles";
            numericUpDownRectangles.Size = new Size(120, 23);
            numericUpDownRectangles.TabIndex = 1;
            numericUpDownRectangles.ValueChanged += numericUpDownRectangles_ValueChanged;
            // 
            // numericUpDownEllipses
            // 
            numericUpDownEllipses.Location = new Point(291, 51);
            numericUpDownEllipses.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownEllipses.Name = "numericUpDownEllipses";
            numericUpDownEllipses.Size = new Size(120, 23);
            numericUpDownEllipses.TabIndex = 2;
            numericUpDownEllipses.ValueChanged += numericUpDownEllipses_ValueChanged;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Location = new Point(12, 551);
            button1.Name = "button1";
            button1.Size = new Size(127, 48);
            button1.TabIndex = 3;
            button1.Text = "Отрисовать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonDraw_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(154, 584);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 31);
            label2.MaximumSize = new Size(40, 40);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 5;
            label2.Text = "Lines";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(178, 31);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 6;
            label3.Text = "Rectangles";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(323, 31);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 7;
            label4.Text = "Ellipses";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.Location = new Point(12, 494);
            button2.Name = "button2";
            button2.Size = new Size(127, 51);
            button2.TabIndex = 8;
            button2.Text = "Стоп";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonStop_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1201, 24);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button3.Location = new Point(12, 437);
            button3.Name = "button3";
            button3.Size = new Size(127, 51);
            button3.TabIndex = 10;
            button3.Text = "Статистика";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1201, 611);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(numericUpDownEllipses);
            Controls.Add(numericUpDownRectangles);
            Controls.Add(numericUpDownLines);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "DrawFast";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownLines).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRectangles).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEllipses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numericUpDownLines;
        private NumericUpDown numericUpDownRectangles;
        private NumericUpDown numericUpDownEllipses;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button2;
        private MenuStrip menuStrip1;
        private Button button3;
    }
}
