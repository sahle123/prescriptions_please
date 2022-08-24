using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceMoveTrigger : MonoBehaviour
{
    [SerializeField] private int _delaySeconds = 3;
    private Vector3 originalCoordinates;
    private Vector3 hideSpace;

    void Start()
    {
        hideSpace = new Vector3(-1000, -1000, -1000);
        originalCoordinates = this.gameObject.transform.position;

        this.gameObject.transform.position = hideSpace;

        ShowPolice();
    }

    public void ShowPolice()
    {
        StartCoroutine(Delay(_delaySeconds));
    }

    private IEnumerator Delay(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        this.gameObject.transform.position = originalCoordinates;
    }
}
