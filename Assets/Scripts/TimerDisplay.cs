using System.Collections;
using System.Collections.Generic;
using GKCore.Observers;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    public RectTransform clockHand;
    public FloatVar maxTime;
    public FloatVar currentTime;

    public void SetCurrentTime(float time)
    {
        currentTime.Value = time;
    }
    public void SetMaxTime(float time)
    {
        maxTime.Value = time;
    }
    //Rotate the clock hand according to the time
    void Update()
    {
        float angle = 360 * (currentTime.Value / maxTime.Value);
        clockHand.rotation = Quaternion.Euler(0, 0, angle);
    }
}
