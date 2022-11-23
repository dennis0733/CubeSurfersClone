using System.Diagnostics.Tracing;
using System;
using UnityEngine;
public class OnBoxAdded : MonoBehaviour, ICollectable
{
    private BlockStack blockStack;
    private InputManager InputManager;
    private Transform character;
    private Camera gameCamera;
    private Vector3 newCamPos;

    void Start()
    {
        blockStack = FindObjectOfType<BlockStack>();
        InputManager = FindObjectOfType<InputManager>();
        character = InputManager.transform.GetChild(0);
    }
    public void Collect()
    {
        if (!blockStack) return;

        bool blockAdded = blockStack.AddBoxToStack(this.gameObject);
        if (blockAdded)
        {
            RePositionBlock();
        }
        
    }
    private void RePositionBlock()
    {
        //Blocks Go Under Base Box
        FindObjectOfType<AudioManager>().Play("BoxGather");
        transform.SetParent(character.transform);
        character.localPosition += Vector3.up * 1.1f;
        transform.localPosition = new Vector3(0, ((blockStack.boxList.Count) * -1.1f), 0);
        Camera.main.fieldOfView += 1f;
        Camera.main.GetComponent<CameraFollow>().offsetZ -= .1f;
        Destroy(this);
    }
}
