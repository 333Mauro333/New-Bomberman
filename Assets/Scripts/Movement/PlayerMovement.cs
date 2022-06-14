using UnityEngine;


namespace NewBomberman
{
    public class PlayerMovement : CharacterMovement
    {
        [SerializeField] string upButtonName = "";
        [SerializeField] string downButtonName = "";
        [SerializeField] string leftButtonName = "";
        [SerializeField] string rightButtonName = "";


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
            if (Input.GetButtonDown(leftButtonName) && !ThereIsABlock(Direction.Left))
            {
                transform.position += -Vector3.right;
            }

            if (Input.GetButtonDown(rightButtonName) && !ThereIsABlock(Direction.Right))
            {
                transform.position += new Vector3(1.0f, 0.0f, 0.0f);
            }
        }
        protected override void VerticalMove()
        {
            if (Input.GetButtonDown(upButtonName) && !ThereIsABlock(Direction.Up))
            {
                transform.position += new Vector3(0.0f, 0.0f, 1.0f);
            }

            if (Input.GetButtonDown(downButtonName) && !ThereIsABlock(Direction.Down))
            {
                transform.position += new Vector3(0.0f, 0.0f, -1.0f);
            }
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

            if (Physics.Raycast(transform.position, direction, out raycast, transform.localScale.x))
            {
                return raycast.collider.CompareTag("Unbreakable");
            }

            return false;
        }
    }
}
