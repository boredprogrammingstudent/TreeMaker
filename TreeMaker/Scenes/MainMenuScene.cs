using TreeMaker.UI;
using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;
using static TreeMaker.Settings.UserSettings;
using TreeMaker.Settings;
using static TreeMaker.Utils.Text;
using TreeMaker.UI.Popups;
using TreeMaker.UI.Buttons;
using TreeMaker.Utils;

namespace TreeMaker.Scenes
{
    class MainMenuScene : Scene
    {
        public MainMenuScene()
        {

            Canvas main = new();
            TextWriteInPopup newTree = new(NameTree, CreateTree, s => 
            {
                if (string.IsNullOrEmpty(s))
                    s += "(1)";
                string dir = @$"..\..\..\User_Files\Trees\{s}";
                while (Directory.Exists(dir))
                {
                    dir += "(1)";
                }
                dir += '\\';
                Directory.CreateDirectory(dir);
                Directory.CreateDirectory(dir + "View");
                string path = dir + $"{s}.tree";
                StreamWriter sw = new(path);
                sw.WriteLine("::");
                sw.Close();
                currScene = new MainViewScene(path, dir);
            }, () =>
            {
                Canvas = new Canvas[] { main };
                main.IsActive = true;
            });
            main.AddPreUpdate(() => ClearBackground(Colors[(int)ColorTypes.Primary]));
            main.AddPreUpdate(() => WriteCentered("TreeMaker", 50, Vector2.Zero, ScreenSize - new Vector2(0, ScreenHeight/2)));
            main.AddElem(
                new MainMenuButton(0, LoadTree, () =>
                {
                    string file = OpenFileManager.Open(@"..\..\..\User_Files\Trees\", FileType.Tree);
                    if(file == string.Empty || file == "Settings")
                    {
                        Canvas = new Canvas[] { main, new GenericMessagePopup(ThereWasAProblem) };
                        main.IsActive = false;
                    }
                    else
                    {
                        string dir = GetDir(file);
                        currScene = new MainViewScene(file, dir);
                    }
                }),
                new MainMenuButton(1, NewTree, () =>
                {
                    Canvas = new Canvas[] { main, newTree };
                    main.IsActive = false;
                }),
                new SettingsButton()
                );
            
            Canvas = new Canvas[] { main };
        }
        public static string GetDir(string file)
        {
            string dir = file;
            char c = ' ';
            while (c != '\\')
            {
                dir = dir[0..^1];
                c = dir[^1];
            }
            return  dir;
        }
    }
}
