using UnityEngine;

public static class GameObject_StatExtension{
    public static StatOwner GetStatOwner(this GameObject gameObject){
        return gameObject.GetComponentInParent<StatOwner>();
    }
    public static void AddStat(this GameObject gameObject, FloatStatHolder stat){
        if(gameObject == null) return;
        StatOwner statOwner = gameObject.GetStatOwner();
        statOwner?.AddFloatStat(stat);
    }
    public static FloatStatHolder GetStatHolder(this GameObject gameObject, string statId){
        if(gameObject == null) return null;
        StatOwner statOwner = gameObject.GetStatOwner();
        return statOwner?.GetFloatStatHolder(statId);
    }
    public static float GetStat(this GameObject gameObject, string statId){
        if(gameObject == null) return 0;
        FloatStatHolder statHolder = gameObject.GetStatHolder(statId);
        return statHolder?.Value ?? 0;
    }
    public static void SetStatValue(this GameObject gameObject, StatId statId, float value){
        if(gameObject == null) return;
        FloatStatHolder statHolder = gameObject.GetStatHolder(statId.id);
        if(statHolder != null)
            statHolder.Value = value;
    }
    public static void AddStatMultiplier(this GameObject gameObject, StatId statId, float value){
        if(gameObject == null) return;
        FloatStatHolder statHolder = gameObject.GetStatHolder(statId.id);
        if(statHolder != null)
            statHolder.observableVar.AddMultiplier(value);
    }
}