using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System;

public class P2CardNumber : MonoBehaviourPunCallbacks, IPunObservable
{
    public static Text tx_p2Num;
    public static int p2Num;
    void Start()
    {
        tx_p2Num = GetComponent<Text>();
        p2Num = Card_Get2.txt_card_transport();
        tx_p2Num.text = p2Num.ToString();
        //Debug.Log("p2카드 " +P2CardNumber.p2Num);
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.IsWriting)
        {
            try
            {
                stream.SendNext(p2Num);
                stream.SendNext(tx_p2Num.text);
            }
            catch (NullReferenceException ex)
            {
                Debug.Log("");
            }
        }
        else
        {
            try
            {
                p2Num = (int)stream.ReceiveNext();
                tx_p2Num.text = (string)stream.ReceiveNext();
            }
            catch (NullReferenceException ex)
            {
                Debug.Log("");
            }
        }


    }
}
