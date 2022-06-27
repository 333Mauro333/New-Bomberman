using UnityEngine;


namespace NewBomberman
{
    public class Player : MonoBehaviour, IDestroyable, IPointsSubject, IDoorStateSubject
    {
        GameManager gm = null;

        int points;

        public ScoreChangeHandler scoreChangeEvent;
        public DoorStateHandler doorStateChangeEvent;



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
            if (other.gameObject.CompareTag("Key"))
            {
                doorStateChangeEvent(true);
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

        public void NotifyChangePoints(int newPoints)
        {
            points = newPoints;
            scoreChangeEvent(points);
        }

        public void NotifyDoorStateChange(bool isOpen)
        {
            doorStateChangeEvent(isOpen);
        }

        public void AddPoints(int pointsToAdd)
        {
            points += pointsToAdd;
            NotifyChangePoints(points);
        }

        void EndGame(bool win)
        {
            gm.SetFinalGame(points, win);
            gm.LoadScene("Results Scene");
        }
    }
}
