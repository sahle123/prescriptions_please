using System;
using UnityEngine;

public class MedTooltip : MonoBehaviour
{
    [SerializeField][TextArea] private string _tooltipText = "<color=#00ff00>EMPTY</color>\r\n<color=#ff0000>Please initialize</color>";

    void Start()
    { }

    public void ShowTooltip(bool isShow)
    {
        if (isShow)
        {
            Func<string> getTooltipTextFunc = () =>
            {
                return _tooltipText;
            };

            ToolTip.ShowTooltip_Static(getTooltipTextFunc);
        }
        else
        {
            ToolTip.HideTooltip_Static();
        }
    }
}
