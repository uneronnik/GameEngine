using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GameEngine
{
    // Prefabs,
    sealed class GameObject
    {
        
        public PointF Location { get; set; }
        public PointF Rotation { get; set; }
        public PointF Scale { get; set; }
        
        public string Tag { get; set; }

        public string Name { get; private set; }
        public bool Enabled { get; set; }
        private List<Component> _components = new List<Component>();

        public GameObject(string name, string tag = "")
        {
            Tag = tag;
            Name = name;
        }
        
        public IReadOnlyList<Component> Components { get => _components.AsReadOnly(); }



        public bool TryGetComponent<T>(out T component)
        {
            foreach (Component item in _components)
            {
                if (item is T)
                {
                    component = (T)(object)item;
                    return true;
                }
            }
            component = default(T);
            return false;
        }
        public void AddComponent(Component component)
        {
            component.Base = this;
            Engine.Updated += component.Update;
            Engine.Started += component.Start;
            _components.Add(component);
        }
        public void RemoveComponent(Component component)
        {
            _components.Remove(component);
            Engine.Updated -= component.Update;
            Engine.Started -= component.Start;
        }


    }
}
