using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Result : MonoBehaviourPunCallbacks, IPunObservable
{
    public static Text tx_result;

    void Start()
    {
        tx_result = GameObject.Find("tx_result").GetComponent<Text>();
        tx_result.text = " ";
    }

    public void Update() {
        if(Player1Button.p1state == true && Player2Button.p2state == true){
            Debug.Log(P1CardNumber.p1Num);
            Debug.Log(P2CardNumber.p2Num);
            if(P1CardNumber.p1Num > P2CardNumber.p2Num){
                tx_result.text = Player1Name.tx_p1Name.text + "승리";
            }
            else if(P1CardNumber.p1Num < P2CardNumber.p2Num){
                tx_result.text = Player2Name.tx_p2Name.text + "승리";
            }
            else{
                tx_result.text = "무승부";
            }
        }
    }

   public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        try
        {
            if (stream.IsWriting)
            {
                stream.SendNext(Player1Button.p1state);
                stream.SendNext(Player2Button.p2state);

                stream.SendNext(P1CardNumber.p1Num);
                stream.SendNext(P2CardNumber.p2Num);

                stream.SendNext(Player1Name.tx_p1Name.text);
                stream.SendNext(Player2Name.tx_p2Name.text);

                stream.SendNext(tx_result.text);
                
                
            }
            else
            {
            Player1Button.p1state = (bool)stream.ReceiveNext();
            Player2Button.p2state = (bool)stream.ReceiveNext();

            P1CardNumber.p1Num = (int)stream.ReceiveNext();
            P2CardNumber.p2Num = (int)stream.ReceiveNext();

            Player1Name.p1Name = (string)stream.ReceiveNext();
            Player2Name.p2Name = (string)stream.ReceiveNext();

            tx_result.text = (string)stream.ReceiveNext();
            
            }
        }
        catch (System.NullReferenceException)
        {

        }
    }
}
