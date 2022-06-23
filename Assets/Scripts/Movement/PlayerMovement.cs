using UnityEngine;


namespace NewBomberman
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] string upButtonName = "";
        [SerializeField] string downButtonName = "";
        [SerializeField] string leftButtonName = "";
        [SerializeField] string rightButtonName = "";

        [SerializeField] float forwardSpeed = 0.0f;
        [SerializeField] float lateralSpeed = 0.0f;

        CharacterController cc;



        void Awake()
        {
            cc = GetComponent<CharacterController>();
        }

        void Update()
        {
            Movement();
        }



        void Movement()
        {
            if (Input.GetButton(upButtonName))
            {
                MoveForward();
            }

            if (Input.GetButton(downButtonName))
            {
                MoveBackward();
            }

            if (Input.GetButton(leftButtonName))
            {
                MoveLeft();
            }

            if (Input.GetButton(rightButtonName))
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
            cc.Move(-transform.forward * (forwardSpeed / 2.0f) * Time.deltaTime);
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
