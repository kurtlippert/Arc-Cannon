using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    void Update()
    {
        // Projectile code
        Vector3 moveDirection = rigidbody2D.velocity;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy calling script. Essentially stop projectile code ^^
        Destroy(this);

        // Also, we wanna tell our event manager about the collision
        EventManager.ArrowCollision(this.gameObject, collision);
    }
}
