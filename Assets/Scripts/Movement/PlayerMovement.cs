using UnityEngine;


namespace NewBomberman
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Button Names")]
        [SerializeField] string upButtonName = "";
        [SerializeField] string downButtonName = "";
        [SerializeField] string leftButtonName = "";
        [SerializeField] string rightButtonName = "";

        [Header("Speed Values")]
        [SerializeField] float forwardSpeed = 0.0f;
        [SerializeField] float lateralSpeed = 0.0f;

        [SerializeField] bool backwardsGoesHalfSpeed = false;


        CharacterController cc;

        bool isMovingForward;
        bool isMovingBackward;
        bool isMovingLeft;
        bool isMovingRight;



        void Awake()
        {
            cc = GetComponent<CharacterController>();

            isMovingForward = false;
            isMovingBackward = false;
            isMovingLeft = false;
            isMovingRight = false;
        }

        void Update()
        {
            CheckMovement();
        }

        void FixedUpdate()
        {
            Movement();
        }



        void CheckMovement()
        {
            isMovingForward = Input.GetButton(upButtonName);
            isMovingBackward = Input.GetButton(downButtonName);
            isMovingLeft = Input.GetButton(leftButtonName);
            isMovingRight = Input.GetButton(rightButtonName);
        }
        void Movement()
        {
            if (isMovingForward)
            {
                MoveForward();
            }

            if (isMovingBackward)
            {
                MoveBackward();
            }

            if (isMovingLeft)
            {
                MoveLeft();
            }

            if (isMovingRight)
            {
                MoveRight();
            }
        }

        void MoveForward()
        {
            cc.Move(transform.forward * forwardSpeed * Time.deltaTime);
        }
        void MoveBackward()
        {
            if (backwardsGoesHalfSpeed)
            {
                cc.Move(-transform.forward * (forwardSpeed / 2.0f) * Time.deltaTime);
            }
            else
            {
                cc.Move(-transform.forward * forwardSpeed * Time.deltaTime);
            }
        }
        void MoveLeft()
        {
            cc.Move(-transform.right * lateralSpeed * Time.deltaTime);
        }
        void MoveRight()
        {
            cc.Move(transform.right * lateralSpeed * Time.deltaTime);
        }
    }
}
