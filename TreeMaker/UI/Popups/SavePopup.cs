using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static TreeMaker.Utils.Text;
using TreeMaker.UI.Buttons;
using TreeMaker.Scenes;
namespace TreeMaker.UI.Popups
{
    class SavePopup : Popup
    {
        public SavePopup(Action onSave)
        {
            AddPreUpdate(() => WriteCentered(DoYouWannaSave, Width / 40, Vector2.One * PopupBuffer, new(Width, Height / 2)));
            AddElem(
                    new PopupButton(0, Save, () =>
                    {
                        onSave();
                    }),
                    new PopupButton(1, DontSave, () =>
                    {
                        Scene.currScene = new MainViewScene();
                    }),
                    new PopupButton(2, Cancel, () =>
                    {
                        Scene.currScene.Canvas = Scene.currScene.Canvas[0..^1];
                        Scene.currScene.SetActive();
                    })
                );
        }
    }
}
