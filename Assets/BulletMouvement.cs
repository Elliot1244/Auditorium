using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMouvement : MonoBehaviour
{

    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed;
    [SerializeField] Vector2 _direction;

    // Start is called before the first frame update
    private void Start()
    {
        _rb.velocity = _direction * _speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
