using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TreeMaker.UI;

namespace TreeMaker.Scenes
{
    abstract class Scene
    {
        static readonly Scene defaultScene = new MainMenuScene();
        public static Scene currScene = defaultScene;
        public Canvas[] Canvas = Array.Empty<Canvas>();
        public virtual void Update()
        {
            if (Canvas != null)
                foreach (Canvas canvas in Canvas)
                    canvas?.Update();
        }
        public void SetInactive()
        {
            if (Canvas == null) return;
            foreach (Canvas canvas in Canvas)
                canvas.IsActive = false;
        }
        public void SetActive()
        {
            if (Canvas == null) return;
            foreach (Canvas canvas in Canvas)
                canvas.IsActive = true;
        }
        public void AddCanvas(Canvas canvas)
        {
            if(Canvas != null)
            {
                Canvas[] newCanvas = new Canvas[Canvas.Length + 1];
                for (int i = 0; i < Canvas.Length; ++i)
                    newCanvas[i] = Canvas[i];
                newCanvas[^1] = canvas;
                Canvas = newCanvas;
            }
        }
    }
}
