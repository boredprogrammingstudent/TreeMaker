using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Raylib_cs.Raylib;
using static TreeMaker.Utils.Text;
using static TreeMaker.Settings.UserSettings;
using static TreeMaker.UI.UI;
using TreeMaker.UI.Inputs;
using System.Numerics;
using TreeMaker.UI.Buttons;

namespace TreeMaker.UI.Popups
{
    class TextWriteInPopup : Popup
    {
        public TextWriteInPopup(string message, string button, Action<string> onButtonClick, Action onXButtonClick) : base()
        {
            AddPreUpdate(() => WriteCentered(message, Vector2.One * PopupBuffer, ScreenSize - Vector2.One * PopupBuffer, Width / 20));
            var input = new InputText(new(PopupBuffer, PopupBuffer + Height), ScreenWidth/3, ScreenHeight/8, Padding.BottomLeft);
            var saveButton = new PopupButton(PopupButton.NbButtons - 1, button, () => onButtonClick(input.Text));
            var xB = new XButton(new(ScreenWidth - PopupBuffer, PopupBuffer), onXButtonClick);
            AddElem(input, saveButton, xB);
        }
    }
}
