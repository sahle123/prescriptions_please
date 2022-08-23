using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text _textLabel;
    [SerializeField] private DialogueObject _dialogueObject;
    [SerializeField] private DialogueObject _exitDialogueObject;
    [SerializeField] private AudioClip[] _voiceFX;

    private TypeWriterEffect _typeWriterEffect;
    private AudioSource _audioSource;

    private void Start()
    {
        _typeWriterEffect = GetComponent<TypeWriterEffect>();
        _audioSource = GetComponent<AudioSource>();
        //ShowDialogue();
        CloseDialogueBox();
    }

    #region For ArrivalEventHandler
    private void OnEnable()
    {
        ArrivalEventHandler.OnArrival += ShowDialogue;
        ArrivalEventHandler.OnExit += ShowExitDialogue;
    }

    private void OnDisable()
    {
        ArrivalEventHandler.OnArrival -= ShowDialogue;
        ArrivalEventHandler.OnExit -= ShowExitDialogue;
    }
    #endregion

    // Greetings dialogue
    public void ShowDialogue()
    {
        ShowDialogueBox();
        StartCoroutine(StepThroughDialogue(_dialogueObject));
    }

    // Goodbye dialogue
    public void ShowExitDialogue()
    {
        ShowDialogueBox();
        StartCoroutine(StepThroughDialogue(_exitDialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        foreach(string dialogue in dialogueObject.Dialogue)
        {
            PlayRandomVoice();
            yield return _typeWriterEffect.Run(dialogue, _textLabel);
            yield return new WaitForSeconds(2); // Wait 2 seconds before going to the next dialogue.
        }
        CloseDialogueBox();
    }

    private void PlayRandomVoice()
    {
        int index = Random.Range(0, _voiceFX.Length);
        _audioSource.PlayOneShot(_voiceFX[index]);
    }

    private void ShowDialogueBox()
    {
        dialogueBox.SetActive(true);
        _textLabel.text = string.Empty;
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        _textLabel.text = string.Empty;
    }
}
