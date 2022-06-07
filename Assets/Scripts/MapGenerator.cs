using UnityEngine;

namespace NewBomberman
{
    public class MapGenerator : MonoBehaviour
    {
        [SerializeField] GameObject player = null;
        [SerializeField] GameObject floor = null;
        [SerializeField] GameObject prefabUnbreakableBlock = null;
        [SerializeField] GameObject prefabBreakableBlock = null;

        [SerializeField] char[,] blocksMap;


        GameObject[,] blocksTable;

        const int mapSize = 10;

        const char plyr1 = 'P';
        const char unBck = 'U';
        const char brBck = 'B';
        const char empty = ' ';



        void Awake()
        {
            blocksMap = new char[mapSize, mapSize] { { unBck, empty, empty, empty, empty, empty, empty, empty, empty, empty },
                                                     { unBck, plyr1, empty, empty, empty, empty, empty, empty, empty, empty },
                                                     { unBck, unBck, unBck, empty, empty, empty, empty, empty, empty, empty },
                                                     { unBck, unBck, unBck, unBck, empty, empty, empty, empty, empty, empty },
                                                     { unBck, unBck, unBck, unBck, unBck, empty, empty, empty, empty, empty },
                                                     { unBck, unBck, unBck, unBck, unBck, unBck, empty, empty, empty, empty },
                                                     { unBck, unBck, unBck, unBck, unBck, unBck, unBck, empty, empty, empty },
                                                     { unBck, unBck, unBck, unBck, unBck, unBck, unBck, unBck, empty, empty },
                                                     { unBck, unBck, unBck, unBck, unBck, unBck, unBck, unBck, unBck, empty },
                                                     { unBck, unBck, unBck, unBck, unBck, unBck, unBck, unBck, unBck, unBck }};
        }
        void Start()
        {
            floor.transform.localScale = new Vector3(mapSize, 1.0f, mapSize);
            floor.transform.position = new Vector3(0.0f, -floor.transform.localScale.y / 2.0f, 0.0f);

            float wBlock = floor.transform.localScale.x / mapSize;
            float dBlock = floor.transform.localScale.z / mapSize;
            float topLeftX = floor.transform.position.x - floor.transform.localScale.x / 2.0f + wBlock / 2.0f;
            float topLeftZ = floor.transform.position.z + floor.transform.localScale.z / 2.0f - dBlock / 2.0f;


            blocksTable = new GameObject[mapSize, mapSize];

            for (int i = 0; i < blocksTable.GetLength(0); i++)
            {
                for (int j = 0; j < blocksTable.GetLength(1); j++)
                {
                    if (blocksMap[i, j] != plyr1)
                    {
                        blocksTable[i, j] = gB(blocksMap[i, j], topLeftX + wBlock * i, topLeftZ - dBlock * j);
                    }
                    else
                    {
                        float posOnTheFloorY = floor.transform.position.y + floor.transform.localScale.y / 2.0f + player.transform.localScale.y / 2.0f;
                        player.transform.position = new Vector3(topLeftX + wBlock * i, posOnTheFloorY, topLeftZ - dBlock * j);
                    }
                }
            }
        }


        GameObject gB(char blockType, float x, float z)
        {
            GameObject block = null;

            float yOnTheFloor = 0.0f;


            if (blockType == unBck)
            {
                block = Instantiate(prefabUnbreakableBlock);
            }
            else if (blockType == brBck)
            {
                block = Instantiate(prefabBreakableBlock);
            }

            if (block != null)
            {
                block.transform.localScale = new Vector3(floor.transform.localScale.x / mapSize, floor.transform.localScale.y, floor.transform.localScale.z / mapSize);

                yOnTheFloor = floor.transform.position.y + floor.transform.localScale.y / 2.0f + block.transform.localScale.y / 2.0f;
                block.transform.position = new Vector3(x, yOnTheFloor, z);
            }


            return block;
        }
    }
}
