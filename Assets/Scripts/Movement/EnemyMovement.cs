using UnityEngine;


namespace NewBomberman
{
    public class EnemyMovement : CharacterMovement
    {
        float secondsToMove;
        float actualTime;

        LimitMovement lM;


        void Awake()
        {
            secondsToMove = 1.0f;
            actualTime = secondsToMove;

            lM = GetComponent<LimitMovement>();
        }

        void Update()
        {
            Movement();
        }


        public void SetTimeToMove(float seconds)
        {
            secondsToMove = seconds;
        }

        protected override void Movement()
        {
            if (actualTime <= 0.0f)
            {
                Direction randomDirection = (Direction)Random.Range(0, 4);


                actualTime = secondsToMove;

                if (!lM.ThereIsAnything(randomDirection) || lM.ThereIsAnything(randomDirection, "Player"))
                {
                    switch (randomDirection)
                    {
                        case Direction.Up:
                            MoveUp();
                            break;

                        case Direction.Down:
                            MoveDown();
                            break;

                        case Direction.Left:
                            MoveLeft();
                            break;

                        case Direction.Right:
                            MoveRight();
                            break;
                    }
                }
            }
            else
            {
                actualTime = (actualTime - Time.deltaTime > 0.0f) ? actualTime - Time.deltaTime : 0.0f;
            }
        }

        protected override void MoveUp()
        {
            transform.position += Vector3.forward;
        }
        protected override void MoveDown()
        {
            transform.position -= Vector3.forward;
        }
        protected override void MoveLeft()
        {
            transform.position -= Vector3.right;
        }
        protected override void MoveRight()
        {
            transform.position += Vector3.right;
        }
    }
}
