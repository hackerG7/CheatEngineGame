using System.Collections;
using System.Collections.Generic;
using GKCore.Observers;
using Unity.VisualScripting;
using UnityEngine;

public class FloatStatHolder : GKBehaviour
{
    public StatId statId;
    [RenamedFrom("floatVar")]
    public FloatStat floatStat;
    public float Value{
        get{
            return floatStat.Value;
        }
        set{
            floatStat.Value = value;
        }
    }
    public void SetValue(float value){
        floatStat.Value = value;
    }
    public void AddValue(float value){
        floatStat.Value += value;
    }
    public void SubtractValue(float value){
        floatStat.Value -= value;
    }
    public void MultiplyValue(float value){
        floatStat.Value *= value;
    }
    public void DivideValue(float value){
        floatStat.Value /= value;
    }
}
