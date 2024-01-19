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
using System.Windows.Forms;
using TreeMaker.Settings;
using TreeMaker.Scenes;

namespace TreeMaker.UI.Popups
{
    class FindPersonPopup : Popup
    {
        public FindPersonPopup(Action<Person> ifFound)
        {
            AddPreUpdate(() => WriteCentered(FindPerson, Width/20, Vector2.One*PopupBuffer, new(Width, Height/2)));
            AddPreUpdate(() => DrawText(FirstName, PopupBuffer + UI_BUFFER, ScreenHeight / 2 + UI_BUFFER, Width / 40, Colors[(int)ColorTypes.Text]));
            AddPreUpdate(() => DrawText(LastName, PopupBuffer + UI_BUFFER, ScreenHeight / 2 + UI_BUFFER + Width / 20 + UI_BUFFER, Width / 40, Colors[(int)ColorTypes.Text]));
            var firstName = new InputText(new(PopupBuffer + UI_BUFFER + Width/5, ScreenHeight / 2 - UI_BUFFER), Width / 3, Height / 8);
            var lastName = new InputText(new(PopupBuffer + UI_BUFFER + Width/5, ScreenHeight / 2 - UI_BUFFER + Width / 20 + UI_BUFFER), Width / 3, Height / 8);
            AddElem(
                new PopupButton(2, Save, () =>
                {
                    Person? person = MainViewScene.People.Find(n => n.FirstName.ToLower() == firstName.Text.ToLower() && n.LastName.ToLower() == lastName.Text.ToLower());
                    if (person != null)
                    {
                        ifFound(person);
                    }
                    else
                    {
                        if (Scene.currScene != null && Scene.currScene.Canvas != null)
                        {
                            Scene.currScene.Canvas[^1] = new GenericMessagePopup(ThisPersonCouldNotBeFound);
                        }
                    }
                }),
                firstName,
                lastName,
                new XButton(new(ScreenWidth - PopupBuffer, PopupBuffer), () =>
                {
                    if (Scene.currScene != null && Scene.currScene.Canvas != null)
                        Scene.currScene.Canvas = Scene.currScene.Canvas[0..^1];
                    Scene.currScene?.SetActive();
                })
                );
        }
    }
}
