using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiamondManager : MonoBehaviour
{
    [SerializeField] private int diamonds;
    [SerializeField] private TextMeshProUGUI diamondsText;
    void Start()
    {
        diamonds = PlayerPrefs.GetInt("PlayerDiamonds", 0);
        diamondsText.text = diamonds.ToString();
    }
    public void Add()
    {
        diamonds += 2;
        PlayerPrefs.SetInt("PlayerDiamonds", diamonds);
        diamondsText.text = diamonds.ToString();
    }
}
