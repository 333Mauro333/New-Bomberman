using UnityEngine;


namespace NewBomberman
{
    public class Key : MonoBehaviour, IPickable
    {
        public PickableItemHandler pickedEvent;



        public void Pick()
        {
            pickedEvent?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
