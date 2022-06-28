using System;

using UnityEngine;


namespace NewBomberman
{
    public class Key : MonoBehaviour, IPickable
    {
        public Action pickedEvent;



        public void Pick()
        {
            pickedEvent?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
