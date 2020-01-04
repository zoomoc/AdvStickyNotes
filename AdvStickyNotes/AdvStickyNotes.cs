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
        public AdvStickyNotes()
        {
            InitializeComponent();
        }
        private void AdvStickyNotes_Load(object sender, EventArgs e)
        {
            serializer = new BinaryFormatter();
            try
            {
                data = new FileStream("data.dat", FileMode.OpenOrCreate);
                if (data.Length != 0)
                {
                    stickyNotes = (List<StickyNote>)serializer.Deserialize(data);
                    MessageBox.Show("불러오기 완료!");
                }
                data.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("저장된 데이터 읽기 오류!\n오류메시지: " + ex.Message);
                throw ex;
            }

            saveTimer = new Timer();
            saveTimer.Interval = 2000;
            saveTimer.Tick += SaveTimer_Tick;
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
                stickyNotes[0].Show();
            }
            else
            {
                foreach(StickyNote stickyNote in stickyNotes)
                {
                    stickyNote.Show();
                }
            }
        }
        public void saveData(NoteData noteData)
        {
            saveTimer.Stop();
            saveTimer.Start();
        }
        private void SaveTimer_Tick(object sender, EventArgs e)
        {
            saveTimer.Stop();
            data = new FileStream("data.dat", FileMode.OpenOrCreate);
            serializer.Serialize(data, stickyNotes);
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
            stickyNotes.Last<StickyNote>().Show();
        }
    }
}
