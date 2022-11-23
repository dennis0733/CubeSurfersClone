using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBoxRemoved : MonoBehaviour
{
    private BlockStack blockStack;
    private Camera gameCamera;
    private Vector3 newCamPos;
    void Start()
    {
        blockStack = FindObjectOfType<BlockStack>();
    }

    void OnCollisionEnter(Collision collision)
    {
        gameCamera = Camera.main;
        string tag = collision.transform.tag;
        if (tag == ("Obstacle") || tag == ("FinalObstacle"))
        {
            RemoveBox();
        }
        else if (tag == ("GroundObstacle"))
        {
            GetComponent<BoxCollider>().isTrigger = true;
            RemoveBox();
        }
    }
    private void RemoveBox()
    {
        FindObjectOfType<AudioManager>().Play("BoxLose");
        gameCamera.fieldOfView = gameCamera.fieldOfView > 70 ? gameCamera.fieldOfView -= 1f : 70;

        if (!(gameCamera.transform.localPosition.z <= 11.1))
            Camera.main.GetComponent<CameraFollow>().offsetZ += .1f;
        blockStack.RemoveBoxToStack(this.gameObject);

        Destroy(this);
    }
}
