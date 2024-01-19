using TreeMaker.UI;
using static Raylib_cs.Raylib;
using Raylib_cs;
using static TreeMaker.Settings.UserSettings;
using TreeMaker.Settings;
using TreeMaker.UI.Infobars;
using TreeMaker.UI.Buttons;
using TreeMaker.Utils;
using static TreeMaker.Scenes.MainViewScene;
using TreeMaker.UI.Popups;

namespace TreeMaker.Scenes
{
    class EditPersonScene : Scene
    {
        public EditPersonScene(Person person)
        {
            Canvas main = new();
            EditInfoBar infobar = new(person);
            main.AddPreUpdate(() => ClearBackground(Colors[(int)ColorTypes.Primary]));
            main.AddElem(
                new XButton(new(ScreenWidth, 0), () => 
                {
                    SetInactive();
                    Canvas = new Canvas[] { main, infobar, new SavePopup(() =>
                    {
                        Save(infobar);
                        currScene = new MainViewScene();
                    }) };
                
                }),
                new RegularButton(0, Text.Save, () => 
                { Save(infobar); person.View(); })
                );
            Canvas = new Canvas[] { main, infobar };
        }
        static void Save(EditInfoBar infobar)
        {
            infobar.Save(); 
            SavePeople.Save(MainViewScene.Path, People);
        }
    }
}
