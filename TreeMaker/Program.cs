/*
 * by me 2024
 */
using System;
using Raylib_cs;
using static Raylib_cs.Raylib;
using TreeMaker.Settings;
using TreeMaker.Scenes;
using TreeMaker.Utils;
namespace TreeMaker
{
    public class Program
    {
        [STAThread]
        public static int Main(string[] args)
        {
            UserSettings.LoadSettings();
            if (args.Length == 0 )
            {
                Scene.currScene = new MainMenuScene();
            }
            else if (args.Length == 1 && args[0][^5..^1] == ".tree")
            {
                //THIS DOESNT WORK AT THE MOMENT
                Scene.currScene = new MainViewScene(args[0], MainMenuScene.GetDir(args[0]));
            }
            else
            {
                throw new Exception();
            }
            InitWindow(UserSettings.ScreenWidth, UserSettings.ScreenHeight, "TreeMaker");
            UserSettings.LoadFonts();
            SetTargetFPS(60);

            while (!WindowShouldClose())
            {
                BeginDrawing();
                Scene.currScene.Update();
                EndDrawing();
            }
            UnloadImages.Unload(MainViewScene.People);
            CloseWindow();

            return 0;
        }
    }
}