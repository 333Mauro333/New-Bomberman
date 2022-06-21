using UnityEngine;

using System.Collections.Generic;


namespace NewBomberman
{
    public class BombPlanter : MonoBehaviour
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
            for (int i = 0; i < bombs.Count; i++)
            {
                if (!bombs[i].gameObject.activeSelf && !ThereIsABomb(bombs[i]))
                {
                    bombs[i].gameObject.SetActive(true);
                    bombs[i].transform.position = new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2.0f + bombs[i].transform.localScale.y * 100 / 2.0f, transform.position.z);

                    break;
                }
            }
        }
        bool ThereIsABomb(Bomb bombToPut)
        {
            for (int i = 0; i < bombs.Count; i++)
            {
                if (!AreTheSame(bombs[i].gameObject, bombToPut.gameObject) && bombs[i].gameObject.activeSelf && SamePositionThanThisObject(bombs[i].gameObject))
                {
                    return true;
                }
            }

            return false;
        }
        bool AreTheSame(GameObject gO1, GameObject gO2)
        {
            return gO1.GetHashCode() == gO2.GetHashCode();
        }
        bool SamePositionThanThisObject(GameObject gO)
        {
            return transform.position.x == gO.transform.position.x && transform.position.z == gO.transform.position.z;
        }
    }
}
