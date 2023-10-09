using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WinFormsApp1;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private Stopwatch stopwatch = new Stopwatch();
        private int numLines = 0;
        private int numRectangles = 0;
        private int numEllipses = 0;
        private bool isDrawing = false;
        private List<string> drawHistory = new List<string>();
        private bool isDrawingCompl = false;
        private enum DifficultyLevel
        {
            Free,
            Easy,
            Medium,
            Hard
        }

        private DifficultyLevel currentDifficultyLevel = DifficultyLevel.Free;

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        public Form1()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
            this.FormClosing += Form1_FormClosing!;
        }
        public class StatisticsForm : Form
        {
            public StatisticsForm(List<string> drawHistory)
            {
                DataGridView dataGridView = new DataGridView();
                dataGridView.Dock = DockStyle.Fill;
                dataGridView.RowHeadersVisible = false;
                dataGridView.AllowUserToAddRows = false;
                dataGridView.AllowUserToDeleteRows = false;
                dataGridView.ReadOnly = true;

                // Создание столбцов таблицы
                dataGridView.Columns.Add("Lines", "Lines");
                dataGridView.Columns.Add("Rectangles", "Rectangles");
                dataGridView.Columns.Add("Ellipses", "Ellipses");
                dataGridView.Columns.Add("DrawTime", "Draw Time");
                dataGridView.Columns.Add("AverageDrawTime", "Average Draw Time");

                // Заполнение таблицы данными из drawHistory
                foreach (string entry in drawHistory)
                {
                    string[] values = entry.Split(',');

                    // Получите время отрисовки из записи
                    float drawTime = float.Parse(values[3].Trim().Split(' ')[2]);

                    // Добавьте среднее значение времени отрисовки в массив значений
                    string[] newValues = new string[values.Length + 1];
                    Array.Copy(values, newValues, values.Length);
                    newValues[newValues.Length - 1] = (drawTime / drawHistory.Count).ToString("F3") + " ms";

                    dataGridView.Rows.Add(newValues);
                }

                Controls.Add(dataGridView);

                this.Text = "Статистика";
                this.Size = new Size(500, 400);
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isDrawing)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите закрыть окно? Процесс рисования будет остановлен.", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            stopwatch.Stop();
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            isDrawing = true;
            isDrawingCompl = false; 
            stopwatch.Reset();
            stopwatch.Start();
            Invalidate();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            isDrawing = false;
            Invalidate();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Создание и отображение формы статистики
            StatisticsForm statisticsForm = new StatisticsForm(drawHistory);
            statisticsForm.ShowDialog();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Draw speed:";

            ToolStripMenuItem fileMenuItem = new ToolStripMenuItem("File");
            ToolStripMenuItem saveToolStripMenuItem = new ToolStripMenuItem("Save");
            fileMenuItem.DropDownItems.Add(saveToolStripMenuItem);
            ToolStripMenuItem openToolStripMenuItem = new ToolStripMenuItem("Open");
            fileMenuItem.DropDownItems.Add(openToolStripMenuItem);
            ToolStripMenuItem clearToolStripMenuItem = new ToolStripMenuItem("Clear");
            fileMenuItem.DropDownItems.Add(clearToolStripMenuItem);
            menuStrip1.Items.Add(fileMenuItem);

            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            clearToolStripMenuItem.Click += ClearToolStripMenuItem_Click;

            RadioButton radioButtonFree = new RadioButton();
            radioButtonFree.Text = "Свободный режим";
            radioButtonFree.Location = new Point(10, 85);
            radioButtonFree.CheckedChanged += RadioButtonDifficulty_CheckedChanged;
            Controls.Add(radioButtonFree);

            RadioButton radioButtonEasy = new RadioButton();
            radioButtonEasy.Text = "Легкий режим";
            radioButtonEasy.Location = new Point(10, 110);
            radioButtonEasy.CheckedChanged += RadioButtonDifficulty_CheckedChanged;
            Controls.Add(radioButtonEasy);

            RadioButton radioButtonMedium = new RadioButton();
            radioButtonMedium.Text = "Средний режим";
            radioButtonMedium.Location = new Point(10, 135);
            radioButtonMedium.CheckedChanged += RadioButtonDifficulty_CheckedChanged;
            Controls.Add(radioButtonMedium);

            RadioButton radioButtonHard = new RadioButton();
            radioButtonHard.Text = "Сложный режим";
            radioButtonHard.Location = new Point(10, 160);
            radioButtonHard.CheckedChanged += RadioButtonDifficulty_CheckedChanged;
            Controls.Add(radioButtonHard);

            radioButtonFree.Checked = true;
        }

        private void RadioButtonDifficulty_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton.Checked)
            {
                switch (radioButton.Text)
                {
                    case "Свободный режим":
                        currentDifficultyLevel = DifficultyLevel.Free;
                        numericUpDownLines.Enabled = true;
                        numericUpDownRectangles.Enabled = true;
                        numericUpDownEllipses.Enabled = true;
                        break;
                    case "Легкий режим":
                        currentDifficultyLevel = DifficultyLevel.Easy;
                        numericUpDownLines.Enabled = false;
                        numericUpDownRectangles.Enabled = false;
                        numericUpDownEllipses.Enabled = false;
                        numericUpDownLines.Value = 2000;
                        numericUpDownRectangles.Value = 2000;
                        numericUpDownEllipses.Value = 2000;
                        break;
                    case "Средний режим":
                        currentDifficultyLevel = DifficultyLevel.Medium;
                        numericUpDownLines.Enabled = false;
                        numericUpDownRectangles.Enabled = false;
                        numericUpDownEllipses.Enabled = false;
                        numericUpDownLines.Value = 6000;
                        numericUpDownRectangles.Value = 6000;
                        numericUpDownEllipses.Value = 6000;
                        break;
                    case "Сложный режим":
                        currentDifficultyLevel = DifficultyLevel.Hard;
                        numericUpDownLines.Enabled = false;
                        numericUpDownRectangles.Enabled = false;
                        numericUpDownEllipses.Enabled = false;
                        numericUpDownLines.Value = 10000;
                        numericUpDownRectangles.Value = 10000;
                        numericUpDownEllipses.Value = 10000;
                        break;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!isDrawing)
            {
                e.Graphics.Clear(Color.White);
                return;
            }
            Rectangle clipRect = new Rectangle(160, 60, ClientSize.Width - 150, ClientSize.Height - 10);
            e.Graphics.SetClip(clipRect);
            int lineLength = 300;
            for (int i = 0; i < numLines; i++)
            {
                int x1 = random.Next(ClientSize.Width);
                int y1 = random.Next(ClientSize.Height);
                double angle = random.NextDouble() * 2 * Math.PI;
                int x2 = x1 + (int)(lineLength * Math.Cos(angle));
                int y2 = y1 + (int)(lineLength * Math.Sin(angle));
                using (Pen pen = new Pen(Color.Red, 1))
                {
                    e.Graphics.DrawLine(pen, x1, y1, x2, y2);
                }
            }
            for (int i = 0; i < numRectangles; i++)
            {
                int x = random.Next(ClientSize.Width);
                int y = random.Next(ClientSize.Height);
                int w = 70;
                int h = 80;
                using (Brush brush = new SolidBrush(Color.Green))
                {
                    e.Graphics.FillRectangle(brush, x, y, w, h);
                }
            }
            for (int i = 0; i < numEllipses; i++)
            {
                int x = random.Next(ClientSize.Width);
                int y = random.Next(ClientSize.Height);
                int w = 60;
                int h = 70;

                using (Brush brush = new SolidBrush(Color.Blue))
                {
                    e.Graphics.FillEllipse(brush, x, y, w, h);
                }
            }
            if (isDrawing && !isDrawingCompl)
            {
                float drawTime = (float)stopwatch.ElapsedTicks / Stopwatch.Frequency * 1000;
                label1.Text = $"Draw speed: {drawTime:F3} ms";

                // Сохранение времени рисования
                string historyEntry = $"Lines: {numLines}, Rectangles: {numRectangles}, Ellipses: {numEllipses}, Draw Time: {drawTime:F3} ms";
                drawHistory.Add(historyEntry);

                stopwatch.Stop();
                isDrawingCompl = true; // Установите флаг, что рисование завершено
            }
        }

        private void numericUpDownLines_ValueChanged(object sender, EventArgs e)
        {
            numLines = (int)numericUpDownLines.Value;
        }

        private void numericUpDownRectangles_ValueChanged(object sender, EventArgs e)
        {
            numRectangles = (int)numericUpDownRectangles.Value;
        }

        private void numericUpDownEllipses_ValueChanged(object sender, EventArgs e)
        {
            numEllipses = (int)numericUpDownEllipses.Value;
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (string entry in drawHistory)
                    {
                        writer.WriteLine(entry);
                    }
                }
                MessageBox.Show("История рисования сохранена.");
            }
        }
        public class TextDisplayForm : Form
        {
            public TextDisplayForm(string text)
            {
                TextBox textBox = new TextBox();
                textBox.Multiline = true;
                textBox.ReadOnly = true;
                textBox.ScrollBars = ScrollBars.Vertical;
                textBox.Dock = DockStyle.Fill;
                textBox.Text = text;

                Controls.Add(textBox);

                this.Text = "История рисования";
                this.Size = new Size(500, 400);
            }
        }
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isDrawing)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text Files (*.txt)|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string fileContent = reader.ReadToEnd();

                        // Открытие новой формы для отображения текста
                        TextDisplayForm textDisplayForm = new TextDisplayForm(fileContent);
                        textDisplayForm.ShowDialog();
                    }
                    MessageBox.Show("История рисования загружена.");
                }
            }
            else
            {
                MessageBox.Show("Остановите процесс рисования перед открытием истории рисования.");
            }
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawHistory.Clear();
            MessageBox.Show("История рисования очищена.");
        }
    }
}