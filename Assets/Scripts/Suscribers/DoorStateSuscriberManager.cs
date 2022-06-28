using UnityEngine;


namespace NewBomberman
{
    public class DoorStateSuscriberManager : MonoBehaviour
    {
        [Header("Object Event")]
        [SerializeField] Key k = null;

        [Header("Suscriptors")]
        [SerializeField] Door d = null;
        [SerializeField] DoorTextController dtc = null;



        void OnEnable()
        {
            k.pickedEvent += d.ConvertColliderToTrigger;
            k.pickedEvent += dtc.ChangeDoorStateMessage;
        }

        void OnDisable()
        {
            k.pickedEvent -= d.ConvertColliderToTrigger;
            k.pickedEvent -= dtc.ChangeDoorStateMessage;
        }
    }
}
