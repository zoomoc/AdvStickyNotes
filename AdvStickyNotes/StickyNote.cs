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
        public StickyNote(AdvStickyNotes p)
        {
            InitializeComponent();
            BackColor = Color.FromArgb(248, 247, 182);
            Visible = true;

            parent = p;

            //드래그해서 창 이동하기 구현
            Panel mover = new Panel
            {
                Location = new Point(0, 0),
                Width = Size.Width,
                Height = 20,
                BackColor = Color.FromArgb(0, 247, 182)
            };

            //메모 영역 텍스트박스
            RichTextBox textBox = new RichTextBox
            {
                Location = new Point(0, 20),
                Width = Size.Width,
                Height = Size.Height,
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(248, 247, 182)
            };

            //닫기 버튼
            Button closeBtn = new Button
            {
                Location = new Point(Size.Width - 20, 0),
                Size = new Size(20, 20),
                Text = "X",
                FlatStyle = FlatStyle.Flat
            };
            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.Click += CloseBtn_Click;
            
            //메모 추가 버튼
            Button addBtn = new Button
            {
                Location = new Point(0, 0),
                Size = new Size(20, 20),
                Text = "+",
                FlatStyle = FlatStyle.Flat
            };
            addBtn.FlatAppearance.BorderSize = 0;
            addBtn.Click += AddBtn_Click;

            this.Controls.Add(mover);
            this.Controls.Add(textBox);
            this.Controls.Add(closeBtn);
            this.Controls.Add(addBtn);
            mover.SendToBack();
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            parent.addNote();
        }
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            if (parent.closeNote())
            {
                Close();
            }
            else
            {
                throw new Exception("오류 발생!\n노트 닫기 동작이 정상적으로 수행되지 않았습니다.");
            }
            
        }
    }
}
