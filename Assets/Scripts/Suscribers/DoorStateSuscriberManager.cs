using UnityEngine;


namespace NewBomberman
{
    public class DoorStateSuscriberManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] Player p = null;
        [SerializeField] DoorTextController dtc = null;



        void Start()
        {
            p.doorStateChangeEvent += dtc.UpdateDoorState;
        }
    }
}
