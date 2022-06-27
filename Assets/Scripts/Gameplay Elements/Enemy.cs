using UnityEngine;


namespace NewBomberman
{
    public class Enemy : MonoBehaviour, IDestroyable
    {
        public void DestroyItSelf()
        {
            Destroy(gameObject);
        }
    }
}
