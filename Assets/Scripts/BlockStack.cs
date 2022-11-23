using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStack : MonoBehaviour
{
    [SerializeField] public List<GameObject> boxList;
    public bool AddBoxToStack(GameObject box)
    {
        boxList.Add(box);
        return true;
    }
    public void RemoveBoxToStack(GameObject box)
    {
        box.transform.parent = null;
        boxList.Remove(box);
    }
}
