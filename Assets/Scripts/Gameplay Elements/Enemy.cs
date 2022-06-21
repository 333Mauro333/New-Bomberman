using UnityEngine;


namespace NewBomberman
{
    public class Enemy : MonoBehaviour, IDestroyable
    {
        [SerializeField] Player p = null;



        void Start()
        {
            p = FindObjectOfType<Player>();
        }

        void Update()
        {
            if (transform.position.x == p.gameObject.transform.position.x && transform.position.z == p.gameObject.transform.position.z)
            {
                p.DestroyItSelf();
            }
        }


        public void DestroyItSelf()
        {
            Destroy(gameObject);
        }
    }
}
