using UnityEngine;


namespace NewBomberman
{
    public class BombGenerator : MonoBehaviour
    {
        [SerializeField] GameObject prefabBomb = null;
        [SerializeField] string bombButtonName = "";


        private void Update()
        {
            if (Input.GetButtonDown(bombButtonName))
            {
                PutBomb();
            }
        }



        void PutBomb()
        {
            GameObject currBomb = Instantiate(prefabBomb);

            currBomb.transform.position = new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2.0f + currBomb.transform.localScale.y / 2.0f, transform.position.z);
        }
    }
}
