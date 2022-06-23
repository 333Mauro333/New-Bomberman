using UnityEngine;


namespace NewBomberman
{
    public class CameraRotation : MonoBehaviour
    {
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


            //transform.RotateAround(transform.position, Vector3.up, rotateHorizontal * sensitivity); //use transform.Rotate(-transform.up * rotateHorizontal * sensitivity) instead if you dont want the camera to rotate around the player
            transform.Rotate(transform.up * rotateHorizontal * sensitivity);
            //Camera.main.transform.RotateAround(transform.position + new Vector3(0.0f, 2.19f, 0.0f), -transform.right, rotateVertical * sensitivity); // again, use transform.Rotate(transform.right * rotateVertical * sensitivity) if you don't want the camera to rotate around the player
            Camera.main.transform.Rotate(-transform.right * rotateVertical * sensitivity);

            Camera.main.transform.rotation = Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, 0.0f);

            if (Camera.main.transform.localRotation.eulerAngles.x > 65.0f && Camera.main.transform.localRotation.eulerAngles.x < 90.0f)
            {
                Camera.main.transform.rotation = Quaternion.Euler(65.0f, Camera.main.transform.rotation.eulerAngles.y, Camera.main.transform.rotation.eulerAngles.z);
            }
            else if (Camera.main.transform.localRotation.eulerAngles.x > 220.0f && Camera.main.transform.localRotation.eulerAngles.x < 280.0f)
            {
                Camera.main.transform.rotation = Quaternion.Euler(280.0f, Camera.main.transform.rotation.eulerAngles.y, Camera.main.transform.rotation.eulerAngles.z);
            }
        }
    }
}
