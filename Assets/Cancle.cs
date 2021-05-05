using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cancle: MonoBehaviour
{
    public void Change() {
        SceneManager.LoadScene("Login");
    }
}
