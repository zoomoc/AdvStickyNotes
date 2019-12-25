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
        TextBox textBox1;
        Button closeBtn;


        public StickyNote()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(248,247,182);
        }

        private void StickyNote_Load(object sender, EventArgs e)
        {
            textBox1 = new TextBox();
            textBox1.Width = 200;
            textBox1.Height = 100;

            closeBtn = new Button();
            closeBtn.Location = new Point(200, 0);
            closeBtn.Size = new Size(20, 20);
            closeBtn.Text = "X";
            closeBtn.Click += CloseBtn_Click;

            this.Controls.Add(textBox1);
            this.Controls.Add(closeBtn);
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Form senderForm = sender as Form;
            senderForm.Close();
            throw new NotImplementedException();
        }
        
    }
}
