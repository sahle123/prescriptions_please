using System;
using UnityEngine;
using TMPro;

public class ToolTip : MonoBehaviour
{
    public static ToolTip Instance { get; private set; }
    [SerializeField] private Vector2 _padding = new Vector2(30, 20);

    private TextMeshProUGUI _tooltipText;
    private RectTransform _backgroundRectTransform;
    private RectTransform _rectTransform;

    private Func<string> getTooltipTextFunc;

    private void Awake()
    {
        Instance = this;

        _backgroundRectTransform = transform.Find("background").GetComponent<RectTransform>();
        _tooltipText = transform.Find("text").GetComponent<TextMeshProUGUI>();
        _rectTransform = transform.GetComponent<RectTransform>();

        HideTooltip();
    }

    private void SetText(string tooltipText)
    {
        _tooltipText.SetText(tooltipText);
        _tooltipText.ForceMeshUpdate();

        Vector2 textSize = _tooltipText.GetRenderedValues(false);
        Vector2 paddingSize = _padding;

        _backgroundRectTransform.sizeDelta = textSize + paddingSize;
    }

    private void Update()
    {
        SetText(getTooltipTextFunc());

        _rectTransform.anchoredPosition = new Vector2(20, 20);
    }

    #region Tooltip show/hide
    private void ShowTooltip(string tooltipString)
    {
        //gameObject.SetActive(true);
        //SetText(tooltipString);
        ShowTooltip(() => tooltipString);
    }

    private void ShowTooltip(Func<string> getTooltipTextFunc)
    {
        this.getTooltipTextFunc = getTooltipTextFunc;
        gameObject.SetActive(true);
        SetText(getTooltipTextFunc());
    }

    private void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    public static void ShowTooltip_Static(string tooltipString)
    {
        Instance.ShowTooltip(tooltipString);
    }

    public static void ShowTooltip_Static(Func<string> getTooltipTextFunc)
    {
        Instance.ShowTooltip(getTooltipTextFunc);
    }

    public static void HideTooltip_Static()
    {
        Instance.HideTooltip();
    }
    #endregion
}
