using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Raylib_cs.Raylib;
using Raylib_cs;

namespace TreeMaker.Utils
{
    static class UnloadImages
    {
        public static void Unload(List<Person> people)
        {
            foreach (Person person in people)
            {
                foreach(Texture2D image in person.Images)
                {
                    UnloadTexture(image);
                }
            }
        }
    }
}
