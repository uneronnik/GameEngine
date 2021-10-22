using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    class Component
    {
        public GameObject Base { get; set; }
        public bool Enabled { get; set; }

        public virtual void Start()
        {
            
        }
        public virtual void FixedUpdate()
        {

        }
        public virtual void Update()
        {
            
        }
        
    }
}
