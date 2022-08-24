using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private TMP_Text _text;

    void Start()
    {
        //Debug.Log(StateController.PlayerScore.ToString());
        _text = GetComponent<TMP_Text>();
        _text.SetText("SAR: " + StateController.PlayerScore.ToString());
    }

    private void Update()
    {
        _text.SetText("SAR: " + StateController.PlayerScore.ToString());
    }
}
