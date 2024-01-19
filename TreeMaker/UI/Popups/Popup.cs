using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TreeMaker.Settings.UserSettings;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
using TreeMaker.Settings;
using Color = Raylib_cs.Color;  
namespace TreeMaker.UI.Popups
{
    abstract class Popup : Canvas
    {
        public static readonly int PopupBuffer = ScreenWidth / 7;
        public static int Width = ScreenWidth - 2 * PopupBuffer;
        public static int Height = ScreenHeight - 2 * PopupBuffer;
        static readonly Color Backdrop = new(0, 0, 0, 100);
        static readonly Color Panel = Colors[(int)ColorTypes.Primary];
        protected Popup()
        {
            AddPreUpdate(() => DrawRectangle(0, 0, ScreenWidth, ScreenHeight, Backdrop));
            AddPreUpdate(() => DrawRectangle(PopupBuffer, PopupBuffer, Width, Height, Panel));
        }
    }
}
