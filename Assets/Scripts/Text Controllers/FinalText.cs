using UnityEngine;

using TMPro;


namespace NewBomberman
{
    public class FinalText : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI tmp;


        void Start()
        {
            tmp.text = "";
        }
    }
}
