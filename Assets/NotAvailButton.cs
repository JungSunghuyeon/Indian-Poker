using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotAvailButton : MonoBehaviour
{
    Button not_availbutton;
    GameObject Notavail;
    void Start()
    {
        not_availbutton = GetComponent<Button>();
        Notavail = GameObject.Find("NotAvail");

        not_availbutton.onClick.AddListener(Not_AvailClick);
    }

    public void Not_AvailClick(){
        Notavail.SetActive(false);
    }
}
