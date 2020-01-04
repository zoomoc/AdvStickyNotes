using System;
using System.Drawing;

namespace AdvStickyNotes
{
    public class NoteData
    {
        public Point notePos;
        public string noteText;
        public NoteData(Point pos, string text)
        {
            notePos = pos;
            noteText = text;
        }
    }
}
