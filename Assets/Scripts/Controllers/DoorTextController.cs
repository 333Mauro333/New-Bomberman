using UnityEngine;

using TMPro;


namespace NewBomberman
{
    public class DoorTextController : MonoBehaviour, IObserverDoorState
    {
        [Header("Door State Messages")]
        [SerializeField] string openMessage = "";
        [SerializeField] string closedMessage = "";

        [Header("References")]
        [SerializeField] TextMeshProUGUI tmpReference;



        void Start()
        {
            tmpReference.text = closedMessage;
        }



        public void ChangeDoorStateMessage()
        {
            tmpReference.text = openMessage;
        }
    }
}
