using UnityEngine;


namespace NewBomberman
{
    public class Enemy : MonoBehaviour, IDestroyable
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
