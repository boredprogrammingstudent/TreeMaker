using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TreeMaker.Settings;
using Raylib_cs;
using static Raylib_cs.Raylib;
using static TreeMaker.Settings.UserSettings;

namespace TreeMaker.UI.Buttons
{
    class XButton : Button
    {
        const int WidthModifier = 15;

        public XButton(Vector2 TopRight, Action OnClick) : base("X", OnClick)
        {
            Width = ScreenWidth / WidthModifier;
            Height = Width;
            TextSize = Width / 2;
            PixelPos = TopRight - new Vector2(Width + UI_BUFFER, -UI_BUFFER);
            TopLeft = PixelPos;
            BottomRight = PixelPos + new Vector2(Width, Height);

        }
    }
}
