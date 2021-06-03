using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BettingCoin : MonoBehaviour
{
    public static Text tx_betcoin;
    public static int num = 0;
    void Start()
    {
        tx_betcoin = GetComponent<Text>();
        tx_betcoin.text = num.ToString();
    }

}
