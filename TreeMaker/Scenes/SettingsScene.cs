using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeMaker.UI;
using static Raylib_cs.Raylib;
using Color = Raylib_cs.Color;
namespace TreeMaker.Scenes
{
    class SettingsScene : Scene
    {
        public SettingsScene()
        {
            Canvas main = new();
            main.AddPreUpdate(() => ClearBackground(Color.RED));
            Canvas = new Canvas[] { main };
        }
    }
}
