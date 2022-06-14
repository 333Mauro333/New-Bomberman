using UnityEngine;


namespace NewBomberman
{
    public class EnemyMovement : CharacterMovement
    {
        float movementTimer;
        float actualTime;

        LimitMovement lM;


        private void Awake()
        {
            movementTimer = 1.0f;
            actualTime = movementTimer;

            lM = GetComponent<LimitMovement>();
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

            if (!lM.ThereIsAnything(randomDirection))
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
    }
}
