using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvailableButton : MonoBehaviour
{
    Button availbutton;
    GameObject avail;
    void Start()
    {
        availbutton = GetComponent<Button>();
        avail = GameObject.Find("Avail");

        availbutton.onClick.AddListener(AvailClick);
    }

    public void AvailClick(){
        avail.SetActive(false);
    }
}
