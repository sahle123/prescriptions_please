using UnityEngine;

public class ToonMovement : MonoBehaviour
{
    // Path for toon to follow
    public Transform[] TargetList;
    public float ToonSpeed = 0.02f;
    public float RotationSpeed = 0.35f;

    private Animator _animator;
    private Rigidbody _rb;
    private int _index;
    private bool _reverseDirection = false;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _index = 0;
    }

    void FixedUpdate()
    {
        CheckKeyboard();

        Vector3 current = transform.position;
        Vector3 target = TargetList[_index].position;

        // Manage animation and direction.
        if (current.Equals(target))
        {
            _animator.SetBool("isWalking", false);

            // Go to next position
            if((!_reverseDirection) && (_index < TargetList.Length - 1))
                _index++;
            else if ((_reverseDirection) && (_index > 0))
                _index--;

            return;
        }
        else
        {
            _animator.SetBool("isWalking", true);
        }

        transform.position = Vector3.MoveTowards(current, target, ToonSpeed);

        //FaceCorrectDirection(current, target);
        FaceCorrectDirectionLerp(current, TargetList[_index]);
    }

    private void CheckKeyboard()
    {
        // Flip directions
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    _reverseDirection = !_reverseDirection;
        //    Debug.Log("Reversed directions: " + _reverseDirection);
        //}
    }

    // Way to rotate without lerping.
    private void FaceCorrectDirection(Vector3 current, Vector3 target)
    {
        Vector3 targetDirection = target - current;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, RotationSpeed, 1.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        Debug.DrawLine(current, target, Color.red);
        Debug.DrawRay(current, newDirection, Color.red);
    }

    // The better, smoother way to rotate B)
    private void FaceCorrectDirectionLerp(Vector3 current, Transform target)
    {
        Vector3 relativePosition = transform.position - current;
        Quaternion targetRotation = Quaternion.LookRotation(relativePosition);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, RotationSpeed);
    }

    // Flips directions
    private void StartExit()
    {
        _reverseDirection = !_reverseDirection;
    }

    private void NoPrescriptionExit()
    {
        _reverseDirection = !_reverseDirection;
    }

    #region For ArrivalEventHandler
    private void OnEnable()
    {
        ArrivalEventHandler.OnExit += StartExit;
        ArrivalEventHandler.OnNoPrescription += NoPrescriptionExit;
    }

    private void OnDisable()
    {
        ArrivalEventHandler.OnExit -= StartExit;
        ArrivalEventHandler.OnNoPrescription -= NoPrescriptionExit;
    }
    #endregion
}
