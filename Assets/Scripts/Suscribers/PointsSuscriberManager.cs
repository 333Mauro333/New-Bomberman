using UnityEngine;


namespace NewBomberman
{
    public class PointsSuscriberManager : MonoBehaviour
    {
        [Header("Object Event")]
        [SerializeField] Player p = null;

        [Header("Suscriptors")]
        [SerializeField] PointsTextController ptc = null;



        void OnEnable()
        {
            p.scoreChangeEvent += ptc.UpdatePoints;
        }

        void OnDisable()
        {
            p.scoreChangeEvent -= ptc.UpdatePoints;
        }
    }
}
