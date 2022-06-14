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
            HorizontalMove();
            VerticalMove();
        }
        protected override void HorizontalMove()
        {
            if (Input.GetButtonDown(leftButtonName) && !lM.ThereIsAnything(Direction.Left))
            {
                transform.position += -Vector3.right;
            }

            if (Input.GetButtonDown(rightButtonName) && !lM.ThereIsAnything(Direction.Right))
            {
                transform.position += new Vector3(1.0f, 0.0f, 0.0f);
            }
        }
        protected override void VerticalMove()
        {
            if (Input.GetButtonDown(upButtonName) && !lM.ThereIsAnything(Direction.Up))
            {
                transform.position += new Vector3(0.0f, 0.0f, 1.0f);
            }

            if (Input.GetButtonDown(downButtonName) && !lM.ThereIsAnything(Direction.Down))
            {
                transform.position += new Vector3(0.0f, 0.0f, -1.0f);
            }
        }
    }
}
