using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    
    [SerializeField]
    int _rows = 5;

    [SerializeField]
    int _columns = 5;

    [SerializeField]
    float _tileSize = 1;

    void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        GameObject referenceTile = Instantiate(Resources.Load("Tile")) as GameObject;
        for (int row = 0; row < _rows; row++)
        {
            for (int column = 0; column < _columns; column++)
            {
                GameObject tile = Instantiate(referenceTile,transform) as GameObject;
                float posX = column * _tileSize;
                float posY = row * _tileSize;
                float posZ = 0f;

                tile.transform.position = new Vector3(posX,posY,posZ);
            }
        }

        Destroy(referenceTile);
    }

}
