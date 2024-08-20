using System.Collections;
using System.Collections.Generic;
using GKCore.Observers;
using UnityEngine;

public class HealthStatLinker : MonoBehaviour
{
    public StatId maxHealthStatId;

    // Start is called before the first frame update
    void Awake()
    {
        HealthOwner healthOwner = GetComponent<HealthOwner>();
        gameObject.GetStatHolder(maxHealthStatId.id).observableVar.onChanged += (old, value) =>
        {
            float diff = value - old;
            healthOwner.maxHealth.Value = value;
            if(healthOwner.health.Value > healthOwner.maxHealth.Value)
                healthOwner.health.Value = healthOwner.maxHealth.Value;

        };
        gameObject.GetStatHolder(maxHealthStatId.id).onChanged.Invoke(gameObject.GetStatHolder(maxHealthStatId.id).Value);
        GKUtils.RunAfterSeconds(()=>{
            healthOwner.health.Value = healthOwner.maxHealth.Value;
        }, 0.05f);
    }
    void Start(){
        HealthOwner healthOwner = GetComponent<HealthOwner>();
        healthOwner.health.Value = healthOwner.maxHealth.Value;
    }
}
