using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    [SerializeField]
    private int _width,
        _height;

    [SerializeField]
    private Tile _grassTile,
        _mountainTile;

    [SerializeField]
    private Transform _camera;

    private Dictionary<Vector2, Tile> _tiles;

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
                var randomTile = Random.Range(0, 6) == 3 ? _mountainTile : _grassTile;
                var spawmedTile = Instantiate(randomTile, new Vector3(x, y), Quaternion.identity);
                spawmedTile.name = $"Tile {x} {y}";

                spawmedTile.Init(x, y);

                _tiles[new Vector2(x, y)] = spawmedTile;
            }
        }

        _camera.transform.position = new Vector3(
            (float)_width / 2 - 0.5f,
            (float)_height / 2 - 0.5f,
            -10
        );

        GameManager.Instance.ChangeState(GameState.SpawnHeroes);
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
