using System.Collections;
using UnityEngine;

public class ShowMeds : MonoBehaviour
{
    [SerializeField] private int _delaySeconds = 3;
    private Vector3 originalCoordinates;
    private Vector3 hideSpace;

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
        ArrivalEventHandler.OnExit += HideMedication;
        ArrivalEventHandler.OnNoPrescription += HideMedication;
    }

    private void OnDisable()
    {
        ArrivalEventHandler.OnArrival -= ShowMedication;
        ArrivalEventHandler.OnExit -= HideMedication;
        ArrivalEventHandler.OnNoPrescription -= HideMedication;
    }
    #endregion

    public void ShowMedication()
    {
        StartCoroutine(Delay(_delaySeconds));
    }

    public void HideMedication()
    {
        this.gameObject.transform.position = hideSpace;
    }

    private IEnumerator Delay(int seconds)
    {
        yield return new WaitForSeconds(seconds);

        this.gameObject.transform.position = originalCoordinates;
    }
}
