using UnityEngine;

using System.IO;
using System.Collections.Generic;


namespace NewBomberman
{
    public class MapGenerator : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] GameObject playerReference = null;
        [SerializeField] GameObject keyReference = null;
        [SerializeField] GameObject doorReference = null;

        [Header("Prefabs")]
        [SerializeField] GameObject prefabBorderBlock = null;
        [SerializeField] GameObject prefabEnemy = null;
        [SerializeField] GameObject prefabTile = null;
        [SerializeField] GameObject prefabUnbreakableBlock = null;
        [SerializeField] GameObject prefabBreakableBlock = null;

        [Header("Configuration")]
        [SerializeField] Vector3 distanceToTheFloor = Vector3.zero;

        FileStream fileStreamOpen;
        StreamReader streamReader;

        List<string> stringMap;

        GameObject[,] tileMap;

        const char border = 'X';
        const char player = 'P';
        const char enemy = 'E';
        const char unbreakableBlock = 'U';
        const char breakableBlock = '-';
        const char door = 'D';
        const char key = 'K';



        void Awake()
        {
            fileStreamOpen = File.OpenRead("Assets/Text Map/Level Map.txt");
            streamReader = new StreamReader(fileStreamOpen);

            stringMap = new List<string>(); // inicializo la lista de strings.

            // Leo el archivo cargado.
            while (!streamReader.EndOfStream)
            {
                stringMap.Add(streamReader.ReadLine());
            }

            tileMap = new GameObject[stringMap.Count, stringMap[0].Length]; // Inicializo el arreglo bidimensional de objetos.

            // Cierro los archivos de lectura.
            fileStreamOpen.Close();
            streamReader.Close();
        }

        void Start()
        {
            float onTheFloor = 0.0f;


            // Se generan los bloques que conforman el piso.
            for (int i = 0; i < stringMap.Count; i++)
            {
                for (int j = 0; j < stringMap[i].Length; j++)
                {
                    tileMap[i, j] = Instantiate(prefabTile);
                    tileMap[i, j].transform.position = new Vector3(j, -transform.localScale.y / 2.0f, -i);
                }
            }

            // Ubico el resto de los elementos sobre el mapa.
            for (int i = 0; i < stringMap.Count; i++)
            {
                for (int j = 0; j < stringMap[i].Length; j++)
                {
                    if (IsABlock(stringMap[i][j]))
                    {
                        gB(stringMap[i][j], tileMap[i, j].transform.position.x, tileMap[i, j].transform.position.z);
                    }
                    else
                    {
                        switch (stringMap[i][j])
                        {
                            case player:
                                // Posiciono al jugador en su respectiva posici�n.
                                onTheFloor = playerReference.transform.localScale.y;
                                playerReference.transform.position = new Vector3(tileMap[i, j].transform.position.x, onTheFloor, tileMap[i, j].transform.position.z);
                                break;

                            case key:
                                // Posiciono a la llave.
                                onTheFloor = keyReference.transform.localScale.y / 2.0f;
                                keyReference.transform.position = new Vector3(tileMap[i, j].transform.position.x, onTheFloor, tileMap[i, j].transform.position.z);
                                break;

                            case door:
                                // Posiciono la puerta.
                                onTheFloor = doorReference.transform.localScale.y / 2.0f;
                                doorReference.transform.position = new Vector3(tileMap[i, j].transform.position.x, onTheFloor, tileMap[i, j].transform.position.z);
                                break;

                            case enemy:
                                // Instancio un enemigo y lo ubico en el mapa.
                                GameObject newEnemy = Instantiate(prefabEnemy);
                                const float timeToMove = 0.5f;


                                onTheFloor = newEnemy.transform.localScale.y + distanceToTheFloor.y;
                                newEnemy.transform.position = new Vector3(tileMap[i, j].transform.position.x, onTheFloor, tileMap[i, j].transform.position.z);
                                newEnemy.GetComponent<EnemyMovement>().SetTimeToMove(timeToMove);
                                break;
                        }
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
                newBlock.transform.position = new Vector3(x, newBlock.transform.localScale.y / 2.0f, z);
            }


            return newBlock;
        }

        bool IsABlock(char character)
        {
            return character == border || character == unbreakableBlock || character == breakableBlock;
        }
    }
}
