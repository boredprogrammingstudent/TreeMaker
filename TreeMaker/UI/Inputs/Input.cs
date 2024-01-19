using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using static TreeMaker.Settings.UserSettings;
using static Raylib_cs.Raylib;
using TreeMaker.Settings;
using Raylib_cs;
using static TreeMaker.Utils.Text;
using TreeMaker.UI.Buttons;
using Color = Raylib_cs.Color;
namespace TreeMaker.UI.Inputs
{
    abstract class Input : ClickableRectangle
    {
        public int MaxChars = int.MaxValue;
        protected Color RingColor => isInWriting ? Colors[(int)ColorTypes.Accent] : Colors[(int)ColorTypes.Text];
        protected const float TextSizeModifier = 2 / 5f;
        public readonly int Height;
        public readonly int Width;
        readonly int TextSize;
        protected string WrittenText = string.Empty;
        bool isInWriting = false;
        protected Input(Vector2 pixelPos, int width, int height, Padding padding)
        {
            PixelPos = pixelPos + padding switch
            {
                Padding.TopLeft => Vector2.One * UI_BUFFER,
                Padding.TopRight => new Vector2(-width - UI_BUFFER, UI_BUFFER),
                Padding.BottomLeft => new Vector2(UI_BUFFER, -height - UI_BUFFER),
                Padding.BottomRight => new Vector2(-width - UI_BUFFER, -height - UI_BUFFER),
                Padding.Top => Vector2.UnitY * -UI_BUFFER,
                Padding.Bottom => Vector2.UnitY * UI_BUFFER,
                Padding.Left => Vector2.UnitX * UI_BUFFER,
                Padding.Right => Vector2.UnitX * -UI_BUFFER,
                _ => Vector2.Zero
            };
            Width = width;
            Height = height;
            TopLeft = PixelPos;
            BottomRight = PixelPos + new Vector2(Width, Height);
            TextSize = (int)(Height * TextSizeModifier);
        }
        protected Input(Vector2 pixelPos, int width, int height) : this(pixelPos, width, height, Padding.None) { }
        public override void Draw()
        {
            DrawRectangle(PixelPosX, PixelPosY, Width, Height, RingColor);
            DrawRectangle(PixelPosX + UI_BUFFER, PixelPosY + UI_BUFFER, Width - UI_BUFFER, Height - UI_BUFFER, Colors[(int)ColorTypes.Secondary2]);
            WriteCentered(WrittenText, TopLeft, BottomRight, TextSize);
        }
        public override void OnClick()
        {
            isInWriting = !isInWriting; //im keeping this syntax for consistency purposes even though it is seldom needed;
        }
        public override void Update()
        {
            if (isActive)
            {
                if(IsMouseButtonPressed(0))
                {
                    if (isMouseInside)
                    {
                        OnClick();
                    }
                    else
                    {
                        isInWriting = false;
                    }
                    return;
                }
                if (isInWriting)
                {
                    Write();
                }
            }
            Draw();
        }
        public abstract void Write();
    }
}
