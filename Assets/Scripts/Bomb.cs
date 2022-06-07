using UnityEngine;


namespace NewBomberman
{
    public class Bomb : MonoBehaviour, IReachable
    {
        [SerializeField] float timeToExplode = 0.0f;
        [SerializeField] float range = 3.0f;

        LineRenderer lR;

        

        void Awake()
        {
            lR = GetComponent<LineRenderer>();
            lR.SetWidth(0.01f, 0.01f);
        }

        void Start()
        {
            lR.SetPosition(0, transform.position);
            lR.SetPosition(1, new Vector3(transform.position.x + range, transform.position.y, transform.position.z));
        }

        void Update()
        {
            SubtractTime();
        }

        void SubtractTime()
        {
            timeToExplode = (timeToExplode - Time.deltaTime <= 0.0f) ? 0.0f : timeToExplode - Time.deltaTime;

            if (timeToExplode <= 0.0f)
            {
                ReachRange();
                Destroy(gameObject);
            }
        }


        public void ReachRange()
        {
            SearchObjective(Direction.Up);
            SearchObjective(Direction.Down);
            SearchObjective(Direction.Left);
            SearchObjective(Direction.Right);
        }

        void SearchObjective(Direction direction)
        {
            Vector3 vectorD = Vector3.zero;
            RaycastHit ray;


            switch (direction)
            {
                case Direction.Up:
                    vectorD = transform.forward;
                    break;

                case Direction.Down:
                    vectorD = -transform.forward;
                    break;

                case Direction.Left:
                    vectorD = -transform.right;
                    break;

                case Direction.Right:
                    vectorD = transform.right;
                    break;
            }

            if (Physics.Raycast(transform.position, vectorD, out ray, range))
            {
                IDestroyable id = ray.transform.gameObject.GetComponent<IDestroyable>();

                if (id != null)
                {
                    id.Destroy();
                }
            }
        }
    }
}
