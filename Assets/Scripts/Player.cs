using UnityEngine;


namespace NewBomberman
{
    public class Player : MonoBehaviour, IDestroyable
    {



        void Start()
        {

        }

        void Update()
        {

        }


        public void DestroyItSelf()
        {
            Destroy(gameObject);
        }
    }
}
