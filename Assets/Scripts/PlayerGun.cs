using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity);
        
        proj.GetComponent<Rigidbody2D>().velocity = transform.right * 30;
    }
}