using UnityEngine;


namespace NewBomberman
{
    public class Key : MonoBehaviour
    {
        public void SetState(bool exists)
        {
            gameObject.SetActive(!exists);
        }
    }
}
