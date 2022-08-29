using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdo : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] float _speed;
    [SerializeField] float _rotation;


    [SerializeField] Vector3 _jump;
    [SerializeField] float _jumpForce = 2.0f;

    PlateformScript _currentPlatform;
    PlateformScript2 _currentPlatform2;
    PlateformScript3 _currentPlatform3;
    void OnCollisionEnter(Collision collision)
    {
        var p = collision.gameObject.GetComponent<PlateformScript>();
        if (p != null)
        {
            _currentPlatform = p;
            //transform.position = collision.transform.position;

            Debug.Log("Ca bouge");
        }

        var p2 = collision.gameObject.GetComponent<PlateformScript2>();
        if (p2 != null)
        {
            _currentPlatform2 = p2;
            //transform.position = collision.transform.position;

            Debug.Log("Ca bouge");
        }

        var p3 = collision.gameObject.GetComponent<PlateformScript3>();
        if (p3 != null)
        {   
            _currentPlatform3 = p3;
            //transform.position = collision.transform.position;

            Debug.Log("Ca bouge");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        var p = collision.gameObject.GetComponent<PlateformScript>();
        if(p != null && _currentPlatform == p)
        {
            _currentPlatform = null;
        }

         var p2 = collision.gameObject.GetComponent<PlateformScript2>();
        if(p2 != null && _currentPlatform2 == p2)
        {
            _currentPlatform2 = null;
        }

        var p3 = collision.gameObject.GetComponent<PlateformScript3>();
        if (p3 != null && _currentPlatform3 == p3)
        {
            _currentPlatform3 = null;
        }
    }

    void FixedUpdate()
    {
        



        // Move
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical) * _speed;

        Vector3 futurPosition = transform.position + direction;
        Debug.DrawRay(transform.position, direction * 5, Color.red);
        Vector3 platformDelta = Vector3.zero;
        if(_currentPlatform != null)
        {
            platformDelta = _currentPlatform.transform.position - _currentPlatform.OldPosition;
        }
        else if(_currentPlatform2 != null)
        {
            platformDelta = _currentPlatform2.transform.position - _currentPlatform2.OldPosition;
        }
        else if (_currentPlatform3 != null)
        {
            platformDelta = _currentPlatform3.transform.position - _currentPlatform3.OldPosition;
        }


        _rigidbody.MovePosition(futurPosition + platformDelta);

        // Rotation
        float aimHorizontal = Input.GetAxis("AimHorizontal");
        float aimVertical = Input.GetAxis("AimVertical");

        Vector3 aimDirection = new Vector3(aimHorizontal, 0, aimVertical);
        transform.LookAt(transform.position + aimDirection);

        // Saut
        if (Input.GetKeyDown("space"))
        {
            _rigidbody.AddForce(_jump * _jumpForce, ForceMode.Impulse);
        }


        //Méthode rotation du joueur selon la souris
        //float h = _rotation * Input.GetAxis("Mouse X");
        //transform.Rotate(0, h, 0);

        Application.targetFrameRate = 30;
    }

    // Start is called before the first frame update
    void Start()
    {
        _jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
