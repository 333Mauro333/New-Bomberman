using System;

using UnityEngine;


namespace NewBomberman
{
    public class Player : MonoBehaviour, IDestroyable, IPointsSubject
    {
        public static Action<int> onScoreChange;

        GameManager gm;

        int points;



        void Awake()
        {
            points = 0;
        }

        void Start()
        {
            gm = FindObjectOfType<GameManager>();
        }

        void OnTriggerEnter(Collider other)
        {
            IPickable iP = other.gameObject.GetComponent<IPickable>();
            IExploiter ie = other.gameObject.GetComponent<IExploiter>();

            if (iP != null)
            {
                iP.Pick();
            }

            if (ie != null)
			{
                RaycastHit raycastHit;

                if (Physics.Raycast(transform.position, other.transform.position - transform.position, out raycastHit, ie.GetExplosionRange()))
                {
                    if (raycastHit.transform.gameObject.tag == "Bomb")
					{
                        DestroyItSelf();
                    }
                }
            }

            if (other.gameObject.CompareTag("Door"))
            {
                EndGame(true);
            }

            if (other.gameObject.CompareTag("Enemy"))
            {
                EndGame(false);
            }
        }



        public void DestroyItSelf()
        {
            EndGame(false);
        }

        public void AddPoints(int pointsToAdd)
        {
            if (pointsToAdd > 0)
            {
                points += pointsToAdd;
                NotifyChangePoints(points);
            }
        }

        public void NotifyChangePoints(int newPoints)
        {
            onScoreChange?.Invoke(newPoints);
        }

        void EndGame(bool win)
        {
            gm.SetFinalGame(points, win);
            gm.LoadScene("Results Scene");
        }
    }
}
