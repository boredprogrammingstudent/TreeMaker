using Raylib_cs;
using TreeMaker.Settings;
using static Raylib_cs.Raylib;
using static TreeMaker.Utils.Text;
using static TreeMaker.Settings.UserSettings;
using Color = Raylib_cs.Color;

namespace TreeMaker.UI.Buttons
{
    abstract class Button : ClickableRectangle
    {
        public string Text { get; protected set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public Color color { get; private set; }
        static readonly Color ButtonColor = Colors[(int)ColorTypes.Secondary2];
        static readonly Color HighlightButtonColor = Colors[(int)ColorTypes.Accent];
        public int TextSize { get; protected set; }
        public Action onClick { get; protected set; }

        protected Button(string text, Action OnClick)
        {
            Text = text;
            onClick = OnClick;
        }

        public override void Draw()
        {
            DrawRectangle(PixelPosX, PixelPosY, Width, Height, color);
            WriteCentered(Text, TopLeft, BottomRight, TextSize);
        }
        public override void Update()
        {
            if (isMouseInside && isActive)
            {
                color = HighlightButtonColor;
                if (IsMouseButtonPressed(0))
                    OnClick();
            }
            else
                color = ButtonColor;
            Draw();
        }
        public override void OnClick()
        {
            onClick();
        }
    }
}
