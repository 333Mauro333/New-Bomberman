using UnityEngine;


namespace NewBomberman
{
    public class PlayerMovement : CharacterMovement
    {



        void Update()
        {
            Movement();
        }


        protected override void Movement()
        {
            HorizontalMove();
            VerticalMove();
        }
        protected override void HorizontalMove()
        {
            float hS = Input.GetAxis("Player1Horizontal");

            transform.position += new Vector3(hS * hSpeed, 0.0f, 0.0f) * Time.deltaTime;
        }
        protected override void VerticalMove()
        {
            float vS = Input.GetAxis("Player1Vertical");

            transform.position += new Vector3(0.0f, 0.0f, vS * vSpeed) * Time.deltaTime;
        }
    }
}
