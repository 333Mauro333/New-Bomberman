using UnityEngine;


namespace NewBomberman
{
    public class Key : MonoBehaviour
    {
        [SerializeField] Player p = null;


        public void DestroyAndOpenDoor()
        {
            p.ChangeDoorState(true);
            Destroy(gameObject);
        }
    }
}
