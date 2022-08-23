using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public string Tag = "Patient";
    public AudioClip BellSfx;

    private Animator _doorAnim;
    private AudioSource _bell;

    void Start() 
    {
        _doorAnim = this.transform.parent.GetComponent<Animator>();
        _bell = this.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tag))
        {
            _doorAnim.SetBool("Open", true);
            _bell.PlayOneShot(BellSfx);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _doorAnim.SetBool("Open", false);
    }
}
