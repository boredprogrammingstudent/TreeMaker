using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeMaker.UI.Buttons;
using TreeMaker.UI.Inputs;
using static TreeMaker.Settings.UserSettings;
using TreeMaker.Scenes;
using static TreeMaker.Utils.Text;
using static Raylib_cs.Raylib;
using System.Numerics;
using TreeMaker.Settings;
using static TreeMaker.UI.UI;

namespace TreeMaker.UI.Popups
{
    class AddRelationshipPopup : Popup
    {
        InputText InputText;
        ArrayIndexChooser chooser;
        bool isDisplayingInputBox;
        string chosenRelationship = string.Empty;
        public AddRelationshipPopup(Person currPerson) : this(currPerson, true) { }
        public AddRelationshipPopup(Person currPerson, bool canAddBack)
        {
            InputText = new(new(PopupBuffer, ScreenHeight - PopupBuffer), ScreenWidth / 3, ScreenHeight / 15, Padding.BottomLeft);
            chooser = new ArrayIndexChooser(ScreenWidth / 3 - ArrayIndexChooser.Width / 2, ScreenHeight / 2, GetAllRelationships(true));
            AddElem(chooser,
                new XButton(new(ScreenWidth - PopupBuffer, PopupBuffer), () =>
                {
                    Scene.currScene.SetActive();
                    Scene.currScene.Canvas = Scene.currScene.Canvas[..^1];
                }),
                new PopupButton(2, Save, () =>
                {
                    chosenRelationship = chooser.GetVal() == Other ? InputText.Text : chooser.GetVal();
                    Scene.currScene.Canvas[^1] = new FindPersonPopup(p =>
                    {
                        currPerson.Relationships.Add(new Relationship(chosenRelationship, p));
                        if (canAddBack)
                        {
                            Scene.currScene.Canvas[^1] = new YesNoPopup(DoYouWantToAnInverseRelationship,
                                () => Scene.currScene.Canvas[^1] = new AddRelationshipPopup(p, false),
                                () => { Scene.currScene.Canvas = Scene.currScene.Canvas[..^1]; 
                                    Scene.currScene.SetActive(); });
                        }

                    });
                }));
            AddPostUpdate(() =>
            {
                DrawText(ParentExample, PopupBuffer + UI_BUFFER, PopupBuffer + UI_BUFFER + Height / 4, Height / 15, Colors[(int)ColorTypes.Text]);
                WriteCentered(ChooseRelationship, Height / 10, Vector2.One * PopupBuffer, new(Width, Height / 4));
            });
        }
        public override void Update()
        {
            if (chooser.GetVal() == Other && !isDisplayingInputBox)
            {
                isDisplayingInputBox = true;
                Elements.Add(InputText);
            }
            else if (chooser.GetVal() != Other && isDisplayingInputBox)
            {
                isDisplayingInputBox = false;
                Elements.Remove(InputText);
            }
            base.Update();
        }
    }
}
