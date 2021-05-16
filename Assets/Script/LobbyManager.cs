using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    private readonly string gameVersion = "1";
    public Button joinButton;
    public Text connectionInfoText;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();
        connectionInfoText.text = "connecting To Master Server";
    }
    public override void OnConnectedToMaster(){
        joinButton.interactable = true;
        connectionInfoText.text ="connected to Master Server";
    }
    public override void OnDisconnected(DisconnectCause cause){
        joinButton.interactable = false;
        connectionInfoText.text = $"offline : connection disabled {cause.ToString()} - try reconnecting ..";
        PhotonNetwork.ConnectUsingSettings();
    }
    public void Connect(){
        joinButton.interactable = false;
        if(PhotonNetwork.IsConnected){
            connectionInfoText.text = "Connection to Random Room";
            PhotonNetwork.JoinRandomRoom();
        }else{
            connectionInfoText.text = "offline : connection disabled - try reconnecting ..";
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    public override void OnJoinRandomFailed(short returnCode, string message){
        connectionInfoText.text = "There is no empty Room, Creating New Room..";
        PhotonNetwork.CreateRoom(null, new RoomOptions{MaxPlayers = 2});
    }
    public override void OnJoinedRoom(){
        connectionInfoText.text = "connected with Room";
        //PhotonNetwork.LoadLevel("GameBoard");
    }
}
