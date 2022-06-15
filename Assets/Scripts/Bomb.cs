using UnityEngine;


namespace NewBomberman
{
    public class Bomb : MonoBehaviour, IReachable
    {
        [SerializeField] float timeToExplode = 0.0f;
        [SerializeField] float range = 1.0f;

        LineRenderer lR;
        float actualTime;

        

        void Awake()
        {
            lR = GetComponent<LineRenderer>();

            lR.startWidth = 0.01f;
            lR.endWidth = 0.01f;

            actualTime = timeToExplode;
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


        public void ReachRange()
        {
            SearchObjective(Direction.Up);
            SearchObjective(Direction.Down);
            SearchObjective(Direction.Left);
            SearchObjective(Direction.Right);
        }

        void SubtractTime()
        {
            actualTime = (actualTime - Time.deltaTime <= 0.0f) ? 0.0f : actualTime - Time.deltaTime;

            if (actualTime <= 0.0f)
            {
                ReachRange();
                ResetValues();
                gameObject.SetActive(false);
            }
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
                IDestroyable iD = ray.transform.gameObject.GetComponent<IDestroyable>();

                if (iD != null)
                {
                    iD.DestroyItSelf();
                }
            }
        }
        void ResetValues()
        {
            actualTime = timeToExplode;
        }
    }
}
