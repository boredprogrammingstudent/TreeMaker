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
using TreeMaker.Utils;
using Microsoft.VisualBasic;

namespace TreeMaker.UI.Popups
{
    class FindPersonPopup : Popup
    {
        InputText firstName;
        InputText lastName;
        Action<Person> IfFound;
        public FindPersonPopup(Action<Person> ifFound)
        {
            IfFound = ifFound;
            AddPreUpdate(() => WriteCentered(FindPerson, Width / 20, Vector2.One * PopupBuffer, new(Width, Height / 2)));
            AddPreUpdate(() => DrawText(FirstName, PopupBuffer + UI_BUFFER, ScreenHeight / 2 + UI_BUFFER, Width / 40, Colors[(int)ColorTypes.Text]));
            AddPreUpdate(() => DrawText(LastName, PopupBuffer + UI_BUFFER, ScreenHeight / 2 + UI_BUFFER + Width / 20 + UI_BUFFER, Width / 40, Colors[(int)ColorTypes.Text]));
            firstName = new(new(PopupBuffer + UI_BUFFER + Width / 5, ScreenHeight / 2 - UI_BUFFER), Width / 3, Height / 8);
            lastName = new(new(PopupBuffer + UI_BUFFER + Width / 5, ScreenHeight / 2 - UI_BUFFER + Width / 20 + UI_BUFFER), Width / 3, Height / 8);
            AddElem(
                new PopupButton(2, Save, GetPeople),
                firstName,
                lastName,
                new XButton(new(ScreenWidth - PopupBuffer, PopupBuffer), () =>
                {
                    Scene.currScene.Canvas = Scene.currScene.Canvas[0..^1];
                    Scene.currScene.SetActive();
                }));
        }
        void GetPeople()
        {
            List<Person> people;
            if (firstName.Text == string.Empty && lastName.Text == string.Empty)
            {
                people = new List<Person>();
            }
            else
            {
                if (lastName.Text == string.Empty)
                {
                    people = MainViewScene.People.Where(n => n.FirstName.ToLower() == firstName.Text.ToLower()).ToList();
                }
                else if (firstName.Text == string.Empty)
                {
                    people = MainViewScene.People.Where(n => n.LastName.ToLower() == lastName.Text.ToLower()).ToList();
                }
                else
                {
                    people = MainViewScene.People.Where(n => n.FirstName.ToLower() == firstName.Text.ToLower() && n.LastName.ToLower() == lastName.Text.ToLower()).ToList();
                }
            }
            if (people.Count == 1)
            {
                IfFound(people[0]);
            }
            else if (people.Count == 0)
            {
                Scene.currScene.Canvas[^1] = new GenericMessagePopup(ThisPersonCouldNotBeFound);
            }
            else
            {
                Scene.currScene.Canvas[^1] = new ChooseRightPersonPopup(people, p => IfFound(p));
            }
        }
    }
}
