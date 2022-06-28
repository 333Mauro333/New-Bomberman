using UnityEngine;

using TMPro;


namespace NewBomberman
{
    public class PointsTextController : MonoBehaviour, IObserverPoints
    {
        [Header("References")]
        [SerializeField] TextMeshProUGUI tmpReference = null;

        int points;



        void Awake()
        {
            points = 0;
        }



        public void UpdatePoints(int points)
        {
            this.points = points;
            tmpReference.text = "POINTS\n" + this.points.ToString("000000");
        }
    }
}
