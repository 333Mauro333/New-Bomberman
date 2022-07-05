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

        SphereCollider sc;

        List<IDestroyable> destroyableList;



        void Awake()
        {
            actualTime = timeToExplode;
            explodedByAnotherBomb = false;
            sc = GetComponent<SphereCollider>();
            destroyableList = new List<IDestroyable>();
        }

        void Update()
        {
            HasExploded();
            SubtractTime();
        }

		void OnTriggerEnter(Collider other)
		{
            RaycastHit raycastHit;

            if (Physics.Raycast(transform.position, other.transform.position - transform.position, out raycastHit, range))
            {
                IDestroyable id = raycastHit.transform.gameObject.GetComponent<IDestroyable>();

                if (id != null)
				{
                    destroyableList.Add(id);
				}
            }
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
        void ResetValues()
        {
            actualTime = timeToExplode;
            explodedByAnotherBomb = false;
        }

        void Explode()
        {
            sc.enabled = true;
        }
        void HasExploded()
		{
            if (sc.enabled)
			{
 				for (int i = 0; i < destroyableList.Count; i++)
				{
                    destroyableList[i].DestroyItSelf();
				}

				destroyableList.Clear();
				sc.enabled = false;
				ResetValues();
				gameObject.SetActive(false);
			}
		}
    }
}
