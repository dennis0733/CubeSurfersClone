using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject baseBoxRemoved;
    public float offsetY;
    public float offsetZ;
    void Start()
    {
        baseBoxRemoved = FindObjectOfType<BaseBoxRemoved>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(transform.localPosition.x, offsetY + baseBoxRemoved.transform.localPosition.y / 1.5f, offsetZ);
        transform.localPosition = Vector3.Lerp(transform.localPosition, newPos, 5 * Time.deltaTime);
    }
}
