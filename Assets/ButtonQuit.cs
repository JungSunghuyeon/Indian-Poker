using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ButtonQuit : MonoBehaviour
{
    Button Exit_btn;
    void Start()
    {
        Exit_btn = GetComponent<Button>();
        Exit_btn.onClick.AddListener(()=>Application.Quit());
    }


}
