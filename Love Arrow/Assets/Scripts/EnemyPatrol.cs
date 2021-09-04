using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * *** Enemy - Patrol ***
 * moves on ground back and forth
 * 
 */
public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public float distance;
    public Transform groundDetection;

    private int canHit = 1;
    private int hit = 0;
    private bool movingRight = true;
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        canHit = enemy.GetNumberOfArrowShots();
        print(canHit);
    }

    void Update()
    {
        if (hit < canHit)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            RaycastHit2D groundHitInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, LayerMask.GetMask("Ground"));
            if (groundHitInfo.collider == false)
            {
                if (movingRight)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Arrow"))
        {
            hit++;
        }
        
    }
}
