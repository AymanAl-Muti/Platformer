using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float bulletSpeed;
    private bool canShoot;
    private void Awake()
    {
        canShoot = true;
    }

    private void Shoot()
    {
        Vector2 bulletDirection = Vector3.Normalize(GameManager.Instance.CursorPos - (Vector2)transform.position);
        
        GameObject proj = Instantiate(projectile, transform.position, Quaternion.FromToRotation(transform.position, bulletDirection));

        proj.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;
    }

    public void OnShootKeyPressed(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(canShoot)
            {
                Shoot();
            }
        }
    }
}