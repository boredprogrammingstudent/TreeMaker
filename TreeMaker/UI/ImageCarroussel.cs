using Raylib_cs;
using static Raylib_cs.Raylib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeMaker.UI;
using static TreeMaker.UI.UI;
namespace TreeMaker.UI
{
    class ImageCarroussel : Canvas
    {
        const int ddy = 50;
        const int ddx = 50;
        int dy = 0;
        int dx = 0;
        Texture2D[] Images;
        int[] posY;
        public ImageCarroussel(Person person, int startpos)
        {
            Images = person.Images.ToArray() ?? Array.Empty<Texture2D>();
            posY = new int[Images.Length];
            posY[0] = startpos;
            if(Images.Length > 0)
            {
                for(int i = 1; i < Images.Length; ++i)
                {
                    posY[i] = posY[i - 1] + Images[i - 1].Height + UI_BUFFER;
                }
            }
        }
        public override void Update()
        {
            for(int i = 0; i < Images.Length; ++i)
            {
                DrawTexture(Images[i], UI_BUFFER + dx, posY[i] + dy, Raylib_cs.Color.WHITE);
            }
            if (IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT))
            {
                if (GetMouseWheelMove() > 0)
                {
                    dx += ddx;
                }
                else if (GetMouseWheelMove() < 0)
                {
                    dx -= ddx;
                }
            }
            else
            {
                if (GetMouseWheelMove() > 0)
                {
                    dy += ddy;
                }
                else if (GetMouseWheelMove() < 0)
                {
                    dy -= ddy;
                }
            }
            
        }
    }
}
