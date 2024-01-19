using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TreeMaker.UI.Popups;
using static TreeMaker.Settings.UserSettings;
using static TreeMaker.UI.Popups.Popup;
namespace TreeMaker.UI.Buttons
{
    class PopupButton : Button
    {
        const int HeightModifier = 3;
        public const int NbButtons = 3;
        public PopupButton(int index, string text, Action OnClick) : base(text, OnClick)
        {
            Width = (Popup.Width - (NbButtons + 1) * UI_BUFFER) / NbButtons;
            Height = Popup.Height / HeightModifier;
            PixelPos = new(PopupBuffer + index * Width + (index + 1) * UI_BUFFER, ScreenHeight - PopupBuffer - UI_BUFFER - Height);

            TopLeft = PixelPos;
            BottomRight = PixelPos + new Vector2(Width, Height);
            TextSize = Height / 3;
        }
    }
}
