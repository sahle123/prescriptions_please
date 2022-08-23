using UnityEngine;

public class ArrivalEventHandler : MonoBehaviour
{
    public delegate void ArrivalAction();
    public static event ArrivalAction OnArrival;
    public static event ArrivalAction OnExit;
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
    }

    public static void StartExit()
    {
        Debug.Log("OnExit event");
        OnExit();
    }

    public static void ExitScene()
    {
        Debug.Log("Exiting scene");
        OnExitScene();
    }
}
