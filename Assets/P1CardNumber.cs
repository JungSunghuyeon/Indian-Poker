using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class P1CardNumber : MonoBehaviourPunCallbacks, IPunObservable
{
    public static Text tx_p1Num;
    public  static int p1Num;

    void Start()
    {
        tx_p1Num = GetComponent<Text>();
        p1Num = Card_Get1.txt_card_transport();
        tx_p1Num.text = p1Num.ToString();
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        try
        {
            if (stream.IsWriting)
            {
                stream.SendNext(p1Num);
                stream.SendNext(tx_p1Num.text);
            }
            else
            {
                p1Num = (int)stream.ReceiveNext();
                tx_p1Num.text = (string)stream.ReceiveNext();
            }
        }
        catch (System.NullReferenceException)
        {

        }
    }
}
