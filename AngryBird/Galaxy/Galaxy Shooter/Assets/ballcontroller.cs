using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 mov = new Vector3(hor, ver, 0);
        GetComponent<Rigidbody>().AddForce(mov * 800 * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "abc")
        {
            // show destroy animation
            // Destroy()
        }
    }

}
