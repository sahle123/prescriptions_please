using UnityEngine;

public class StateController : MonoBehaviour
{
    public static int PlayerScore = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
