using UnityEngine;


namespace NewBomberman
{
    public class CameraRotation : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] Camera camera = null;

        [Header("Configuration")]
        [SerializeField] string mouseXAxisName = "";
        [SerializeField] string mouseYAxisName = "";

        [SerializeField] float sensitivity = 0.0f;



        void Update()
        {
            MoveRotation();
        }



        void MoveRotation()
        {
            float rotateHorizontal = Input.GetAxis(mouseXAxisName);
            float rotateVertical = Input.GetAxis(mouseYAxisName);


            transform.Rotate(0.0f, rotateHorizontal * sensitivity, 0.0f);

            Vector3 rotation = camera.transform.localEulerAngles;
            rotation.x = (rotation.x - rotateVertical * sensitivity + 360) % 360;

            if (rotation.x > 80.0f && rotation.x < 180.0f)
            {
                rotation.x = 80.0f;
            }
            else if (rotation.x < 280.0f && rotation.x > 180.0f)
            {
                rotation.x = 280.0f;
            }

            camera.transform.localEulerAngles = rotation;
        }
    }
}
