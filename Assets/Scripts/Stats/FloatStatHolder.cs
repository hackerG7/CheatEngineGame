using System.Collections;
using System.Collections.Generic;
using GKCore.Observers;
using Unity.VisualScripting;
using UnityEngine;
[ExecuteInEditMode]
public class FloatStatHolder : VarHolder<FloatStat, float>
{
    public StatId statId;
    void OnValidate(){
        // Rename
        if(statId != null)
            name = statId.id;
    }
    public void AddValue(float value){
        observableVar.Value += value;
    }
    public void SubtractValue(float value){
        observableVar.Value -= value;
    }
    public void MultiplyValue(float value){
        observableVar.Value *= value;
    }
    public void DivideValue(float value){
        observableVar.Value /= value;
    }
}
