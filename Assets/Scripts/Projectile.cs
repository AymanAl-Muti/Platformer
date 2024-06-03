using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}