using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //Ref
    private Vector3 mOffset;

    //Config
    [SerializeField] private float sensitivity;
    private float leftSideOffset;
    private float rightSideOffset;
    private float mZCoord;

    private void Start()
    {
        leftSideOffset = -2;
        rightSideOffset = 2;
        
    }
    private void Update()
    { MovementHandler(); }
    private void MovementHandler()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = gameObject.transform.localPosition - GetMouseAsWorldPoint();
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 targetPos = new Vector3(Mathf.Clamp(GetMouseAsWorldPoint().x + mOffset.x, leftSideOffset, rightSideOffset), transform.localPosition.y, transform.localPosition.z);
            transform.localPosition = targetPos;
        }
    }
    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToViewportPoint(mousePoint) * sensitivity;
    }
}
