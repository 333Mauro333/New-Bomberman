using UnityEngine;


namespace NewBomberman
{
    public class PlayerMovement : CharacterMovement
    {
        [SerializeField] string upButtonName = "";
        [SerializeField] string downButtonName = "";
        [SerializeField] string leftButtonName = "";
        [SerializeField] string rightButtonName = "";

        LimitMovement lm;



        void Awake()
        {
            lm = GetComponent<LimitMovement>();
        }

        void Update()
        {
            Movement();
        }



        protected override void Movement()
        {
            if (Input.GetButtonDown(upButtonName) && (!lm.ThereIsAnything(Direction.Up) || lm.ThereIsAnything(Direction.Up, "Key")))
            {
                MoveUp();
            }

            if (Input.GetButtonDown(downButtonName) && (!lm.ThereIsAnything(Direction.Down) || lm.ThereIsAnything(Direction.Down, "Key")))
            {
                MoveDown();
            }

            if (Input.GetButtonDown(leftButtonName) && (!lm.ThereIsAnything(Direction.Left) || lm.ThereIsAnything(Direction.Left, "Key")))
            {
                MoveLeft();
            }

            if (Input.GetButtonDown(rightButtonName) && (!lm.ThereIsAnything(Direction.Right) || lm.ThereIsAnything(Direction.Right, "Key")))
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
