using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluenceGuizmo : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;
    [SerializeField] CircleCollider2D _areaCircle;
    [SerializeField] AreaEffector2D _areaEffector;

    Vector2 _oldMousePosition;
    void OnMouseDown()
    {
        Debug.Log("Down on influencer");
        _oldMousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

     void OnMouseDrag()
    {
        Debug.Log("Drag on influencer");
        Vector2 currentMousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 _position2D = transform.position;
        float _distanceBetweenOriginAndCursor = Vector2.Distance(_position2D, currentMousePosition);

        _areaCircle.radius = _distanceBetweenOriginAndCursor;
        transform.localScale = new Vector3(_distanceBetweenOriginAndCursor, _distanceBetweenOriginAndCursor, _distanceBetweenOriginAndCursor);

        _oldMousePosition = currentMousePosition;
    }
}
