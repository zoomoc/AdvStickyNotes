using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdvStickyNotes
{
    [Serializable]
    public partial class AdvStickyNotes : Form
    {
        List<StickyNote> stickyNotes;
        public AdvStickyNotes()
        {
            InitializeComponent();

            FormClosing += AdvStickyNotes_FormClosing;
        }

        private void AdvStickyNotes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (stickyNotes.Count() == 0) return;
            try
            {
                Stream data = new FileStream("data.dat", FileMode.Create);
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(data, stickyNotes);
                data.Close();
                MessageBox.Show("저장 완료!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("파일 저장 오류!\n오류메시지: " + ex.Message);
            }
        }

        private void StickyNote_Shown(object sender, EventArgs e)
        {
            Size = new Size(0, 0);
            Visible = false;
            ShowInTaskbar = true;

            stickyNotes = new List<StickyNote>(); 
            stickyNotes.Add(new StickyNote(this));
            stickyNotes[0].Show();
        }

        public bool closeNote(StickyNote note)
        {
            stickyNotes.Remove(note);
            if(stickyNotes.Count() == 0)
            {
                Close();
            }
            return true;
        }

        public void addNote()
        {
            stickyNotes.Add(new StickyNote(this));
            stickyNotes.Last<StickyNote>().Show();
        }
        
    }
}
