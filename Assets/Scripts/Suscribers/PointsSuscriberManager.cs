using UnityEngine;


namespace NewBomberman
{
    public class PointsSuscriberManager : MonoBehaviour
    {
        [Header("Object Event")]
        [SerializeField] Player p = null;

        [Header("Suscriptors")]
        [SerializeField] PointsTextController ptc = null;



        void Start()
        {
            p.scoreChangeEvent += ptc.UpdatePoints;
        }
    }
}
