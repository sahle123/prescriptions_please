using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    public int TimeTillFade = 2;
    public int ScoreThreshold = 350;
    public string NextScene;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Space))
    //    {
    //        _animator.SetBool("FadeIn", true);
    //        //ArrivalEventHandler.ExitScene();
    //    }
    //}

    private void StartFadeIn()
    {
        // Delay for a set amount of seconds.
        StartCoroutine(DelayAndFade(2));
    }

    #region For ArrivalEventHandler
    private void OnEnable()
    {
        ArrivalEventHandler.OnExit += StartFadeIn;
        ArrivalEventHandler.OnNoPrescription += StartFadeIn;
    }

    private void OnDisable()
    {
        ArrivalEventHandler.OnExit -= StartFadeIn;
        ArrivalEventHandler.OnNoPrescription -= StartFadeIn;
    }
    #endregion

    private IEnumerator DelayAndFade(int waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        _animator.SetBool("FadeIn", true);
        yield return new WaitForSeconds(waitSeconds + 3);

        if (NextScene == "none")
        {
            Debug.Log("EXIT WINDOW");
            Application.Quit();
        }
        else if(StateController.PlayerScore > ScoreThreshold)
            SceneManager.LoadScene("Scene_4_2_bad");
        else
            SceneManager.LoadScene(NextScene);
    }
}
