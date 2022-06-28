using UnityEngine;


namespace NewBomberman
{
    public class Player : MonoBehaviour, IDestroyable, IPointsSubject, IDoorStateSubject
    {
        public ScoreChangeHandler scoreChangeEvent;
        public DoorStateHandler doorStateChangeEvent;

        GameManager gm = null;

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
            if (other.gameObject.CompareTag("Key"))
            {
                Debug.Log("Entró");
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
            scoreChangeEvent?.Invoke(newPoints);
        }

        public void NotifyDoorStateChange(bool isOpen)
        {
            doorStateChangeEvent?.Invoke(isOpen);
        }

        void EndGame(bool win)
        {
            gm.SetFinalGame(points, win);
            gm.LoadScene("Results Scene");
        }
    }
}
