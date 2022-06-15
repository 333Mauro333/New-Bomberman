using UnityEngine;

using System.Collections.Generic;


namespace NewBomberman
{
    public class BombGenerator : MonoBehaviour
    {
        [SerializeField] GameObject prefabBomb = null;
        [SerializeField] string bombButtonName = "";

        List<Bomb> bombs;
        ushort defaultSize;


        void Awake()
        {
            bombs = new List<Bomb>();

            defaultSize = 2;
        }

        void Start()
        {
            for (int i = 0; i < defaultSize; i++)
            {
                GameObject currBomb = Instantiate(prefabBomb);


                bombs.Add(currBomb.GetComponent<Bomb>());
                currBomb.SetActive(false);
            }
        }

        void Update()
        {
            if (Input.GetButtonDown(bombButtonName))
            {
                PutBomb();
            }
        }


        void PutBomb()
        {
            Debug.Log("Entró");
            for (int i = 0; i < bombs.Count; i++)
            {
                if (!bombs[i].gameObject.activeSelf)
                {
                    bombs[i].gameObject.SetActive(true);
                    bombs[i].transform.position = new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2.0f + bombs[i].transform.localScale.y / 2.0f, transform.position.z);

                    break;
                }
            }
        }
    }
}
