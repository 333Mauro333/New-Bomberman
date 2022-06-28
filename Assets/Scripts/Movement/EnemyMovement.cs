using UnityEngine;


namespace NewBomberman
{
    public class EnemyMovement : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] Transform target = null;

        [Header("Speed Configuration")]
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
