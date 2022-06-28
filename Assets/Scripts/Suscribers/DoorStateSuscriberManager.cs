using UnityEngine;


namespace NewBomberman
{
    public class DoorStateSuscriberManager : MonoBehaviour
    {
        [Header("Object Event")]
        [SerializeField] Player p = null;

        [Header("Suscriptors")]
        [SerializeField] Key k = null;
        [SerializeField] Door d = null;
        [SerializeField] DoorTextController dtc = null;



        void Start()
        {
            p.doorStateChangeEvent += k.SetState;
            p.doorStateChangeEvent += d.UpdateBoxColliderState;
            p.doorStateChangeEvent += dtc.UpdateDoorState;
        }
    }
}
