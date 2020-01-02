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
    public partial class AdvStickyNotes : Form
    {
        List<StickyNote> stickyNotes;
        public AdvStickyNotes()
        {
            InitializeComponent();
            stickyNotes = new List<StickyNote>();
            Visible = false;
        }

        private void StickyNote_Shown(object sender, EventArgs e)
        {
            stickyNotes.Add(new StickyNote(this));
            stickyNotes[0].Show();
            Size = new Size(0, 0);
            
            MessageBox.Show("첫 메모 창을 띄우고 다음 코드를 실행했어요");
            
        }

        public bool closeNote()
        {
            return false;
        }

        public void addNote()
        {
            stickyNotes.Add(new StickyNote(this));
            stickyNotes.Last<StickyNote>().Show();
            MessageBox.Show("노트 갯수: "+stickyNotes.Count()+"개!");
        }
        
    }
}
