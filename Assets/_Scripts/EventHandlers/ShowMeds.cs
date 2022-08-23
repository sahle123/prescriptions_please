using System.Collections;
using UnityEngine;

public class ShowMeds : MonoBehaviour
{
    private Vector3 originalCoordinates;
    private Vector3 hideSpace;
    private int _delaySeconds = 3;

    private void Start()
    {
        hideSpace = new Vector3(-1000, -1000, -1000);
        originalCoordinates = this.gameObject.transform.position;

        this.gameObject.transform.position = hideSpace;
    }

    #region For ArrivalEventHandler
    private void OnEnable()
    {
        ArrivalEventHandler.OnArrival += ShowMedication;
    }

    private void OnDisable()
    {
        ArrivalEventHandler.OnArrival -= ShowMedication;
    }
    #endregion

    public void ShowMedication()
    {
        ShowMedsAfterDelay(_delaySeconds);
    }

    private Coroutine ShowMedsAfterDelay(int seconds)
    {
        return StartCoroutine(Delay(seconds));
    }

    private IEnumerator Delay(int seconds)
    {
        for(int i = 0; i < seconds; i++)
        {
            yield return new WaitForSeconds(1);
        }
        this.gameObject.transform.position = originalCoordinates;
    }
}
