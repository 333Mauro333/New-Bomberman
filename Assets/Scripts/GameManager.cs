using UnityEngine;
using UnityEngine.SceneManagement;


namespace NewBomberman
{
    public class GameManager : MonoBehaviour
    {
        public GameManager instance;

        public bool forLeftHanded = false;

        public bool win = false;
        public int score = 0;



        void Awake()
        {
            Initialize();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Menu");
            }
        }



        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void QuitGame()
        {
            #if UNITY_EDITOR

            UnityEditor.EditorApplication.isPlaying = false;

            #elif UNITY_STANDALONE_WIN
            
            Application.Quit();

            #endif
        }



        public void SetFinalGame(int score, bool win)
        {
            this.score = score;
            this.win = win;
        }

        void Initialize()
        {
            // Si no hay una instancia del GameManager...
            if (instance == null)
            {
                // Este controlador se convierte en la escena.
                instance = this;

                // No me destruyo al cargar la escena.
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                // Para qué quiero crearme si ya hay una instancia de mí? Me destruyo.
                Destroy(gameObject);
            }
        }
    }
}
