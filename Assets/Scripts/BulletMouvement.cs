using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMouvement : MonoBehaviour
{

    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed;
    [SerializeField] Vector2 _direction;
    [SerializeField] float _lifeSpan;

    float _startLife;

    // Start is called before the first frame update
    private void Start()
    {
        _rb.velocity = _direction * _speed;
        _startLife = Time.time;
    }



    // Update is called once per frame
    private void Update()
    {
       if(Time.time > _startLife + _lifeSpan)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
