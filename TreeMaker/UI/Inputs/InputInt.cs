using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Raylib_cs.Raylib;
using Raylib_cs;

namespace TreeMaker.UI.Inputs
{
    class InputInt : Input
    {
        public string Text
        {
            get => text;
            set 
            {
                text = value;
                WrittenText = text;
            }
        }
        string text = "0";
        public int Value => int.Parse(Text);
        public InputInt(Vector2 pixelPos, int width, int height) : base(pixelPos, width, height)
        { WrittenText = Text; }
        public override void Write()
        {
            var key = (KeyboardKey)GetKeyPressed();
            switch (key)
            {
                case KeyboardKey.KEY_BACKSPACE: Text = Text.Length > 0 ? Text[0..^1] : string.Empty; break;
                default:
                    char c = (char)key;
                    if (c >= '0' && c <= '9')
                        Text += c;
                    break;
            }
            WrittenText = Text;
        }
    }
}
