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
        AdvStickyNotes parent;
        private bool isMouseDown;
        private Point mouseDownPoint;
        private int titleHeight = 30;

        RichTextBox textBox;
        public NoteData noteData;

        public StickyNote(AdvStickyNotes p, NoteData nd = new NoteData())
        {

            InitializeComponent();
            
            BackColor = Color.FromArgb(253, 253, 201);
            Visible = true;

            parent = p;

            //드래그해서 창 이동하기 구현
            Panel mover = new Panel
            {
                Location = new Point(0, 0),
                Width = Size.Width,
                Height = titleHeight,
                BackColor = Color.FromArgb(248, 247, 182)
            };
            isMouseDown = false;
            mover.MouseDown += Mover_MouseDown;
            mover.MouseMove += Mover_MouseMove;
            mover.MouseUp += Mover_MouseUp;


            //메모 영역 텍스트박스
            textBox = new RichTextBox
            {
                Location = new Point(0, titleHeight),
                Width = Size.Width,
                Height = Size.Height,
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(253, 253, 201)
            };
            textBox.TextChanged += TextBox_TextChanged;

            //닫기 버튼
            Button closeBtn = new Button
            {
                Location = new Point(Size.Width - titleHeight, 0),
                Size = new Size(titleHeight, titleHeight),
                Text = "X",
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(248, 247, 182)
            };
            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.Click += CloseBtn_Click;
            
            //메모 추가 버튼
            Button addBtn = new Button
            {
                Location = new Point(0, 0),
                Size = new Size(titleHeight, titleHeight),
                Text = "+",
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(248, 247, 182)
            };
            addBtn.FlatAppearance.BorderSize = 0;
            addBtn.Click += AddBtn_Click;

            this.Controls.Add(mover);
            this.Controls.Add(textBox);
            this.Controls.Add(closeBtn);
            this.Controls.Add(addBtn);
            mover.SendToBack();

            if(noteData == null)
            {
                noteData = new NoteData(Location, textBox.Text);
            }

            FormClosed += StickyNote_FormClosed;
        }

        public void saveData()
        {
            noteData.notePos = Location;
            noteData.noteText = textBox.Text;

            parent.saveData(this, noteData);
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            saveData();
        }

        private void StickyNote_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.closeNote(this);
        }

        private void Mover_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            saveData();
        }

        private void Mover_MouseMove(object sender, MouseEventArgs e)
        {
            if(isMouseDown == false) { return; }
            int x = Location.X + (e.Location.X - mouseDownPoint.X);
            int y = Location.Y + (e.Location.Y - mouseDownPoint.Y);
            Location = new Point(x, y);
        }

        private void Mover_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownPoint = e.Location;
            isMouseDown = true;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            parent.addNote();
        }
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();       
        }
    }
}
