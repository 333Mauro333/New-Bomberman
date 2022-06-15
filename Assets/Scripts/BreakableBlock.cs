using UnityEngine;


namespace NewBomberman
{
    public class BreakableBlock : MonoBehaviour, IDestroyable
    {
        public void DestroyItSelf()
        {
            Debug.Log("Bloque destruible detecto que debe romperse.");
            Destroy(gameObject);
        }
    }
}
