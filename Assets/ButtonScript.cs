using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{

    [SerializeField] Button _buttonToControl;

    [SerializeField] UnityEvent _onPressed;
    [SerializeField] UnityEvent _onReleased;

    bool _isPressed;


    private void Start()
    {
        _buttonToControl.onClick.AddListener(MaFontion);
        _isPressed = false;
    }

    void ForceReleased()
    {
        _isPressed = false;
        _onReleased.Invoke();
    }

    void MaFontion()
    {
        if(_isPressed == true)
        {
            _isPressed = false;
        }
        else if(_isPressed == false)
        {
            _isPressed = true;
        }

        if(_isPressed)
        {
            _onPressed.Invoke();
        }
        else
        {
            _onReleased.Invoke();
        }
    }
}
