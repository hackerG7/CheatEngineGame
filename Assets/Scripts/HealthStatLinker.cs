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
        gameObject.GetStatHolder(maxHealthStatId.id).onChanged += (value) =>
        {
            healthOwner.maxHealth.Value = value;
        };
        gameObject.GetStatHolder(maxHealthStatId.id).onChanged.Invoke(gameObject.GetStatHolder(maxHealthStatId.id).Value);
        healthOwner.health = healthOwner.maxHealth;
    }
}
