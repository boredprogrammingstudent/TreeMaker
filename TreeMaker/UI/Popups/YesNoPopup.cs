using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TreeMaker.Utils.Text;
using TreeMaker.UI.Buttons;
using System.Numerics;
using static TreeMaker.Settings.UserSettings;
namespace TreeMaker.UI.Popups
{
    class YesNoPopup : Popup
    {
        public YesNoPopup(string message, Action onYes, Action onNo)
        {
            AddPreUpdate(() => WriteCentered(message, Vector2.One * PopupBuffer, ScreenSize - Vector2.One * PopupBuffer, Width/20));
            AddElem(
                new PopupButton(0, Yes, onYes),
                new PopupButton(1, No, onNo)
                );
        }
    }
}
