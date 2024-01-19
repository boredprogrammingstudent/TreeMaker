using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeMaker.UI.Inputs;
using static TreeMaker.Settings.UserSettings;
using static TreeMaker.UI.UI;
using static Raylib_cs.Raylib;
using static TreeMaker.Utils.Text;
using TreeMaker.Settings;
using Raylib_cs;
using Color = Raylib_cs.Color;
using static TreeMaker.Utils.OpenFileManager;
using TreeMaker.Scenes;

namespace TreeMaker.UI.Infobars
{
    class EditInfoBar : InfoBar
    {
        static readonly int inputWidth = ScreenWidth / 8;
        static readonly int inputHeight = ScreenHeight / 20;
        static readonly int dist = inputHeight + UI_BUFFER;
        static readonly int textPosX = 2 * UI_BUFFER;
        static readonly int textSize = Language switch
        {
            Languages.French => 20,
            _ => 30
        };
        Color color = Colors[(int)ColorTypes.Text];
        InputText firstName;
        InputText lastName;
        InputInt dayOfBirth;
        InputInt monthOfBirth;
        InputInt yearOfBirth;
        InputInt dayOfDeath;
        InputInt monthOfDeath;
        InputInt yearOfDeath;

        Action _firstName;
        Action _lastName;
        Action _dayOfBirth;
        Action _monthOfBirth;
        Action _yearOfBirth;
        Action _dayOfDeath;
        Action _monthOfDeath;
        Action _yearOfDeath;

        public EditInfoBar(Person person) : base(person)
        {
            int inputPosX = (Width - UI_BUFFER) / 2 + UI_BUFFER;
            int i = 2 * UI_BUFFER;
            firstName = new(new(inputPosX, i), inputWidth, inputHeight);
            lastName = new(new(inputPosX, i += dist), inputWidth, inputHeight);
            dayOfBirth = new(new(inputPosX, i += dist), inputWidth, inputHeight);
            monthOfBirth = new(new(inputPosX, i += dist), inputWidth, inputHeight);
            yearOfBirth = new(new(inputPosX, i += dist), inputWidth, inputHeight);
            dayOfDeath = new(new(inputPosX, i += dist), inputWidth, inputHeight);
            monthOfDeath = new(new(inputPosX, i += dist), inputWidth, inputHeight);
            yearOfDeath = new(new(inputPosX, i += dist), inputWidth, inputHeight);

            firstName.Text = person.FirstName;
            lastName.Text = person.LastName;
            dayOfBirth.Text = person.DayOfBirth.ToString();
            monthOfBirth.Text = person.MonthOfBirth.ToString();
            yearOfBirth.Text = person.YearOfBirth.ToString();
            dayOfDeath.Text = person.DayOfDeath.ToString();
            monthOfDeath.Text = person.MonthOfDeath.ToString();
            yearOfDeath.Text = person.YearOfDeath.ToString();
            AddElem(firstName, lastName, dayOfBirth, monthOfBirth, yearOfBirth, dayOfDeath, monthOfDeath, yearOfDeath);

            i = 2 * UI_BUFFER;
            _firstName = () => DrawText(FirstName, textPosX, i, textSize, color);
            _lastName = () => DrawText(LastName, textPosX, i + dist, textSize, color);
            _dayOfBirth = () => DrawText(DayOfBirth, textPosX, i + 2 * dist, textSize, color);
            _monthOfBirth = () => DrawText(MonthOfBirth, textPosX, i + 3 * dist, textSize, color);
            _yearOfBirth = () => DrawText(YearOfBirth, textPosX, i + 4 * dist, textSize, color);
            _dayOfDeath = () => DrawText(DayOfDeath, textPosX, i + 5 * dist, textSize, color);
            _monthOfDeath = () => DrawText(MonthOfDeath, textPosX, i + 6 * dist, textSize, color);
            _yearOfDeath = () => DrawText(YearOfDeath, textPosX, i + 7 * dist, textSize, color);
            AddPostUpdate(_firstName, _lastName, _dayOfBirth, _monthOfBirth, _yearOfBirth, _dayOfDeath, _monthOfDeath, _yearOfDeath);

            AddElem(new InfoBarButton(AddImage, () =>
            {
                string image = Open(@"C:\", Utils.FileType.Image);
                if(image != string.Empty && image.Contains("png"))
                {
                    string path = MainViewScene.Dir + person.ID + person.FirstName + person.LastName + person.Images.Count + ".png";
                    File.Copy(image, path, false);
                    File.SetAttributes(path, FileAttributes.Normal);
                    person.AddImage(path);
                }
            }, i + 9 * dist, Width - 2 * UI_BUFFER, Width / 5));

        }
        public void Save()
        {
            Person.FirstName = firstName.Text;
            Person.LastName = lastName.Text;
            Person.DayOfBirth = dayOfBirth.Value;
            Person.MonthOfBirth = monthOfBirth.Value;
            Person.YearOfBirth = yearOfBirth.Value;
            Person.DayOfDeath = dayOfDeath.Value;
            Person.MonthOfDeath = monthOfDeath.Value;
            Person.YearOfDeath = yearOfDeath.Value;
        }
    }
}
