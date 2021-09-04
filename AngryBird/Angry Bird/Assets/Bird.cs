using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _birdWasLaunched;
    private float _timeSittingAround;

    [SerializeField] private float _launchPower = 200;
    

    private void Awake()
    {
        _initialPosition = transform.position;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);

        if (_birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }



        if(_timeSittingAround > 3 ||
            transform.position.y < -10 ||
            transform.position.y > 10 ||
            transform.position.x > 10 ||
            transform.position.x < -15)
        {
            string name = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(name);
        }
    }


    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        GetComponent<LineRenderer>().enabled = false;

        GetComponent<SpriteRenderer>().color = Color.white;

        // launch bird
        Vector2 _directionToInitial = _initialPosition - transform.position;

        Rigidbody2D _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.AddForce(_directionToInitial * _launchPower);
        _rigidBody.gravityScale = 1;

        _birdWasLaunched = true;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y, 0);
    }

}
