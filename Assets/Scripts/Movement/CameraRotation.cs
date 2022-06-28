using UnityEngine;


namespace NewBomberman
{
    public class CameraRotation : MonoBehaviour
    {
        [Header("Button Names")]
        [SerializeField] string mouseXAxisName = "";
        [SerializeField] string mouseYAxisName = "";

        [Header("References")]
        [SerializeField] Camera camera = null;

        [Header("Speed Configuration")]
        [SerializeField] float sensitivity = 0.0f;

        [Header("Angle Configuration")]
        [SerializeField] float verticalDownAngle = 0.0f;



        void Update()
        {
            RotatoryMotion();
        }



        void RotatoryMotion()
        {
            float rotateHorizontal = Input.GetAxis(mouseXAxisName);
            float rotateVertical = Input.GetAxis(mouseYAxisName);


            transform.Rotate(0.0f, rotateHorizontal * sensitivity, 0.0f);

            Vector3 rotation = camera.transform.localEulerAngles;
            rotation.x = (rotation.x - rotateVertical * sensitivity + 360) % 360;

            if (rotation.x > verticalDownAngle && rotation.x < 180.0f)
            {
                rotation.x = verticalDownAngle;
            }
            else if (rotation.x < 280.0f && rotation.x > 180.0f)
            {
                rotation.x = 280.0f;
            }

            camera.transform.localEulerAngles = rotation;
        }
    }
}
