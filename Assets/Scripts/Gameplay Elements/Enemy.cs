using UnityEngine;


namespace NewBomberman
{
    public class Enemy : MonoBehaviour, IDestroyable
    {
        [Header("References")]
        [SerializeField] Transform target = null;

        [Header("Configuration")]
        [SerializeField] float speed = 0.0f;



        void Update()
        {
            if (target != null)
            {
                transform.LookAt(target);
            }
        }

        void FixedUpdate()
        {
            if (target != null)
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
        }



        public void DestroyItSelf()
        {
            Destroy(gameObject);
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }
        public bool HasTarget()
        {
            return target != null;
        }
    }
}
