using UnityEngine;


namespace NewBomberman
{
    public class PlayerMovement : CharacterMovement
    {
        [SerializeField] string upButtonName = "";
        [SerializeField] string downButtonName = "";
        [SerializeField] string leftButtonName = "";
        [SerializeField] string rightButtonName = "";

        LimitMovement lM;



        void Awake()
        {
            lM = GetComponent<LimitMovement>();
        }

        void Update()
        {
            Movement();
        }


        protected override void Movement()
        {
            if (Input.GetButtonDown(upButtonName) && !lM.ThereIsAnything(Direction.Up))
            {
                MoveUp();
            }

            if (Input.GetButtonDown(downButtonName) && !lM.ThereIsAnything(Direction.Down))
            {
                MoveDown();
            }

            if (Input.GetButtonDown(leftButtonName) && !lM.ThereIsAnything(Direction.Left))
            {
                MoveLeft();
            }

            if (Input.GetButtonDown(rightButtonName) && !lM.ThereIsAnything(Direction.Right))
            {
                MoveRight();
            }
        }

        protected override void MoveUp()
        {
            transform.position += new Vector3(0.0f, 0.0f, 1.0f);
        }
        protected override void MoveDown()
        {
            transform.position += new Vector3(0.0f, 0.0f, -1.0f);
        }
        protected override void MoveLeft()
        {
            transform.position += -Vector3.right;
        }
        protected override void MoveRight()
        {
            transform.position += new Vector3(1.0f, 0.0f, 0.0f);
        }
    }
}
