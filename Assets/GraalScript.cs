using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GraalScript : MonoBehaviour
{
    [SerializeField] GameObject _graal;

    // the range of X
    [Header("Limitation X")]
    [SerializeField] float _xMin;
    [SerializeField] float _xMax;

    // the range of y
    [Header("Limitation Y")]
    [SerializeField] float _yMin;
    [SerializeField] float _yMax;


    //public UnityEvent<GraalScript> OnGraalCollected;


    void OnTriggerEnter2D(Collider2D collision)
    {
            var p = collision.gameObject.GetComponent<PlayerScript>();
            GameObject Graal = _graal;

            if (p != null)
            {
                Debug.Log("Enemie Touché");

                // Définition des limites x et y de manière aléatoires
                Vector2 pos = new Vector2(Random.Range(_xMin, _xMax), Random.Range(_yMin, _yMax));

                // Création de l'objet.
                Instantiate(Graal, pos, transform.rotation);
            }
            Destroy(_graal);
        //OnGraalCollected.Invoke(this);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
