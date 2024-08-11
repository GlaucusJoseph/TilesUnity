using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private Color _baseColor,
        _offSetColor;

    [SerializeField]
    private SpriteRenderer _renderer;

    [SerializeField]
    private GameObject _highlight;

    public void Init(bool isOffset)
    {
        _renderer.color = isOffset ? _offSetColor : _baseColor;
    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}
