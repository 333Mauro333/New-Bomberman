using UnityEngine;

using TMPro;


namespace NewBomberman
{
    public class FinalText : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI tmp;

        GameManager gm;


        void Start()
        {
            gm = FindObjectOfType<GameManager>();

            if (gm.win)
            {
                tmp.text = "¡CONGRATULATIONS! ¡YOU WIN!\nSCORE: " + gm.score.ToString("000000");
            }
            else
            {
                tmp.text = "YOU LOSE.\nSCORE: " + gm.score.ToString("000000");
            }
        }
    }
}
