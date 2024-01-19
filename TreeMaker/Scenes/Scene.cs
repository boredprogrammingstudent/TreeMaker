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
        public static Scene? currScene;
        public Canvas[]? Canvas;
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
    }
}
