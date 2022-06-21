using UnityEngine;


namespace NewBomberman
{
    public class Player : MonoBehaviour, IDestroyable, IPointsSubject, IDoorStateSubject
    {
        [SerializeField] Key key = null;
        [SerializeField] GameObject door = null;

        GameManager gm = null;

        int points;
        bool doorIsOpen;

        public ScoreChangeHandler scoreChangeEvent;
        public DoorStateHandler doorStateChangeEvent;



        void Awake()
        {
            points = 0;
            doorIsOpen = false;
        }

        void Start()
        {
            gm = FindObjectOfType<GameManager>();
        }

        void Update()
        {
            // Usé esta forma porque con el "OnCollisionEnter" no me funcionaba y no tuve suficiente tiempo para tratar de verificar bien a qué se debía
            // esto.
            if (key != null && transform.position.x == key.gameObject.transform.position.x && transform.position.z == key.gameObject.transform.position.z)
            {
                key.DestroyAndOpenDoor();
            }
            else if (transform.position.x == door.transform.position.x && transform.position.z == door.transform.position.z)
            {
                gm.SetFinalGame(points, true);
                gm.LoadScene("Results Scene");
            }
        }



        public void DestroyItSelf()
        {
            gm.SetFinalGame(points, false);
            gm.LoadScene("Results Scene");
        }

        public void NotifyChangePoints(int newPoints)
        {
            points = newPoints;
            scoreChangeEvent(points);
        }

        public void NotifyDoorStateChange(bool isOpen)
        {
            doorIsOpen = isOpen;
            doorStateChangeEvent(isOpen);
        }

        public void AddPoints(int pointsToAdd)
        {
            points += pointsToAdd;
            NotifyChangePoints(points);
        }

        public void ChangeDoorState(bool isOpen)
        {
            doorIsOpen = isOpen;
            doorStateChangeEvent(true);
        }
    }
}
