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
        [SerializeField] GameObject enemyReference = null;

        [Header("Prefabs")]
        [SerializeField] GameObject prefabBorderBlock = null;
        [SerializeField] GameObject prefabTile = null;
        [SerializeField] GameObject prefabUnbreakableBlock = null;
        [SerializeField] GameObject prefabBreakableBlock = null;

        [Header("Parent Elements")]
        [SerializeField] GameObject parentTiles = null;
        [SerializeField] GameObject parentBorder = null;
        [SerializeField] GameObject parentUnbreakableBlocks = null;
        [SerializeField] GameObject parentBreakableBlocks = null;

        [Header("Configuration")]
        [SerializeField] Vector3 distanceFromEnemyToGround = Vector3.zero; // Distancia del piso para el enemigo.

        FileStream fileStreamOpen; // Campo que se ocupa de cargar el archivo de texto.
        StreamReader streamReader; // Campo que se ocupa de leer el archivo.

        List<string> stringMap; // Lista de strings, la cual va a guardar el mapa.

        GameObject[,] tileMap; // Arreglo bidimensional de los casilleros que conforman el piso.

        // Carácteres para interpretar las letras del mapa de texto.
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
                    tileMap[i, j] = Instantiate(prefabTile, parentTiles.transform);
                    tileMap[i, j].transform.position = new Vector3(j, -transform.localScale.y / 2.0f, -i);
                }
            }

            // Ubico el resto de los elementos sobre el mapa.
            for (int i = 0; i < stringMap.Count; i++)
            {
                for (int j = 0; j < stringMap[i].Length; j++)
                {
                    if (IsABlock(stringMap[i][j])) // Si lo generado en esta posición es un bloque...
                    {
                        // Genero el bloque correspondiente.
                        gB(stringMap[i][j], tileMap[i, j].transform.position.x, tileMap[i, j].transform.position.z);
                    }
                    else // De lo contrario...
                    {
                        // Evalúo y reacciono.
                        switch (stringMap[i][j])
                        {
                            case player:
                                // Posiciono al jugador en su respectiva posición.
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
                                // Posiciono al enemigo.
                                onTheFloor = enemyReference.transform.localScale.y + distanceFromEnemyToGround.y;
                                enemyReference.transform.position = new Vector3(tileMap[i, j].transform.position.x, onTheFloor, tileMap[i, j].transform.position.z);
                                break;
                        }
                    }
                }
            }
        }



        GameObject gB(char blockType, float x, float z)
        {
            GameObject newBlock = null;

            // Instancio el bloque correspondiente.
            if (blockType == unbreakableBlock)
            {
                newBlock = Instantiate(prefabUnbreakableBlock, parentUnbreakableBlocks.transform);
            }
            else if (blockType == breakableBlock)
            {
                newBlock = Instantiate(prefabBreakableBlock, parentBreakableBlocks.transform);
            }
            else if (blockType == border)
            {
                newBlock = Instantiate(prefabBorderBlock, parentBorder.transform);
            }

            // Para evitar errores si se intenta mover la posición de un objeto nulo.
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
