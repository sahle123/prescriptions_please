using System.Collections;
using UnityEngine;

public class ArrivalEventHandler : MonoBehaviour
{
    public delegate void ArrivalAction();
    public static event ArrivalAction OnArrival;
    public static event ArrivalAction OnExit;
    public static event ArrivalAction OnNoPrescription;
    public static event ArrivalAction OnExitScene;

    // Tag we are looking for in the trigger
    [SerializeField] private string Tag = "Patient";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tag))
        {
            //Debug.Log("Other Collider:" + other.name);
            Debug.Log("OnArrival event");
            OnArrival();
        }
        else if (other.gameObject.CompareTag("Police"))
        {
            Debug.Log("Police arrival");
            OnArrival();
            StartCoroutine(Delay(12, OnExit));
        }
    }

    public static void StartExit()
    {
        Debug.Log("OnExit event");
        OnExit();
    }

    public static void NoPrescriptionExit()
    {
        Debug.Log("OnNoPrescription");
        OnNoPrescription();
    }

    public static void ExitScene()
    {
        Debug.Log("Exiting scene");
        OnExitScene();
    }

    private IEnumerator Delay(int seconds, ArrivalAction action)
    {
        yield return new WaitForSeconds(seconds);
        action();
    }
}
