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
    class InputText : Input
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
        string text = string.Empty;
        public InputText(Vector2 pixelPos, int width, int height) : base(pixelPos, width, height) { }
        public InputText(Vector2 pixelPos, int width, int height, Padding padding) : base(pixelPos, width, height, padding) { }
        char accent = ' ';
        public override void Write()
        {
            var c = (char)GetKeyPressed();
         
            switch (c)
            {
                case (char)0: break;
                case (char)39: accent = '`'; break;
                case (char)91: accent = '^'; break;
                case (char)259: Text = Text.Length > 0 ? Text[0..^1] : string.Empty; break;
                default:
                    if (c >= 'A' && c <= 'Z' || c >= '0' && c <= '9' || c == ' '|| c == 47)
                    {
                        c = (c, accent) switch
                        {
                            ('A', '`') => 'À',
                            ('E', '`') => 'È',
                            ('I', '`') => 'Ì',
                            ('O', '`') => 'Ò',
                            ('U', '`') => 'Ù',
                            ('A', '^') => 'Â',
                            ('E', '^') => 'Ê',
                            ('I', '^') => 'Î',
                            ('O', '^') => 'Ô',
                            ('U', '^') => 'Û',
                            ((char)47, _) => 'É',
                            _ => c
                        };;
                        Text += IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT) || IsKeyDown(KeyboardKey.KEY_RIGHT_SHIFT) ?
                            c : c.ToString().ToLower();
                        accent = ' ';
                    }
                    break;
            }
            WrittenText = Text;
        }
    }
}
