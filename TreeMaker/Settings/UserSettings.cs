using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeMaker.Utils;
using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;
using Color = Raylib_cs.Color;
namespace TreeMaker.Settings
{
    static class UserSettings
    {
        const string SETTINGS = @"..\..\..\User_Files\User_Settings\Settings";
        public static Languages Language;
        public static DisplayModes DisplayMode;
        public static Color[] Colors => DisplayMode switch
        {
            DisplayModes.Dark => new Color[]
            {
                new Color(18, 18, 18, 255),
                new Color(0, 116, 204, 255),
                new Color(30, 30, 30, 255),
                new Color(48, 48, 48, 255),
                new Color(255, 255, 255, 255)
            },
            _ => new Color[]
            {
                new Color(255, 255, 255, 255),
                new Color(0, 116, 204, 255),
                new Color(240, 240, 240, 255),
                new Color(224, 224, 224, 255),
                new Color(0, 0, 0, 255)
            }
        };
        public static Vector2 ScreenSize;
        public static int ScreenWidth
        {
            get => (int)ScreenSize.X;
            set => ScreenSize = new(value, ScreenSize.Y);
        }
        public static int ScreenHeight
        {
            get => (int)ScreenSize.Y;
            set => ScreenSize = new(ScreenSize.X, value);
        }
        public static void LoadSettings()
        {
            FileReader.ReadFile(SETTINGS, SetSetting);
        }
        static void SetSetting(string setting, string response)
        {
            switch (setting)
            {
                case "LANG":
                    Language = response switch
                    {
                        "FR" => Languages.French,
                        _ => Languages.English
                    }; break;
                case "DISPMODE":
                    DisplayMode = response switch
                    {
                        "LIGHT" => DisplayModes.Light,
                        _ => DisplayModes.Dark
                    }; break;
                case "WIDTH": ScreenWidth = int.TryParse(response, out int width) ? width : ScreenWidth; break;
                case "HEIGHT": ScreenHeight = int.TryParse(response, out int height) ? height : ScreenHeight; break;
                default: break;
            }
        }
    }
    enum Languages
    {
        English,
        French
    };
    enum DisplayModes
    {
        Dark,
        Light
    };
    enum ColorTypes
    {
        Primary,
        Accent,
        Secondary1,
        Secondary2,
        Text
    };
}
