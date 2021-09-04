using UnityEngine;

/**
 * *** Bow ***
 * rotates according to the mouse cursor input
 * Shoots if mouse button clicked
 * 
 */
public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public float launchForce;
    public Transform shotPoint;

    // Update is called once per frame
    void Update()
    {
        RotateArrowToMouse();

        if (Input.GetMouseButtonDown(0)) Shoot();
        
    }

    private void Shoot()
    {
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }

    private void RotateArrowToMouse()
    {
        Vector2 bowPoisiton = this.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPoisiton;
        transform.right = direction;
    }

    
}
