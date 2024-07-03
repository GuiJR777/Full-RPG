using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using TMPro;
using UnityEngine;

public class HealthDebugLabel : MonoBehaviour
{
    [SerializeField] TextMeshPro healthLabel;
    Health healthComponent;
    bool dead = false;

    void Start()
    {
        healthComponent = GetComponent<Health>();
    }


    void Update()
    {
        if (dead) return;

        float health = healthComponent.GetHealth();
        healthLabel.text = health.ToString();

        if (health <= 0)
        {
            Destroy(healthLabel);
            dead = true;
        }
    }
}
