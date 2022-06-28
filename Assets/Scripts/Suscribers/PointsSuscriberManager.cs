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
            Player.onScoreChange += ptc.UpdatePoints;
        }

        void OnDisable()
        {
            Player.onScoreChange -= ptc.UpdatePoints;
        }
    }
}
