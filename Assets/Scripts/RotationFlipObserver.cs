using System.Collections;
using System.Collections.Generic;
using GKCore.Observers;
using UltEvents;
using UnityEngine;

public class RotationFlipObserver : MonoBehaviour
{
    [Header("Variables")]
    public BoolVar isFlippedRight;
    void Update(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        if(angle > 90 || angle < -90){
            isFlippedRight.Value = false;
        }else{
            isFlippedRight.Value = true;
        }
    }
}
