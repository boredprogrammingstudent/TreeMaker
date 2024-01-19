using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using static Raylib_cs.Raylib;
using static TreeMaker.UI.UI;
using static TreeMaker.Settings.UserSettings;
using TreeMaker.Settings;
using System.Numerics;
using TreeMaker.UI.Buttons;
using Color = Raylib_cs.Color;
using Button = TreeMaker.UI.Buttons.Button;
namespace TreeMaker.UI.Sidebars
{
    class Sidebar : Canvas
    {

        public readonly int Width;
        readonly int Height = ScreenHeight - 2 * UI_BUFFER;
        readonly Color Panel = Colors[(int)ColorTypes.Secondary1];
        int MaxNbButtons;
        int nbButtons = 0;
        public Sidebar(bool left, int width, int maxNbButtons)
        {
            Width = width;
            MaxNbButtons = maxNbButtons;
            AddPreUpdate(() => DrawRectangle(UI_BUFFER, UI_BUFFER, Width, Height, Panel));
        }
        public void AddButton(string text, Action Onclick)
        {
            if (nbButtons <= MaxNbButtons)
            {
                int width = Width - 2 * UI_BUFFER;
                int height = (Height - (MaxNbButtons + 1) * UI_BUFFER) / MaxNbButtons;
                Vector2 pixelPos = new(2 * UI_BUFFER, UI_BUFFER + (nbButtons + 1) * UI_BUFFER + nbButtons * height);
                AddElem(new SidebarButton(width, height, Language switch
                {
                    Languages.French => height / 5,
                    _ => height / 3
                }, pixelPos, text, Onclick));
            }
            ++nbButtons;
        }
        class SidebarButton : Button
        {
            public SidebarButton(int width, int height, int textSize, Vector2 pixelPos, string text, Action OnClick) : base(text, OnClick)
            {
                Width = width;
                Height = height;
                PixelPos = pixelPos;
                TopLeft = PixelPos;
                BottomRight = PixelPos + new Vector2(Width, Height);
                TextSize = textSize;
            }
        }
    }
}
