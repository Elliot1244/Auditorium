using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefabs;
    [SerializeField] float _spwanCooldown;

    //[SerializeField] Vector2  _minMax;
    [SerializeField] float _max;
    [SerializeField] float _min;

    float _lastShoot;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rx = Random.Range(_min, _max);
        float ry = Random.Range(_min, _max);

        Vector3 randomDirection = new Vector3(rx, ry);

        if (Time.time > _lastShoot + _spwanCooldown)
        {
            _lastShoot = Time.time;
            GameObject.Instantiate(_bulletPrefabs, transform.position + randomDirection, transform.rotation);
        }
            
    }

    private void FixedUpdate()
    {
        
    }
}
