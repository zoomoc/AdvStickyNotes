using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdvStickyNotes
{
    public partial class StickyNote : Form
    {
        RichTextBox textBox1;
        Button closeBtn;
        Button addBtn;

        public StickyNote()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(248,247,182);
        }

        private void StickyNote_Load(object sender, EventArgs e)
        {
            textBox1 = new RichTextBox();
            textBox1.Location = new Point(0, 20);
            textBox1.Width = Size.Width;
            textBox1.Height = Size.Height;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.BackColor = Color.FromArgb(248, 247, 182);

            closeBtn = new Button();
            closeBtn.Location = new Point(Size.Width-20, 0);
            closeBtn.Size = new Size(20, 20);
            closeBtn.Text = "X";
            closeBtn.Click += CloseBtn_Click;
            closeBtn.FlatStyle = FlatStyle.Flat;
            closeBtn.FlatAppearance.BorderSize = 0;

            addBtn = new Button();
            addBtn.Location = new Point(0, 0);
            addBtn.Size = new Size(20, 20);
            addBtn.Text = "+";
            addBtn.Click += AddBtn_Click;
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.FlatAppearance.BorderSize = 0;

            

            this.Controls.Add(textBox1);
            this.Controls.Add(closeBtn);
            this.Controls.Add(addBtn);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            new StickyNote().Show();

        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        
    }
}
