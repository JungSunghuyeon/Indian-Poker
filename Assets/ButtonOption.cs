using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonOption : MonoBehaviour
{
     Button btn_option;
    void Start()
    {
        btn_option = GetComponent<Button>();
        btn_option.onClick.AddListener(()=>SceneManager.LoadScene("option"));
    }



}
