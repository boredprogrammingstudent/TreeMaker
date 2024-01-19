using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeMaker.Settings;

namespace TreeMaker.Utils
{
    static class SavePeople
    {
        public static void Save(string path, List<Person> people)
        {
            StreamWriter sw = new(path);
            sw.WriteLine($"LANG:{UserSettings.Language switch { Languages.French => "FR", _ => "EN" }}:");
            for (int i = 0; i < people.Count; ++i)
            {
                sw.WriteLine("PERSON::");
                sw.WriteLine($"FIRSTNAME:{people[i].FirstName}:");
                sw.WriteLine($"LASTNAME:{people[i].LastName}:");
                sw.WriteLine($"DAYOFBIRTH:{people[i].DayOfBirth}:");
                sw.WriteLine($"MONTHOFBIRTH:{people[i].MonthOfBirth}:");
                sw.WriteLine($"YEAROFBIRTH:{people[i].YearOfBirth}:");
                sw.WriteLine($"DAYOFDEATH:{people[i].DayOfDeath}:");
                sw.WriteLine($"MONTHOFDEATH:{people[i].MonthOfDeath}:");
                sw.WriteLine($"YEAROFDEATH:{people[i].YearOfDeath}:");
                for(int j = 0; j < people[i].ImagePaths.Count; ++j)
                {
                    sw.WriteLine($"IMAGE:{people[i].ImagePaths[j]}:");
                }
                sw.WriteLine("ENDPERSON::");
            }
            sw.WriteLine("RELATIONSHIPS::");
            for (int i = 0; i < people.Count; ++i)
            {
                sw.WriteLine($"PERSON:{i}:");
                for (int j = 0; j < people[i].Relationships.Count; ++j)
                {
                    sw.WriteLine(people[i].Relationships[j].Type + ':' + 
                        people[i].Relationships[j].Other.ID + ':');
                }
            }
            sw.Close();
        }
    }
}
