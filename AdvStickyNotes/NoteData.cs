using System;
using System.Drawing;

namespace AdvStickyNotes
{
    [Serializable]
    public class NoteData
    {
        public Point notePos;
        public string noteText;
        public NoteData(Point pos = new Point(), string text = "")
        {
            notePos = pos;
            noteText = text;
        }
    }
}
