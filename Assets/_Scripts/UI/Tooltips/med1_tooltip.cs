using UnityEngine;
using System;

public class med1_tooltip : MonoBehaviour
{
    [SerializeField][TextArea] private string _tooltipText = "<color=#00ff00>EMPTY</color>\r\n<color=#ff0000>Please initialize</color>";

    void Start()
    {

        Func<string> getTooltipTextFunc = () =>
        {
            return _tooltipText;
        };

        ToolTip.ShowTooltip_Static(getTooltipTextFunc);
    }
}
