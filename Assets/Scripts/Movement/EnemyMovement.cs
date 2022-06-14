using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewBomberman
{
    public class EnemyMovement : CharacterMovement
    {
        float movementTimer;
        float actualTime;


        private void Awake()
        {
            movementTimer = 1.0f;
            actualTime = movementTimer;
        }

        void Update()
        {
            Movement();
        }


        protected override void Movement()
        {
            if (actualTime <= 0.0f)
            {
                actualTime = movementTimer;
                HorizontalMove();
            }
            else
            {
                actualTime = (actualTime - Time.deltaTime > 0.0f) ? actualTime - Time.deltaTime : 0.0f;
            }
        }



        protected override void HorizontalMove()
        {
            Direction randomDirection = (Direction)Random.Range(2, 4); // Para el movimiento horizontal (izquierda y derecha).

            if (!ThereIsABlock(randomDirection))
            {
                switch (randomDirection)
                {
                    case Direction.Left:
                        transform.position -= Vector3.right;
                        break;

                    case Direction.Right:
                        transform.position += Vector3.right;
                        break;
                }
            }
        }
        protected override void VerticalMove()
        {

        }


        bool ThereIsABlock(Direction d)
        {
            RaycastHit raycast;
            Vector3 direction;


            switch (d)
            {
                case Direction.Up:
                    direction = transform.forward;
                    break;

                case Direction.Down:
                    direction = -transform.forward;
                    break;

                case Direction.Left:
                    direction = -transform.right;
                    break;

                case Direction.Right:
                    direction = transform.right;
                    break;

                default:
                    return false;
            }

            return Physics.Raycast(transform.position, direction, out raycast, transform.localScale.x);
        }
    }
}
