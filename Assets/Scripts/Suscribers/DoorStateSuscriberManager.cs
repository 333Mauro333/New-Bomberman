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



        void OnEnable()
        {
            k.pickedEvent += d.ConvertColliderToTrigger;
            k.pickedEvent += dtc.ChangeDoorStateMessage;
            k.pickedEvent += em.StartToFollow;
        }

        void OnDisable()
        {
            k.pickedEvent -= d.ConvertColliderToTrigger;
            k.pickedEvent -= dtc.ChangeDoorStateMessage;
            k.pickedEvent -= em.StartToFollow;
        }
    }
}
