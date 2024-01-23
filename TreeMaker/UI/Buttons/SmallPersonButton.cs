using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TreeMaker.UI.Buttons
{
    class SmallPersonButton : Button
    {
        public SmallPersonButton(Person person, Vector2 startPos, int index, int width, int height, Action onClick) :
            base($"{person.FirstName} {person.LastName}, " +
                $"{person.DayOfBirth}/{person.MonthOfBirth}/{person.YearOfBirth} - " +
                $"{person.DayOfDeath}/{person.MonthOfDeath}/{person.YearOfDeath}",
                onClick)
        {
            Width = width; Height = height;
            PixelPos = startPos + index * new Vector2(0, Height + UI_BUFFER);
            TopLeft = PixelPos;
            BottomRight = PixelPos + new Vector2(Width, Height);
        }
        public void SetTextSize(int val)
        {
            TextSize = val;
        }
    }
}
