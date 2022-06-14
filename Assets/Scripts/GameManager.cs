using UnityEngine;
using UnityEngine.SceneManagement;


namespace NewBomberman
{
    class GameManager : MonoBehaviour
    {
        public GameManager instance;



        void Awake()
        {
            //Initialize();
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

        void Initialize()
        {
            // Si no hay una instancia del SceneController...
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
