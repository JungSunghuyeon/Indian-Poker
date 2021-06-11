using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Player1ID : MonoBehaviourPunCallbacks, IPunObservable
{
    Text tx_player1ID;
    public static string player1ID;
    // Start is called before the first frame update
    void Start()
    {
        tx_player1ID = GetComponent<Text>();
        player1ID = Login.player_id;
        tx_player1ID.text = player1ID;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        try
        {
            if (stream.IsWriting)
            {
                stream.SendNext(tx_player1ID.text);
             
                stream.SendNext(player1ID);
                
            }
            else
            {
                tx_player1ID.text = (string)stream.ReceiveNext();
                
                player1ID = (string)stream.ReceiveNext();
                

            }
        }
        catch (System.NullReferenceException)
        {

        }
    }
}
