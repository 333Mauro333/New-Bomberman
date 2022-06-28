using UnityEngine;


namespace NewBomberman
{
    public class BreakableBlock : MonoBehaviour, IDestroyable
    {
        [SerializeField] int blockValue = 10;

        Player p;



        void Start()
        {
            p = FindObjectOfType<Player>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                DestroyItSelf();
            }
        }


        public void DestroyItSelf()
        {
            p.AddPoints(blockValue);
            Destroy(gameObject);
        }
    }
}
