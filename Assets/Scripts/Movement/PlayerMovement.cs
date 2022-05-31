using UnityEngine;


namespace NewBomberman
{
    public class PlayerMovement : CharacterMovement
    {
        [SerializeField] KeyCode up = KeyCode.None;
        [SerializeField] KeyCode down = KeyCode.None;
        [SerializeField] KeyCode left = KeyCode.None;
        [SerializeField] KeyCode right = KeyCode.None;


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
            if (Input.GetKeyDown(left) && !ThereIsABlock(Direction.Left))
            {
                transform.position += -Vector3.right;
            }

            if (Input.GetKeyDown(right) && !ThereIsABlock(Direction.Right))
            {
                transform.position += new Vector3(1.0f, 0.0f, 0.0f);
            }
        }
        protected override void VerticalMove()
        {
            if (Input.GetKeyDown(up) && !ThereIsABlock(Direction.Up))
            {
                transform.position += new Vector3(0.0f, 0.0f, 1.0f);
            }

            if (Input.GetKeyDown(down) && !ThereIsABlock(Direction.Down))
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
