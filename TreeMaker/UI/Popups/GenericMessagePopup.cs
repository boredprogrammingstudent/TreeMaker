using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static TreeMaker.Utils.Text;
using static TreeMaker.Settings.UserSettings;
using TreeMaker.Scenes;
using TreeMaker.UI.Buttons;
namespace TreeMaker.UI.Popups
{
    class GenericMessagePopup : Popup
    {
        public GenericMessagePopup(string message) : this(message, Width / 20) { }
        public GenericMessagePopup(string message, int textSize)
        {
            AddPreUpdate(() => WriteCentered(message, Vector2.One * PopupBuffer, ScreenSize - Vector2.One * PopupBuffer, textSize));
            AddElem(new PopupButton(2, "OK", () =>
            {
                Scene.currScene.Canvas = Scene.currScene.Canvas[0..^1];
                foreach (Canvas canvas in Scene.currScene.Canvas)
                {
                    canvas.IsActive = true;
                }

            }));
        }
    }
}
