using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private int _width,
        _height;

    [SerializeField]
    private Tile _tilePreFab;

    [SerializeField]
    private Transform _camera;

    private Dictionary<Vector2, Tile> _tiles;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var spawmedTile = Instantiate(_tilePreFab, new Vector3(x, y), Quaternion.identity);
                spawmedTile.name = $"Tile {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawmedTile.Init(isOffset);

                _tiles[new Vector2(x, y)] = spawmedTile;
            }
        }

        _camera.transform.position = new Vector3(
            (float)_width / 2 - 0.5f,
            (float)_height / 2 - 0.5f,
            -10
        );
    }

    public Tile GetTileAtPosition(Vector2 position)
    {
        if (_tiles.TryGetValue(position, out var tile))
        {
            return tile;
        }
        return null;
    }
}
