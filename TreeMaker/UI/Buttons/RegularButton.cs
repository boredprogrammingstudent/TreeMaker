using Raylib_cs;
using static Raylib_cs.Raylib;
using static TreeMaker.Settings.UserSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeMaker.Settings;
using static TreeMaker.Utils.Text;
using System.Numerics;

namespace TreeMaker.UI.Buttons
{
    class RegularButton : Button
    {
        public static readonly int HeightModifier = 10;
        public static readonly int NbButtons = 8;
        public RegularButton(int index, string text, Action OnClick) : base(text, OnClick)
        {
            Width = ScreenWidth / NbButtons - (NbButtons + 1) * UI_BUFFER;
            Height = ScreenHeight / HeightModifier;
            TextSize = Height / 3 - HeightModifier;
            PixelPos = new(ScreenWidth - (index + 1) * (UI_BUFFER + Width), ScreenHeight - UI_BUFFER - Height);
            TopLeft = PixelPos;
            BottomRight = PixelPos + new Vector2(Width, Height);
        }
    }
}
