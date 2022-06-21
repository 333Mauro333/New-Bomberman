using UnityEngine;

using TMPro;


namespace NewBomberman
{
    public class DoorTextController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] TextMeshProUGUI tmpReference;



        public void UpdateDoorState(bool doorIsOpen)
        {
            if (doorIsOpen)
            {
                tmpReference.text = "DOOR STATE:\nOPEN";
            }
            else
            {
                tmpReference.text = "DOOR STATE:\nCLOSED";
            }
        }
    }
}
