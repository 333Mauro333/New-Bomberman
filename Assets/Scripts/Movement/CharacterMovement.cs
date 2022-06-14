using UnityEngine;


namespace NewBomberman
{
    [RequireComponent(typeof(LimitMovement))]
    public abstract class CharacterMovement : MonoBehaviour
    {
        protected float hSpeed = 0.0f;
        protected float vSpeed = 0.0f;


        protected abstract void Movement();

        protected abstract void MoveUp();
        protected abstract void MoveDown();
        protected abstract void MoveLeft();
        protected abstract void MoveRight();
    }
}
