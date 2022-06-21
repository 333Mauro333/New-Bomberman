using UnityEngine;


namespace NewBomberman
{
    public class GameManagerReferenceSearcher : MonoBehaviour
    {
        public GameManager instance = null;



        void Start()
        {
            instance = FindObjectOfType<GameManager>();
        }


        public void LoadScene(string sceneName)
        {
            instance.LoadScene(sceneName);
        }
    }
}
