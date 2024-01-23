using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Button = TreeMaker.UI.Buttons.Button;
using static TreeMaker.Settings.UserSettings;
using static Raylib_cs.Raylib;
using TreeMaker.Settings;
using Color = Raylib_cs.Color;
using static TreeMaker.Utils.Text;

namespace TreeMaker.UI
{
    class ArrayIndexChooser : UI
    {
        readonly string[] Array;
        int index;
        public static readonly int Width = ScreenWidth/5;
        public static readonly int Height = ScreenHeight/10;
        readonly ArrowButton left;
        readonly ArrowButton right;
        readonly Display disp;
        public ArrayIndexChooser(int posX, int posY, string[] choices) 
        {
            Array = choices;
            index = 0;
            disp = new(posX, posY, Width, Height, this);
            left = new(true, new(posX - UI_BUFFER - Height, posY), Height, this);
            right = new(false, new(posX + Width + UI_BUFFER, posY), Height, this);
        }
        public void LeftPressed()
        {
            if (index == 0)
                index = Array.Length - 1;
            else --index;
        }
        public void RightPressed()
        {
            if (index == Array.Length - 1)
                index = 0;
            else ++index;
        }
        public string GetVal() => Array[index];
        public override void Draw()
        {
            //nothing here since all the components draw themselves
        }

        public override void Update()
        {
            left.Update();
            right.Update();
            disp.Draw();
        }
        class ArrowButton : Button
        {
            readonly Vector2 v1;
            readonly Vector2 v2;
            readonly Vector2 v3;
            readonly static Color ArrowColor = Colors[(int)ColorTypes.Text];
            public ArrowButton(bool left, Vector2 pos, int width, ArrayIndexChooser array) : 
                base(string.Empty, left ? array.LeftPressed : array.RightPressed)
            {
                PixelPos = pos;
                Width = width;
                Height = width;
                TopLeft = PixelPos;
                BottomRight = PixelPos + new Vector2(Width, Height);
                TextSize = Height / 3;
                if (left)
                {
                    v1 = pos + new Vector2(Width, Height) - Vector2.One * UI_BUFFER;
                    v2 = pos + new Vector2(Width - UI_BUFFER, UI_BUFFER);
                    v3 = pos + new Vector2(UI_BUFFER, Height / 2);
                }
                else
                {
                    v3 = pos + new Vector2(UI_BUFFER, Height - UI_BUFFER);
                    v2 = pos + Vector2.One * UI_BUFFER;
                    v1 = pos + new Vector2(Width - UI_BUFFER, Height / 2);
                }
            }
            public override void Draw()
            {
                base.Draw();
                DrawTriangle(v1, v2, v3, ArrowColor);
            }
        }
        class Display : UI
        {
            readonly int PosX;
            readonly int PosY;
            readonly int Width;
            readonly int Height;
            Func<string> getText;
            Color color = Colors[(int)ColorTypes.Secondary2];
            public Display(int posX, int posY, int width, int height, ArrayIndexChooser array) 
            {
                PosX = posX; 
                PosY = posY;
                Width = width;
                Height = height;
                getText = array.GetVal;
            }
            public override void Draw()
            {
                DrawRectangle(PosX, PosY, Width, Height, color);
                WriteCentered(getText(), Height / 3, new(PosX, PosY), new(Width, Height));
            }
            public override void Update()
            {
                //nothing here since it just draws;
            }
        }
    }
}
