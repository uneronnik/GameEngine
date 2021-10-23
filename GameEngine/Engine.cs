using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GameEngine
{
    static class Engine
    {
        public delegate void UpdateHandler();
        public static event UpdateHandler Updated;
        public delegate void StartHandler();
        public static event StartHandler Started;
        static List<GameObject> _objects = new List<GameObject>();
        static public Graphics graphics;
        static public Form1 form;
        static public GameObject Camera { get; set; } = new GameObject("camera"); 
        static public IReadOnlyList<GameObject> Objects { get => _objects.AsReadOnly(); }
        public static void CreateObject(GameObject instance)
        {
            if (_objects.Contains(instance))
                return;
            foreach (var item in _objects)
            {
                if (item.Name == instance.Name)
                    return;
            }
            foreach (var component in instance.Components)
            {
                Updated += component.Update;
                Started += component.Start;
            }
            _objects.Add(instance);
        }
        
        public static GameObject GetObjectByName(string name)
        {
            foreach (var item in _objects)
            {
                if (item.Name == name)
                    return item;
            }
            return null;
        }
        public static List<GameObject> GetObjectsByTag(string tag)
        {
            List<GameObject> objectsWithCorrectTag = new List<GameObject>();
            foreach (var item in objectsWithCorrectTag)
            {
                if(item.Tag == tag)
                {
                    objectsWithCorrectTag.Add(item);
                }
            }
            return objectsWithCorrectTag;
        }

        public static void Update()
        {
            Updated?.Invoke();
        }
        public static void DeleteObject(GameObject gameObject)
        {
            if (!_objects.Contains(gameObject))
                return;
            foreach (var component in gameObject.Components)
            {
                
                Updated -= component.Update;
                Started -= component.Start;
            }
            _objects.Remove(gameObject);
        }
    }
}
