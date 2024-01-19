using System;
using System.Collections.Generic;
using System.Linq;
using Raylib_cs;
using static Raylib_cs.Raylib;
using TreeMaker.Scenes;
using static TreeMaker.Utils.Text;
namespace TreeMaker
{
    class Person
    {
        static int id = 0;
        public Person() : this(true) { }
        public Person(bool idCount)
        {
            if(idCount)
            {
                ID = id++;
            }
        }
        public int ID { get; private set; }
        public string FirstName = Unknown;
        public string LastName = Unknown;
        public (string FirstName, string LastName) Name
        {
            get => (FirstName, LastName);
            set => (FirstName, LastName) = value;
        }
        public int DayOfBirth;
        public int MonthOfBirth;
        public int YearOfBirth;
        public (int Day, int Month, int Year) DateOfBirth
        {
            get => (DayOfBirth, MonthOfBirth, YearOfBirth);
            set => (DayOfBirth, MonthOfBirth, YearOfBirth) = value;
        }
        public int DayOfDeath;
        public int MonthOfDeath;
        public int YearOfDeath;
        public (int Day, int Month,int Year) DateOfDeath
        {
            get => (DayOfDeath, MonthOfDeath, YearOfDeath);
            set => (DayOfDeath, MonthOfDeath, YearOfDeath) = value;
        }
        public List<string> ImagePaths = new();
        public List<Texture2D> Images = new();
        public void AddImage(string path)
        {
            ImagePaths.Add(path);
            Images.Add(LoadTexture(path));
        }
        public List<Relationship> Relationships = new();
        public void View() => Scene.currScene = new ViewPersonScene(this);
        public void Edit() => Scene.currScene = new EditPersonScene(this);
    }
}