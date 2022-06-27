using UnityEngine;


namespace NewBomberman
{
    [RequireComponent(typeof(BoxCollider))]
    public class Door : MonoBehaviour
    {
        BoxCollider bc = null;



        void Awake()
        {
            bc = GetComponent<BoxCollider>();
        }



        public void UpdateBoxColliderState(bool isOpen)
        {
            bc.isTrigger = isOpen;
        }
    }
}
