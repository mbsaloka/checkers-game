using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;

    void Awake()
    {
        Instance = this;
    }

    public void GenerateGrid()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                float xPos = x - (_width / 2) + 0.5f;
                float yPos = y - (_height / 2) + 0.5f;

                var spawnedTile = Instantiate(_tilePrefab, new Vector3(xPos, yPos, -3), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x + y) % 2 == 1;
                spawnedTile.init(isOffset);
            }
        }

        GameManager.Instance.ChangeState(GameState.SpawnHeroes);
    }
}
