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




        public void UpdateDoorState(bool isOpen)
        {
            if (isOpen)
            {
                tmpReference.text = openMessage;
            }
            else
            {
                tmpReference.text = closedMessage;
            }
        }
    }
}
