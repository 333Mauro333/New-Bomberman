using UnityEngine;


namespace NewBomberman
{
    public abstract class CharacterMovement : MonoBehaviour
    {
        [SerializeField] protected float hSpeed = 0.0f;
        [SerializeField] protected float vSpeed = 0.0f;


        protected abstract void Movement();
        protected abstract void HorizontalMove();
        protected abstract void VerticalMove();
    }
}
