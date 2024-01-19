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
    class MainMenuButton : Button
    {
        const int HeightModifier = 5;
        const int NbButtons = 3;
        public MainMenuButton(int index, string text, Action OnClick) :
            base(text, OnClick)
        {
            Width = ScreenWidth / NbButtons - (NbButtons + 1) * UI_BUFFER;
            Height = ScreenHeight / HeightModifier;
            TextSize = Height / 3 - HeightModifier;
            PixelPos = new(index * Width + (index + 1) * UI_BUFFER, ScreenHeight - UI_BUFFER - Height);
            TopLeft = PixelPos;
            BottomRight = PixelPos + new Vector2(Width, Height);
        }
    }
}