using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;



public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }
    private static GameManager instance;
    public void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("Player1", Vector3.zero, Quaternion.identity);
        }
        else if (!PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("Player2", Vector3.zero, Quaternion.identity);
        }
        CardSpawn();


    }

    public void Update()
    {
        /*if (Player1Call.p1callstate == true && Player2Call.p2callstate == true)
        {
            if (int.Parse(P1CardNumber.tx_p1Num.text) > int.Parse(P2CardNumber.tx_p2Num.text))
            {
                Result.tx_result.text = Player1Name.p1Name + "승리";
            }
            else if (P1CardNumber.p1Num < P2CardNumber.p2Num)
            {
                Result.tx_result.text = Player2Name.p2Name + "승리";
            }
            else
            {
                Result.tx_result.text = "무승부";
            }
        }*/
    }

    public void CardSpawn()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("Card", Vector3.zero, Quaternion.identity);

        }
        else{
            return;
        }
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }

  
}

