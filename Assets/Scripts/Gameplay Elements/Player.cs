using UnityEngine;


namespace NewBomberman
{
    public class Player : MonoBehaviour, IDestroyable, IPointsSubject
    {
        public ScoreChangeHandler scoreChangeEvent;

        GameManager gm = null;

        public int points;



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

            if (iP != null)
            {
                iP.Pick();
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


            if (scoreChangeEvent != null)
            {
                Debug.Log("Grita evento.");
                scoreChangeEvent(newPoints);

            }
        }

        void EndGame(bool win)
        {
            gm.SetFinalGame(points, win);
            gm.LoadScene("Results Scene");
        }
    }
}
