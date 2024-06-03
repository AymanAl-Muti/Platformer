using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter()
    {
        Debug.Log("Collision");
        
        Destroy(gameObject);
    }
}