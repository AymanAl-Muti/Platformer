using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private Slider healthBar;
    [SerializeField] private float maxHealth;
    private float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            TakeDamage(10);
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            Heal(10);
        }
        if(transform.position.y <=-10)
        {
            Debug.Log("Out of Bounds");
            TakeDamage(100);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        healthBar.value = currentHealth / maxHealth;
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.value = currentHealth / maxHealth;
    }

    private void Die()
    {
        Debug.Log("The player died");
    }
}
