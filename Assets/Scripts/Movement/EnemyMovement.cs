using UnityEngine;


namespace NewBomberman
{
    public class EnemyMovement : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] Transform target = null;

        [Header("Speed Configuration")]
        [SerializeField] float speed = 0.0f;


        bool follow;



		void Awake()
		{
            follow = false;
		}

		void Update()
        {
            if (target != null && follow)
            {
                transform.LookAt(target);
            }
        }

        void FixedUpdate()
        {
            if (target != null && follow)
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
        }



        public void StartToFollow()
		{
            follow = true;
		}
    }
}
