using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage()
    {
        currentHealth -=1;
    
    }
}
