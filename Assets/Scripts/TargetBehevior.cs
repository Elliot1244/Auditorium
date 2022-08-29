using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehevior : MonoBehaviour
{
    [SerializeField] Transform _transformToMove;
    [SerializeField] Camera _mainCamera;

    Vector2 _oldMousePosition;

    private void OnMouseDown()
    {
        _oldMousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("coucou");
    }

    private void OnMouseDrag()
    {
        //transform.position = GetMousePos();
        Vector2 currentMousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _transformToMove.Translate(currentMousePosition - _oldMousePosition, Space.World);

        _oldMousePosition = currentMousePosition;
    }

    Vector3 GetMousePos()
    {
        var _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = 0;
        return _mousePos;
    }

}
