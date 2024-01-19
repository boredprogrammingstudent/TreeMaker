using TreeMaker.Settings;
using TreeMaker.UI;
using TreeMaker.UI.Sidebars;
using TreeMaker.Utils;
using static Raylib_cs.Raylib;
using static TreeMaker.Settings.UserSettings;
using static TreeMaker.Utils.Text;
using TreeMaker.UI.Popups;
using TreeMaker.UI.Buttons;
using System.Numerics;
using System;

namespace TreeMaker.Scenes
{
    class MainViewScene : Scene
    {
        public static List<Person> People = new();
        public static string Path = string.Empty;
        public static string Dir = string.Empty;
        public MainViewScene(string path, string dir)
        {
            People = LoadPeople.Load(path);
            Dir = dir;
            Path = path;
            InitializeScene();
        }
        public MainViewScene()
        {
            InitializeScene();
        }
        void InitializeScene()
        {
            Canvas main = new();
            Sidebar sidebar = new(true, ScreenWidth / 6, 8);
            main.AddPreUpdate(() => ClearBackground(Colors[(int)ColorTypes.Primary]));
            main.AddElem(new XButton(Vector2.UnitX * ScreenWidth, () =>
            {
                currScene = new MainMenuScene();
                UnloadImages.Unload(People);
                People.Clear();
            }));
            sidebar.AddButton(AddPerson, () =>
            {
                Person person = new();
                People.Add(person);
                currScene = new EditPersonScene(person);
            });
            sidebar.AddButton(FindPerson, () =>
            {
                SetInactive();
                Canvas = new Canvas[] { main, sidebar,
                    new FindPersonPopup(person => currScene = new ViewPersonScene(person)) };
            });

            Canvas = new Canvas[] { main, sidebar };
        }
    }
}
