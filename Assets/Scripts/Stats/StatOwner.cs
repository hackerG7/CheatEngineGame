using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatOwner : Owner
{
    public Transform statListContainer;
    public ObservableDictionary<string, FloatStatHolder> floatStats = new ObservableDictionary<string, FloatStatHolder>();

    public void AddFloatStat(FloatStatHolder stat)
    {
        floatStats.Add(stat.statId.id, stat);
    }
    void Awake(){
        statListContainer.OnTransformChildrenChanged(LoadStatsInChildren);
        LoadStatsInChildren();
    }
    void LoadStatsInChildren(){
        floatStats.Clear();
        foreach (Transform child in statListContainer)
        {
            FloatStatHolder stat = child.GetComponent<FloatStatHolder>();
            if(stat != null)
                AddFloatStat(stat);
        }
    }
    public FloatStatHolder GetFloatStatHolder(StatId statId)
    {
        return GetFloatStatHolder(statId.id);
    }
    public FloatStatHolder GetFloatStatHolder(string statId)
    {
        if(floatStats.ContainsKey(statId))
            return floatStats[statId];
        return null;
    }
}
