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
        }

        private void StickyNote_Shown(object sender, EventArgs e)
        {
            stickyNotes.Add(new StickyNote());
            stickyNotes[0].Show();
            Size = new Size(0, 0);
            
            MessageBox.Show("첫 메모 창을 띄우고 다음 코드를 실행했어요");
            
        }

        public void deleteNote()
        {
            stickyNotes
        }

        public void addStickyNote()
        {
            //new StickyNote().Show();
        }
        
    }
}
