using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonExit : MonoBehaviour
{
    Button btn_exit;
    void Start()
    {
        btn_exit = GetComponent<Button>();
        btn_exit.onClick.AddListener(()=>SceneManager.LoadScene("Login"));
    }


    
}
