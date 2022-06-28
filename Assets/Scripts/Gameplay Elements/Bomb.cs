using System.Collections.Generic;

using UnityEngine;


namespace NewBomberman
{
    public class Bomb : MonoBehaviour, IDestroyable
    {
        [Header("Setting Values")]
        [SerializeField] float timeToExplode = 0.0f;
        [SerializeField] float range = 3.0f;

        float actualTime;
        bool explodedByAnotherBomb;
        


        void Awake()
        {
            actualTime = timeToExplode;
            explodedByAnotherBomb = false;
        }

        void Update()
        {
            SubtractTime();
        }



        public void DestroyItSelf()
        {
            if (!explodedByAnotherBomb)
            {
                explodedByAnotherBomb = true;
                Explode();
            }
        }

        void SubtractTime()
        {
            actualTime = (actualTime - Time.deltaTime <= 0.0f) ? 0.0f : actualTime - Time.deltaTime;

            if (actualTime <= 0.0f)
            {
                Explode();
            }
        }
        void SeekAndDestroy()
        {
            List<IDestroyable> destroyableGameObjects = new List<IDestroyable>();
            Vector3 diff = new Vector3(0.0f, 0.25f, 0.0f);
            RaycastHit ray;


            for (int i = 0; i < 4; i++)
            {
                Vector3 vectorD = GetVectorDirection((Direction)i);

                if (Physics.Raycast(transform.position + diff, vectorD, out ray, range))
                {
                    IDestroyable iD = ray.transform.gameObject.GetComponent<IDestroyable>();


                    if (iD != null)
                    {
                        destroyableGameObjects.Add(iD);
                    }
                }
            }

            for (int i = 0; i < destroyableGameObjects.Count; i++)
            {
                destroyableGameObjects[i].DestroyItSelf();
            }
        }
        void ResetValues()
        {
            actualTime = timeToExplode;
            explodedByAnotherBomb = false;
        }

        void Explode()
        {
            SeekAndDestroy();
            ResetValues();
            gameObject.SetActive(false);
        }

        Vector3 GetVectorDirection(Direction direction)
        {
            Vector3 vectorToReturn = Vector3.zero;


            switch (direction)
            {
                case Direction.Up:
                    vectorToReturn = transform.forward;
                    break;

                case Direction.Down:
                    vectorToReturn = -transform.forward;
                    break;

                case Direction.Left:
                    vectorToReturn = -transform.right;
                    break;

                case Direction.Right:
                    vectorToReturn = transform.right;
                    break;
            }

            return vectorToReturn;
        }
    }
}
