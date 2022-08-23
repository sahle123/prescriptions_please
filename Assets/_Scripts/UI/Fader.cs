using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    public int TimeTillFade = 2;
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
    }

    private void OnDisable()
    {
        ArrivalEventHandler.OnExit -= StartFadeIn;
    }
    #endregion

    private IEnumerator DelayAndFade(int waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        _animator.SetBool("FadeIn", true);
        yield return new WaitForSeconds(waitSeconds + 5);
        SceneManager.LoadScene(NextScene);
    }
}
