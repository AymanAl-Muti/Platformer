using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;
    [SerializeField] private float iFrame = 2f;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
   
    public void Damage()
    { 
        if(iFrame <= 0f)
        {
            currentHealth -= 1;
            iFrame -= Time.deltaTime;
        }
    
    }

    private void Update()
    {
        if(iFrame <= 0f)
        {
            iFrame = 2f;
        }
    }
}
