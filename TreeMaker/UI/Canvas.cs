using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeMaker.UI
{
    //The order in which you add stuff is the reverse order in which they will execute
    
    class Canvas
    {
        public bool IsActive
        {
            get => isActive;
            set
            {
                isActive = value;
                foreach(UI elem in Elements)
                    elem.isActive = value;
            }
        }
        bool isActive;
        readonly List<UI> Elements = new();
        readonly List<Action> PreUpdate = new();
        readonly List<Action> PostUpdate = new();
        public UI this[int i] { get => Elements[i]; set => Elements[i] = value; }
        public void AddElem(params UI[] elements)
        {
            foreach(var elem in elements)
            {
                Elements.Add(elem);
            }
        }
        public void AddPreUpdate(params Action[] action)
        {
            foreach(var elem in action)
            {
                PreUpdate.Add(elem);
            }
        }
        public void AddPostUpdate(params Action[] action)
        {
            foreach(var elem in action)
            {
                PostUpdate.Add(elem);
            }
        }
        public void Remove(UI elem) => Elements.Remove(elem);
        public void Clear() => Elements.Clear();
        public virtual void Update()
        {
            foreach(var action in PreUpdate)
            {
                action();
            }
            foreach (var elem in Elements)
            {
                elem.Update();
            }
            foreach(var action in PostUpdate)
            {
                action();
            }
        }
    }
}
