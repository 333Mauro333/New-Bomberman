using UnityEngine;


namespace NewBomberman
{
    public class Door : MonoBehaviour
    {
        BoxCollider bc = null;



        void Awake()
        {
            bc = GetComponent<BoxCollider>();
        }



        public void UpdateBoxColliderState(bool isOpen)
        {
            if (bc != null && isOpen)
            {
                Destroy(bc);
            }
        }
    }
}
