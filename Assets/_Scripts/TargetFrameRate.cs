using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFrameRate : MonoBehaviour
{
    public int FrameRate = 60;
    void Start()
    {
        Application.targetFrameRate = FrameRate;
    }
}
