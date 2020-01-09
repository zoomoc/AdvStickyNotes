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
using Threading = System.Threading;

namespace AdvStickyNotes
{
    public partial class AdvStickyNotes : Form
    {
        public List<StickyNote> stickyNotes;
        private Stream data;
        private BinaryFormatter serializer;
        private Timer saveTimer;
        private bool isInitialized = false;
        public AdvStickyNotes()
        {
            InitializeComponent();

            saveTimer = new Timer();
            saveTimer.Interval = 2000;
            saveTimer.Tick += SaveTimer_Tick;

            serializer = new BinaryFormatter();
            data = new FileStream("data.dat", FileMode.OpenOrCreate);
            if (data.Length != 0)
            {
                List<NoteData> noteDatas = new List<NoteData>((List<NoteData>)serializer.Deserialize(data));
                stickyNotes = new List<StickyNote>();

                foreach (NoteData noteData in noteDatas)
                {
                    stickyNotes.Add(new StickyNote(this, noteData));
                }
                MessageBox.Show("불러오기 완료!");
            }
            data.Close();
        }
        private void AdvStickyNotes_Shown(object sender, EventArgs e)
        {
            Size = new Size(0, 0);
            Visible = false;
            ShowInTaskbar = true;

            if (stickyNotes == null)
            {
                stickyNotes = new List<StickyNote>();
                stickyNotes.Add(new StickyNote(this));
                stickyNotes.First().Show();
            }
            else
            {
                foreach(StickyNote stickyNote in stickyNotes)
                {
                    stickyNote.Show();
                }
            }

            isInitialized = true;
        }
        public void saveData(StickyNote sender)
        {
            if (isInitialized == false) return;
            saveTimer.Stop();
            saveTimer.Start();
        }
        private void SaveTimer_Tick(object sender, EventArgs e)
        {
            saveTimer.Stop();

            List<NoteData> noteDatas = new List<NoteData>();
            foreach (StickyNote stickyNote in stickyNotes)
            {
                noteDatas.Add(stickyNote.noteData);
            }
            data = new FileStream("data.dat", FileMode.OpenOrCreate);
            serializer.Serialize(data, noteDatas);
            data.Close();

            MessageBox.Show("저장!");

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
            stickyNotes.Last().Show();
        }

        public void deleteNote(StickyNote stickyNote)
        {

        }
    }
}
