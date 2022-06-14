using UnityEngine;


namespace NewBomberman
{
    public class MapGenerator : MonoBehaviour
    {
        [SerializeField] GameObject player = null;
        [SerializeField] GameObject prefabBorderBlock = null;
        [SerializeField] GameObject prefabEnemy = null;
        [SerializeField] GameObject prefabFloor = null;
        [SerializeField] GameObject prefabUnbreakableBlock = null;
        [SerializeField] GameObject prefabBreakableBlock = null;


        char[,] blocksMap;
        GameObject[,] blocksTable;

        const int mapSize = 10;

        const char brder = '+';
        const char plyr1 = 'P';
        const char nEnmy = 'E';
        const char unBck = 'U';
        const char brBck = 'B';
        const char empty = ' ';



        void Awake()
        {
            blocksMap = new char[mapSize, mapSize] { { brder, brder, brder, brder, brder, brder, brder, brder, brder, brder },
                                                     { brder, plyr1, empty, empty, empty, empty, empty, empty, empty, brder },
                                                     { brder, empty, unBck, unBck, empty, empty, unBck, unBck, empty, brder },
                                                     { brder, empty, unBck, empty, empty, empty, empty, unBck, empty, brder },
                                                     { brder, empty, empty, empty, empty, empty, empty, empty, empty, brder },
                                                     { brder, empty, empty, empty, empty, nEnmy, empty, empty, empty, brder },
                                                     { brder, empty, unBck, empty, empty, empty, empty, unBck, empty, brder },
                                                     { brder, empty, unBck, unBck, empty, empty, unBck, unBck, empty, brder },
                                                     { brder, empty, empty, empty, empty, empty, empty, empty, empty, brder },
                                                     { brder, brder, brder, brder, brder, brder, brder, brder, brder, brder }};
        }
        void Start()
        {
            prefabFloor.transform.localScale = new Vector3(mapSize, 1.0f, mapSize);
            prefabFloor.transform.position = new Vector3(0.0f, -prefabFloor.transform.localScale.y / 2.0f, 0.0f);

            float wBlock = prefabFloor.transform.localScale.x / mapSize;
            float dBlock = prefabFloor.transform.localScale.z / mapSize;
            float topLeftX = prefabFloor.transform.position.x - prefabFloor.transform.localScale.x / 2.0f + wBlock / 2.0f;
            float topLeftZ = prefabFloor.transform.position.z + prefabFloor.transform.localScale.z / 2.0f - dBlock / 2.0f;


            blocksTable = new GameObject[mapSize, mapSize];

            for (int i = 0; i < blocksTable.GetLength(0); i++)
            {
                for (int j = 0; j < blocksTable.GetLength(1); j++)
                {
                    if (blocksMap[i, j] != plyr1 && blocksMap[i, j] != nEnmy)
                    {
                        blocksTable[i, j] = gB(blocksMap[i, j], topLeftX + wBlock * j, topLeftZ - dBlock * i);
                    }
                    else if (blocksMap[i, j] == plyr1)
                    {
                        float posOnTheFloorY = prefabFloor.transform.position.y + prefabFloor.transform.localScale.y / 2.0f + player.transform.localScale.y / 2.0f;
                        player.transform.position = new Vector3(topLeftX + wBlock * j, posOnTheFloorY, topLeftZ - dBlock * i);
                    }
                    else
                    {
                        GameObject newEnemy = Instantiate(prefabEnemy);

                        float posOnTheFloorY = prefabFloor.transform.position.y + prefabFloor.transform.localScale.y / 2.0f + newEnemy.transform.localScale.y / 2.0f;
                        newEnemy.transform.position = new Vector3(topLeftX + wBlock * i, posOnTheFloorY, topLeftZ - dBlock * j);
                    }
                }
            }
        }


        GameObject gB(char blockType, float x, float z)
        {
            GameObject newBlock = null;

            float yOnTheFloor = 0.0f;

            if (blockType == unBck)
            {
                newBlock = Instantiate(prefabUnbreakableBlock);
            }
            else if (blockType == brBck)
            {
                newBlock = Instantiate(prefabBreakableBlock);
            }
            else if (blockType == brder)
            {
                newBlock = Instantiate(prefabBorderBlock);
            }

            if (newBlock != null)
            {
                newBlock.transform.localScale = new Vector3(prefabFloor.transform.localScale.x / mapSize, prefabFloor.transform.localScale.y, prefabFloor.transform.localScale.z / mapSize);

                yOnTheFloor = prefabFloor.transform.position.y + prefabFloor.transform.localScale.y / 2.0f + newBlock.transform.localScale.y / 2.0f;
                newBlock.transform.position = new Vector3(x, yOnTheFloor, z);
            }


            return newBlock;
        }
    }
}
