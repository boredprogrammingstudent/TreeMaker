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
using Color = Raylib_cs.Color;
using Button = TreeMaker.UI.Buttons.Button;
namespace TreeMaker.UI.Infobars
{
    abstract class InfoBar : Canvas
    {
        protected Person Person;
        public readonly int Width = (int)(ScreenWidth / 3.5f);
        public readonly int Height = ScreenHeight - 2 * UI_BUFFER;
        readonly Color Panel = Colors[(int)ColorTypes.Secondary1];
        protected InfoBar(Person person)
        {
            Person = person;
            AddPreUpdate(() => DrawRectangle(UI_BUFFER, UI_BUFFER, Width, Height, Panel));
        }
        protected class InfoBarButton : Button
        {
            public InfoBarButton(string text, Action onclick, int posY, int width, int height) : base(text, onclick)
            {
                Width = width;
                Height = height;
                TextSize = Height / 3;
                PixelPos = new(2 * UI_BUFFER, posY);
                TopLeft = PixelPos;
                BottomRight = PixelPos + new Vector2(Width, Height);
            }
        }
    }
}
