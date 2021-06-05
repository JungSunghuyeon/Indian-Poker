using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;



public class GameManager : MonoBehaviourPunCallbacks, IPunObservable
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
    int turn;
    public void Start()
    {
        
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("Player1", Vector3.zero, Quaternion.identity);
            PhotonNetwork.Instantiate("Player1Button", Vector3.zero, Quaternion.identity);
        }
        else if (!PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("Player2", Vector3.zero, Quaternion.identity);
            PhotonNetwork.Instantiate("Player2Button", Vector3.zero, Quaternion.identity);
            Invoke("Firstturn",5f);
        }
        CardSpawn();
        
        
        

    }

    public void Firstturn(){
        turn = Random.Range(1,3);
        if(turn == 1){
            Player1Button.btn_p1call.interactable = true;
            Player1Button.btn_p1half.interactable = true;
            Player1Button.btn_p1die.interactable = true;
        }
        else if(turn == 2){
            Player2Button.btn_p2call.interactable = true;
            Player2Button.btn_p2half.interactable = true;
            Player2Button.btn_p2die.interactable = true;
        }
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

     public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(turn);

            stream.SendNext(Player1Button.btn_p1call.interactable);
            stream.SendNext(Player1Button.btn_p1half.interactable);
            stream.SendNext(Player1Button.btn_p1die.interactable);

            stream.SendNext(Player2Button.btn_p2call.interactable);
            stream.SendNext(Player2Button.btn_p2half.interactable);
            stream.SendNext(Player2Button.btn_p2die.interactable);
            
           


        }
        else
        {
          
            Player1Button.btn_p1call.interactable = (bool)stream.ReceiveNext();
            Player1Button.btn_p1half.interactable = (bool)stream.ReceiveNext();
            Player1Button.btn_p1die.interactable = (bool)stream.ReceiveNext();

            Player2Button.btn_p2call.interactable = (bool)stream.ReceiveNext();
            Player2Button.btn_p2half.interactable = (bool)stream.ReceiveNext();
            Player2Button.btn_p2die.interactable = (bool)stream.ReceiveNext();
            

        
        }
    }
  
}

