using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TreeMaker.Scenes;
using static TreeMaker.Settings.UserSettings;
namespace TreeMaker.UI.Buttons
{
    class SettingsButton : Button
    {
        const int WidthModifier = 10;
        const int HeightModifier = 10;
        public SettingsButton() : base(Utils.Text.Settings, () => Scene.currScene = new SettingsScene())
        {
            Vector2 TopRight = new(ScreenWidth, 0);
            Width = ScreenWidth / WidthModifier;
            Height = ScreenHeight / HeightModifier;
            TextSize = Height/3;
            PixelPos = TopRight - new Vector2(Width + UI_BUFFER, -UI_BUFFER);
            TopLeft = PixelPos;
            BottomRight = PixelPos + new Vector2(Width, Height);

        }
    }
}
