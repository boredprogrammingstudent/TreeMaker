using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeMaker.UI.Buttons;
using static TreeMaker.UI.UI;
using System.Numerics;
using Button = TreeMaker.UI.Buttons.Button;
namespace TreeMaker.UI.Popups
{
    class ChooseRightPersonPopup : Popup
    {
        readonly static int peoplePerColumn = 4;
        public ChooseRightPersonPopup(List<Person> people, Action<Person> onChoose)
        {
            int peoplePerRow = (int)Math.Ceiling((float)people.Count / peoplePerColumn);
            int width = (Width - (peoplePerRow + 1) * UI_BUFFER) / peoplePerRow;
            int height = (Height - (peoplePerColumn + 1) * UI_BUFFER) / peoplePerColumn;
            for (int j = 0; j < people.Count; j += peoplePerColumn)
            {
                for (int i = 0; i < peoplePerColumn && j + i < people.Count; ++i)
                {
                    Person person = people[i + j];
                    Vector2 startPos = Vector2.One * (UI_BUFFER + PopupBuffer) +
                        new Vector2((j + 1) / peoplePerColumn * (width + UI_BUFFER), 0);
                    AddElem(new SmallPersonButton(person, startPos,
                        i, width, height, () => onChoose(person)));
                }
            }
            foreach (UI elem in Elements)
            {
                SmallPersonButton? b = elem as SmallPersonButton;
                b?.SetTextSize(Width / (peoplePerRow * 20));
            }
        }
    }
}
