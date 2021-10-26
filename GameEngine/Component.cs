namespace GameEngine
{
    class Component
    {
        public GameObject Base { get; set; }
        public bool Enabled { get; set; }

        public virtual void Start()
        {
            
        }
        public virtual void Update()
        {
            
        }
        public virtual void OnTrigerEnter(GameObject gameObject)
        {

        }
        public virtual void OnTrigerStay(GameObject gameObject)
        {

        }
        public virtual void OnTrigerExit(GameObject gameObject)
        {

        }
        public virtual void OnColliderEnter(GameObject gameObject)
        {

        }
        public virtual void OnColliderExit(GameObject gameObject)
        {

        }
    }
}
