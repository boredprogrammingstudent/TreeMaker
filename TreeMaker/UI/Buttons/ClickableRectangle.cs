using Raylib_cs;
using static Raylib_cs.Raylib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace TreeMaker.UI.Buttons
{
    abstract class ClickableRectangle : UI, Clickable
    {
        protected ClickableRectangle(Vector2 topLeft, Vector2 bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }
        protected ClickableRectangle() { }
        public Vector2 TopLeft { get; protected set; }
        public Vector2 BottomRight { get; protected set; }
        public bool isMouseInside
        {
            get
            {
                Vector2 mousePos = GetMousePosition();
                return
                    TopLeft.X <= mousePos.X &&
                    TopLeft.Y <= mousePos.Y &&
                    BottomRight.X >= mousePos.X &&
                    BottomRight.Y >= mousePos.Y;
            }
        }
        public override void Update()
        {
            Draw();
            if (IsMouseButtonPressed(0) && isMouseInside && isActive)
                OnClick();
        }
        public abstract void OnClick();
    }
}
