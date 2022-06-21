using UnityEngine;


namespace NewBomberman
{
    public class BreakableBlock : MonoBehaviour, IDestroyable
    {
        const int blockValue = 10;



        public void DestroyItSelf()
        {
            FindObjectOfType<Player>().AddPoints(blockValue);
            Destroy(gameObject);
        }
    }
}
