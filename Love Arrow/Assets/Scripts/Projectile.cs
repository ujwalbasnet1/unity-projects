using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject arrow;
    public float launchForce;
    public Transform shotPoint;


    Vector2 targetPosition = new Vector2(-8.8f, -2.9f); // TODO

    float timer;

    void Update()
    {
        _RotateArrowToMouse();

        timer += Time.deltaTime;

        // TODO check if target is in surrounding
        if (timer > 2)
        {
            Shoot();
            timer = 0;
        }


    }

    // for aiming little higher then actual position of target
    private Vector2 getShootingPosition()
    {
        return targetPosition + new Vector2(0, 1);
    }

    private void Shoot()
    {

        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        Rigidbody2D rb = newArrow.GetComponent<Rigidbody2D>();

        Vector2 _directionToInitial = getShootingPosition() - rb.position;
        rb.AddForce(_directionToInitial * launchForce);
    }

    private void _RotateArrowToMouse()
    {
        Vector2 bowPoisiton = this.shotPoint.position;
        Vector2 direction = getShootingPosition()- bowPoisiton;
        transform.right = direction;
    }


    
}

