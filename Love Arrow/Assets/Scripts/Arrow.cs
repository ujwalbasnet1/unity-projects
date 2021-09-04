using UnityEngine;

/**
 * *** Arrow ***
 * launches arrow
 * moves to direction arrow points
 * on collided remains sticked
 * and attached to the hit body
 * 
 */
public class Arrow : MonoBehaviour
{
    bool hasHit;
    Rigidbody2D rb;

    void Start()
    {
        hasHit = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _ChangeDirectionOfArrow();
    }

    private void _ChangeDirectionOfArrow()
    {
        if(!hasHit)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasHit = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;

        // attaches to the parent
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            transform.parent = collision.transform;
        }
        
    }
}
