using UnityEngine;


namespace NewBomberman
{
    public class PointsSuscriberManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] Player p = null;
        [SerializeField] PointsTextController ptc = null;



        void Start()
        {
            p.scoreChangeEvent += ptc.UpdatePoints;
        }
    }
}
