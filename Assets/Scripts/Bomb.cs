using UnityEngine;


namespace NewBomberman
{
    public class Bomb : MonoBehaviour, IReachable
    {
        [SerializeField] float timeToExplode = 0.0f;

        LineRenderer lR;

        

        void Awake()
        {
            lR = GetComponent<LineRenderer>();
            lR.SetWidth(0.01f, 0.01f);
        }

        void Start()
        {
            Debug.Log(transform.position);

            lR.SetPosition(0, transform.position);
            lR.SetPosition(1, new Vector3(transform.position.x + 3.0f, transform.position.y, transform.position.z));
        }

        void Update()
        {
            CheckTime();
            ReachRange();
        }

        void CheckTime()
        {
            timeToExplode = (timeToExplode - Time.deltaTime <= 0.0f) ? 0.0f : timeToExplode - Time.deltaTime;

            if (timeToExplode <= 0.0f)
            {
                Destroy(gameObject);
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            IDestroyable id = other.GetComponent<IDestroyable>();

            if (timeToExplode <= 0.0f)
            {
                if (id != null)
                {
                    id.Destroy();
                }
            }
        }

        public void ReachRange()
        {

        }
    }
}
