using UnityEngine;

using System.IO;
using System.Collections.Generic;


namespace NewBomberman
{
    public class MapGenerator : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] GameObject playerReference = null;
        [SerializeField] GameObject prefabBorderBlock = null;
        [SerializeField] GameObject prefabEnemy = null;
        [SerializeField] GameObject prefabTile = null;
        [SerializeField] GameObject prefabUnbreakableBlock = null;
        [SerializeField] GameObject prefabBreakableBlock = null;

        FileStream fileStreamOpen;
        StreamReader streamReader;

        GameObject[,] tileMap;

        List<string> stringMap;

        const int mapSize = 10;

        const char border = 'X';
        const char player = 'P';
        const char enemy = 'E';
        const char unbreakableBlock = 'U';
        const char breakableBlock = '-';
        const char space = ' ';
        const char door = 'D';
        const char key = 'K';



        void Awake()
        {
            fileStreamOpen = File.OpenRead("Assets/Text Map/Level Map.txt");
            streamReader = new StreamReader(fileStreamOpen);

            stringMap = new List<string>();

            while (!streamReader.EndOfStream)
            {
                stringMap.Add(streamReader.ReadLine());
            }

            tileMap = new GameObject[stringMap.Count, stringMap[0].Length];

            Debug.Log("Detenerse");
        }

        void Start()
        {
            float wBlock = prefabTile.transform.localScale.x;
            float dBlock = prefabTile.transform.localScale.z;
            float tileCenterX = prefabTile.transform.localScale.x / 2.0f;
            float tileCenterZ = prefabTile.transform.localScale.z / 2.0f;


            for (int i = 0; i < stringMap.Count; i++)
            {
                for (int j = 0; j < stringMap[i].Length; j++)
                {
                    tileMap[i, j] = Instantiate(prefabTile);
                    tileMap[i, j].transform.position = new Vector3(j, -transform.localScale.y / 2.0f, i);
                }
            }

            for (int i = 0; i < stringMap.Count; i++)
            {
                for (int j = 0; j < stringMap[i].Length; j++)
                {
                    if (IsABlock(stringMap[i][j]))
                    {
                        gB(stringMap[i][j], tileMap[i, j].transform.position.x + j, tileMap[i, j].transform.position.z - i);
                    }
                    else if (stringMap[i][j] == player)
                    {
                        playerReference.transform.position = new Vector3(tileMap[i, j].transform.position.x + j, 0.0f, tileMap[i, j].transform.position.z - i);
                    }
                    else if (stringMap[i][j] == enemy)
                    {
                        GameObject newEnemy = Instantiate(prefabEnemy);

                        newEnemy.transform.position = new Vector3(tileMap[i, j].transform.position.x + j, 0.0f, tileMap[i, j].transform.position.z - i);
                        newEnemy.GetComponent<EnemyMovement>().SetTimeToMove(0.5f);
                    }
                }
            }
        }


        GameObject gB(char blockType, float x, float z)
        {
            GameObject newBlock = null;


            if (blockType == unbreakableBlock)
            {
                newBlock = Instantiate(prefabUnbreakableBlock);
            }
            else if (blockType == breakableBlock)
            {
                newBlock = Instantiate(prefabBreakableBlock);
            }
            else if (blockType == border)
            {
                newBlock = Instantiate(prefabBorderBlock);
            }

            if (newBlock != null)
            {
                newBlock.transform.position = new Vector3(x, 0.0f, z);
            }


            return newBlock;
        }

        bool IsABlock(char character)
        {
            return character == border || character == unbreakableBlock || character == breakableBlock;
        }
    }
}
