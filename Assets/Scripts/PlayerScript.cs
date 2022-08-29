using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{

    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed = 0.1f;


    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            _rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }

        if (Input.GetKey("right")) 
        {
            transform.position = new Vector3(transform.position.x + _speed, transform.position.y);
        }

        if (Input.GetKey("left"))
        {
            transform.position = new Vector3(transform.position.x - _speed, transform.position.y);
        }
    }
}
