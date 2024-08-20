using System.Collections;
using System.Collections.Generic;
using GKCore.Observers;
using UnityEngine;

public class HealthStatLinker : MonoBehaviour
{
    public StatId maxHealthStatId;
    public StatId healthStatId;

    // Start is called before the first frame update
    void Awake()
    {
        HealthOwner healthOwner = GetComponent<HealthOwner>();
        gameObject.GetStatHolder(maxHealthStatId.id).onChanged += (value) =>
        {
            healthOwner.maxHealth.Value = value;
        };
        gameObject.GetStatHolder(maxHealthStatId.id).onChanged.Invoke(gameObject.GetStatHolder(maxHealthStatId.id).Value);
        gameObject.GetStatHolder(healthStatId.id).onChanged += (value) =>
        {
            healthOwner.health.Value = value;
        };
        gameObject.GetStatHolder(healthStatId.id).onChanged.Invoke(gameObject.GetStatHolder(healthStatId.id).Value);
    }
}
