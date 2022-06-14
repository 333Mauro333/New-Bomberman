using UnityEngine;


namespace NewBomberman
{
    public class BreakableBlock : MonoBehaviour, IDestroyable
    {
        public void Destroy()
        {
            Debug.Log("Bloque destruible detecto que debe romperse.");
            Destroy(gameObject);
        }
    }
}
