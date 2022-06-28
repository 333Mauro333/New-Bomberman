using UnityEngine;

using TMPro;


namespace NewBomberman
{
    public class ToggleController : MonoBehaviour
    {
        GameManager gm = null;



        void Start()
        {
            gm = FindObjectOfType<GameManager>();
        }
    }
}
