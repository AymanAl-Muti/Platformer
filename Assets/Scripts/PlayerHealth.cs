using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private Slider healthBar;
    private readonly float maxHealth = 100;
    private float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
    }
   
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.value = currentHealth / maxHealth;
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        healthBar.value = currentHealth / maxHealth;
    }
}
