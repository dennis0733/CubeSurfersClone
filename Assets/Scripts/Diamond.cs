using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour, ICollectable
{
    DiamondManager diamondManager;
    void Start()
    {
        diamondManager = FindObjectOfType<DiamondManager>();
    }
    public void Collect()
    {
        diamondManager.Add();
        Destroy(this.gameObject);
    }
}
