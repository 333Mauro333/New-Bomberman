using UnityEngine;


public class Bomb : MonoBehaviour
{
    [SerializeField] float timeToExplode = 0.0f;


    void Update()
    {
        CheckTime();
    }

    void CheckTime()
    {
        timeToExplode = (timeToExplode - Time.deltaTime <= 0.0f) ? 0.0f : timeToExplode - Time.deltaTime;

        if (timeToExplode == 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
