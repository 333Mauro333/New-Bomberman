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
        [SerializeField] EnemyMovement em = null;
        [SerializeField] LightController lc = null;



        void OnEnable()
        {
            k.pickedEvent += d.ConvertColliderToTrigger;
            k.pickedEvent += dtc.ChangeDoorStateMessage;
            k.pickedEvent += em.StartToFollow;
            k.pickedEvent += lc.SwitchColor;
        }

        void OnDisable()
        {
            k.pickedEvent -= d.ConvertColliderToTrigger;
            k.pickedEvent -= dtc.ChangeDoorStateMessage;
            k.pickedEvent -= em.StartToFollow;
            k.pickedEvent += lc.SwitchColor;
        }
    }
}
