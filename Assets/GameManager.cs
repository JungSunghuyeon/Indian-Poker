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
        ButtonSpawn();

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
    public void ButtonSpawn()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("Button", Vector3.zero, Quaternion.identity);

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

