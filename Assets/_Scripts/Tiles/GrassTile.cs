using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTile : Tile
{
    // Start is called before the first frame update
    [SerializeField]
    private Color _baseColor,
        _offSetColor;

    public override void Init(int x, int y)
    {
        var isOffset = (x + y) % 2 == 1;
        _renderer.color = isOffset ? _offSetColor : _baseColor;
    }
}
