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
    [Serializable]
    public partial class AdvStickyNotes : Form
    {
        public List<StickyNote> stickyNotes;
        private Stream data;
        [NonSerialized] private Threading.Timer saveTimer;
        public AdvStickyNotes()
        {
            InitializeComponent();
        }
        private void AdvStickyNotes_Load(object sender, EventArgs e)
        {
            try
            {
                data = new FileStream("data.dat", FileMode.OpenOrCreate);
                if (data.Length == 0) return;
                
                BinaryFormatter serializer = new BinaryFormatter();
                stickyNotes = (List<StickyNote>)serializer.Deserialize(data);
                data.Close();
                MessageBox.Show("불러오기 완료!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("저장된 데이터 읽기 오류!\n오류메시지: " + ex.Message);
                throw ex;
            }

            saveTimer = new System.Threading.Timer(new System.Threading.TimerCallback(saveTimerProc));
        }
        private void AdvStickyNotes_Shown(object sender, EventArgs e)
        {
            Size = new Size(0, 0);
            Visible = false;
            ShowInTaskbar = true;

            stickyNotes = new List<StickyNote>(); 
            stickyNotes.Add(new StickyNote(this));
            stickyNotes[0].Show();
        }
        public void saveData()
        {
            //saveTimer.Change     -------------여기 작성중이야!
        }
        private void saveTimerProc(object state)
        {
            Threading.Timer t = (Threading.Timer) state;
            
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
