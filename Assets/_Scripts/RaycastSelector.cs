using UnityEngine;

public class RaycastSelector : MonoBehaviour
{
    public LayerMask Mask;
    public Color SelectColor = Color.blue;
    public AudioClip CashRegister;

    private AudioSource _audioSource;

    Camera _cam;

    void Start()
    {
        _cam = Camera.main;
        _audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = 100f;
        mousePos = _cam.ScreenToWorldPoint(mousePos);

        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100, Mask))
            {
                Debug.Log(hit.transform.GetComponent<MedPrice>().Value);
                Debug.Log(hit.transform.name);
                StateController.PlayerScore += hit.transform.GetComponent<MedPrice>().Value;

                if (hit.transform.name == "No_prescription")
                {
                    ArrivalEventHandler.NoPrescriptionExit();
                }
                else
                {
                    _audioSource.PlayOneShot(CashRegister);
                    ArrivalEventHandler.StartExit();
                }

                //hit.transform.GetComponent<Renderer>().material.color = SelectColor;
                //Destroy(hit.transform.gameObject);

                //Destroy(this.gameObject);
            }
        }
    }
}
