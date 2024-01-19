using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeMaker.UI;
using static Raylib_cs.Raylib;
using static TreeMaker.Settings.UserSettings;
using TreeMaker.Settings;
using static TreeMaker.Utils.Text;
using System.Numerics;
using static TreeMaker.UI.UI;
using TreeMaker.UI.Buttons;
namespace TreeMaker.Scenes
{
    class ViewPersonImagesScene : Scene
    {
        public ViewPersonImagesScene(Person person)
        {
            Canvas main = new();
            main.AddPreUpdate(() => ClearBackground(Colors[(int)ColorTypes.Primary]));
            int TextSize = ScreenHeight / 15;
            main.AddPostUpdate(() => WriteCentered("Scroll down for more", 
                TextSize, Vector2.Zero, new(ScreenWidth, TextSize + 2 * UI_BUFFER)));
            main.AddElem(new XButton(new(ScreenWidth, 0), person.View));
            ImageCarroussel images = new(person, TextSize + 2 * UI_BUFFER);


            Canvas = new Canvas[] { images, main }; //Images is first so theyre under the UI;
        }
    }
}
