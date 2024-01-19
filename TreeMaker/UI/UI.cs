using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Reflection;
using static TreeMaker.Settings.UserSettings;

namespace TreeMaker.UI
{
    abstract class UI
    {
        public static readonly int UI_BUFFER = ScreenWidth / 250;
        public Vector2 PixelPos;
        public int PixelPosX => (int)PixelPos.X;
        public int PixelPosY => (int)PixelPos.Y;
        public bool isActive = true;
        
        public abstract void Update();
        public abstract void Draw();
    }
    enum Padding
    {
        Left,
        Right,
        Top,
        Bottom,
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
        None
    };
}
