using UnityEngine;

public class Highlighter : MonoBehaviour
{
    public Color HighlighterColor = Color.red;

    private Renderer _renderer;
    private Color _originalColor;
    private MedTooltip _tooltip;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _tooltip = GetComponent<MedTooltip>();
        _originalColor = _renderer.material.color;
    }

    private void OnMouseOver()
    {
        _renderer.material.color = HighlighterColor;
        _tooltip.ShowTooltip(true);
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _originalColor;
        _tooltip.ShowTooltip(false);
    }

    private void OnDestroy()
    {
        _tooltip.ShowTooltip(false);
    }
}
