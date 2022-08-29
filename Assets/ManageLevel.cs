using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageLevel : MonoBehaviour
{

    [SerializeField] BulletReceiver _objectif;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_objectif.IsValidated())
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
