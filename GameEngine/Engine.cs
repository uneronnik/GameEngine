using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameEngine
{
    static class Engine
    {
        public delegate void UpdateHandler();
        public static event UpdateHandler Updated;
        public delegate void StartHandler();
        public static event StartHandler Started;
        static List<GameObject> _objects = new List<GameObject>();
        static public BufferedGraphics graphicsBuffer;
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
            Task graphicsTask = new Task(() =>
            {
                
                foreach (var component in Camera.Components)
                {
                    component.Update();
                }
                List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();
                foreach (var gameObject in Objects)
                {
                    foreach (var component in gameObject.Components)
                    {
                        if (component is SpriteRenderer)
                        {
                            spriteRenderers.Add((SpriteRenderer)component);
                        }
                    }
                }
                spriteRenderers.Sort((left, right) => 
                {
                    if (left.OrderInRender > right.OrderInRender)
                        return -1;
                    else if (left.OrderInRender < right.OrderInRender)
                        return 1;
                    else
                        return 0; 
                });
                foreach (var renderer in spriteRenderers)
                {
                    lock (graphicsBuffer)
                    {
                        renderer.Update();
                    }
                }


            });
            Task otherTask = new Task(() =>
            {

                foreach (var gameObject in Objects)
                {
                    foreach (var component in gameObject.Components)
                    {
                        if (!(component is SpriteRenderer))
                            component.Update();
                    }
                }

            });

            
            graphicsTask.Start();
            otherTask.Start();
            Task.WaitAll(graphicsTask, otherTask);


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
