using System.Collections;
using System.Collections.Generic;
using GKCore.Observers;
using UnityEngine;

public class CameraDepthController : MonoBehaviour
{
    public float currentDepth;
    public FloatVar targetDepth;

    public void SetTargetDepth(float depth)
    {
        targetDepth.Value = depth;
    }

    //Set VCam Orthographic Size to targetDepth
    void Awake()
    {
        currentDepth = targetDepth.Value;
        GetComponent<Cinemachine.CinemachineVirtualCamera>().m_Lens.OrthographicSize = targetDepth.Value;
    }
    void Update(){
        // Slowly move the camera to the target depth
        currentDepth = Mathf.Lerp(currentDepth, targetDepth.Value, 0.1f);
        GetComponent<Cinemachine.CinemachineVirtualCamera>().m_Lens.OrthographicSize = currentDepth;
    }
}
