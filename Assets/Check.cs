using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Check : MonoBehaviour
{
    Button checkbutton;
    GameObject check;

    void Start()
    {
        checkbutton = GetComponent<Button>();
        check = GameObject.Find("Check");

        checkbutton.onClick.AddListener(checkClick);
    }

    public void checkClick(){
        check.SetActive(false);
    }
}
