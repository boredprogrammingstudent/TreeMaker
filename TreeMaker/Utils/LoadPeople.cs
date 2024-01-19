using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeMaker.Settings;

namespace TreeMaker.Utils
{
    static class LoadPeople
    {
        static bool isRelationship = false;
        public static List<Person> People = new();
        static Person person = new(false);
        public static List<Person> Load(string path)
        {
            FileReader.ReadFile(path, LoadData);
            isRelationship = false;
            return People;
        }
        static void LoadData(string obj, string set)
        {
            if(!isRelationship)
            {
                switch (obj)
                {
                    case "LANG":
                        UserSettings.Language = set switch
                        {
                            "FR" => Languages.French,
                            _ => Languages.English
                        }; break;
                    case "PERSON":
                        person = new Person();
                        break;
                    case "ENDPERSON":
                        People.Add(person);
                        break;
                    case "FIRSTNAME":
                        person.FirstName = set;
                        break;
                    case "LASTNAME":
                        person.LastName = set;
                        break;
                    case "DAYOFBIRTH":
                        person.DayOfBirth = int.TryParse(set, out int day) ? day : default;
                        break;
                    case "MONTHOFBIRTH":
                        person.MonthOfBirth = int.TryParse(set, out int month) ? month : default;
                        break;
                    case "YEAROFBIRTH":
                        person.YearOfBirth = int.TryParse(set, out int year) ? year : default;
                        break;
                    case "DAYOFDEATH":
                        person.DayOfDeath = int.TryParse(set, out int Day) ? Day : default;
                        break;
                    case "MONTHOFDEATH":
                        person.MonthOfDeath = int.TryParse(set, out int Month) ? Month : default;
                        break;
                    case "YEAROFDEATH":
                        person.YearOfDeath = int.TryParse(set, out int Year) ? Year : default;
                        break;
                    case "IMAGE":
                        person.AddImage(set); 
                        break;
                    case "RELATIONSHIPS":
                        isRelationship = true;
                        break;

                }
            }
            else
            {
                switch (obj)
                {
                    case "PERSON":
                        if (int.TryParse(set, out int index))
                        {
                            person = People[index];
                        }
                        else throw new InvalidDataException();
                        break;
                    default:
                        if (obj == string.Empty) break;
                        if (int.TryParse(obj, out int rel))
                        {
                            if (rel < 0) throw new InvalidDataException();
                            person.Relationships.Add(new(set, People[rel]));
                        }
                        else throw new InvalidDataException();
                        break;
                }
            }
            
        }
    }
    class InvalidDataException : Exception { }
}
