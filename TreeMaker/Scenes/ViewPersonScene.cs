using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeMaker.UI;
using static Raylib_cs.Raylib;
using Color = Raylib_cs.Color;
using Image = Raylib_cs.Image;
using static TreeMaker.Settings.UserSettings;
using TreeMaker.Settings;
using TreeMaker.UI.Infobars;
using TreeMaker.UI.Buttons;
using static TreeMaker.Utils.Text;

namespace TreeMaker.Scenes
{
    class ViewPersonScene : Scene
    {
        public ViewPersonScene(Person person)
        {
            Canvas main = new();
            ViewInfoBar infobar = new(person);
            main.AddPreUpdate(() => ClearBackground(Colors[(int)ColorTypes.Primary]));
            main.AddElem(
                new RegularButton(0, Edit, person.Edit),
                new XButton(new(ScreenWidth, 0), () => currScene = new MainViewScene()));
            Canvas = new Canvas[]
            {
                main, infobar
            };
        }
    }
}
