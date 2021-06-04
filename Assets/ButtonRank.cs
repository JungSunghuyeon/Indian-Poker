using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonRank : MonoBehaviour
{
    Button btn_rank;
    void Start()
    {
        btn_rank = GetComponent<Button>();
        btn_rank.onClick.AddListener(()=>SceneManager.LoadScene("rank"));
    }

   
}
