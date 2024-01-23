using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TreeMaker.Utils.Text;
using System.Numerics;
using static TreeMaker.UI.UI;
using static Raylib_cs.Raylib;
using Color = Raylib_cs.Color;
using static TreeMaker.Settings.UserSettings;
using TreeMaker.Settings;
using TreeMaker.Scenes;
namespace TreeMaker.UI.Infobars
{
    class ViewInfoBar : InfoBar
    {
        public ViewInfoBar(Person person) : base(person)
        {
            int textSize = Width / 15;
            AddPreUpdate(() => Write(FirstName + " : " + person.FirstName,
                2 * UI_BUFFER, 2 * UI_BUFFER + 0 * (UI_BUFFER + textSize), textSize));
            AddPreUpdate(() => Write(LastName + " : " + person.LastName,
                2 * UI_BUFFER, 2 * UI_BUFFER + 1 * (UI_BUFFER + textSize), textSize));
            AddPreUpdate(() => Write(DayOfBirth + " : " + person.DayOfBirth,
                2 * UI_BUFFER, 2 * UI_BUFFER + 2 * (UI_BUFFER + textSize), textSize));
            AddPreUpdate(() => Write(MonthOfBirth + " : " + person.MonthOfBirth,
                2 * UI_BUFFER, 2 * UI_BUFFER + 3 * (UI_BUFFER + textSize), textSize));
            AddPreUpdate(() => Write(YearOfBirth + " : " + person.YearOfBirth,
                2 * UI_BUFFER, 2 * UI_BUFFER + 4 * (UI_BUFFER + textSize), textSize));
            AddPreUpdate(() => Write(DayOfDeath + " : " + person.DayOfDeath,
                2 * UI_BUFFER, 2 * UI_BUFFER + 5 * (UI_BUFFER + textSize), textSize));
            AddPreUpdate(() => Write(MonthOfDeath + " : " + person.MonthOfDeath,
                2 * UI_BUFFER, 2 * UI_BUFFER + 6 * (UI_BUFFER + textSize), textSize));
            AddPreUpdate(() => Write(YearOfDeath + " : " + person.YearOfDeath,
                2 * UI_BUFFER, 2 * UI_BUFFER + 7 * (UI_BUFFER + textSize), textSize));
            
            Vector2 imagePos = new Vector2(2 * UI_BUFFER, 2 * UI_BUFFER + 12 * (UI_BUFFER + textSize));
            if(person.Images.Count > 0)
            {
                AddElem(new InfoBarButton(ViewMoreImages, () =>
                {
                    Scene.currScene = new ViewPersonImagesScene(person);
                }, 2 * UI_BUFFER + 9 * (UI_BUFFER + textSize), Width - 2 * UI_BUFFER, Width / 5));
                float width = (float)(Width - 2 * UI_BUFFER)/person.Images[0].Width;
                float height = (float)(ScreenHeight - 2 * UI_BUFFER - imagePos.Y) / person.Images[0].Height;
                float size = Math.Min(width, height);
                AddPostUpdate(() => DrawTextureEx(person.Images[0], imagePos, 0, size, Color.WHITE));
            }
            
        }
    }
}
