using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Click : MonoBehaviourPunCallbacks, IPunObservable
{
    public Button btn_p1call, btn_p1half, btn_p1die, btn_p2call, btn_p2half, btn_p2die;
    int p1bet, p2bet;
    int turn;

    void Awake()
    {
        Invoke("Firstturn", 3f);
    }
    void Start()
    {

        btn_p1call.onClick.AddListener(p1Call);
        btn_p1half.onClick.AddListener(p1Half);
        btn_p1die.onClick.AddListener(p1Die);

        btn_p2call.onClick.AddListener(p2Call);
        btn_p2half.onClick.AddListener(p2Half);
        btn_p2die.onClick.AddListener(p2Die);
    }

    public void p1Call()
    {
        if (BettingCoin.num == 0)
        {
            p1bet = 1;
            BettingCoin.num += p1bet;
            BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
        else
        {
            p1bet = p2bet;
            BettingCoin.num += p1bet;
            BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
        if (PhotonNetwork.IsMasterClient)
        {
            p1Disable();
        }
        else{
            p1Disable();
        }
    }
    public void p1Half()
    {
        if (BettingCoin.num == 0)
        {
            p1bet = 2;
            BettingCoin.num += p1bet;
            BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
        else
        {
            p1bet = p2bet + 2;
            BettingCoin.num += p1bet;
            BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
        if (PhotonNetwork.IsMasterClient)
        {
            p1Disable();
        }
        else{
            p1Disable();
        }
    }
    public void p1Die()
    {
        if (BettingCoin.num == 0)
        {

        }
        else
        {

        }
        if (PhotonNetwork.IsMasterClient)
        {
            p1Disable();
        }
        else{
            p1Disable();
        }
    }


    public void p2Call()
    {
        if (BettingCoin.num == 0)
        {
            p2bet = 1;
            BettingCoin.num += p2bet;
            BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
        else
        {
            p2bet = p1bet;
            BettingCoin.num += p2bet;
            BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
        if (PhotonNetwork.IsMasterClient)
        {
            p2Disable();
        }
        else{
            p2Disable();
        }
    }
    public void p2Half()
    {
        if (BettingCoin.num == 0)
        {
            p2bet = 2;
            BettingCoin.num += p2bet;
            BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
        else
        {
            p2bet = p1bet + 1;
            BettingCoin.num += p2bet;
            BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
        if (PhotonNetwork.IsMasterClient)
        {
            p2Disable();
        }
         else{
            p2Disable();
        }
    }
    public void p2Die()
    {
        if (BettingCoin.num == 0)
        {

        }
        else
        {

        }
        if (PhotonNetwork.IsMasterClient)
        {
            p2Disable();
        }
         else{
            p2Disable();
        }
    }

    public void p1Disable()
    {             //플레이어1 버튼 비활성화, 플레이어2 버튼 활성화

        btn_p1call.interactable = false;
        btn_p1half.interactable = false;
        btn_p1die.interactable = false;

        btn_p2call.interactable = true;
        btn_p2half.interactable = true;
        btn_p2die.interactable = true;

    }
    public void p2Disable()
    {            //플레이어2 버튼 비활성화, 플레이어1 버튼 활성화
        btn_p1call.interactable = true;
        btn_p1half.interactable = true;
        btn_p1die.interactable = true;

        btn_p2call.interactable = false;
        btn_p2half.interactable = false;
        btn_p2die.interactable = false;

    }
    public void Firstturn()
    {        //첫 턴 

        turn = Random.Range(1, 3);
        if (turn == 1)
        {                             //플레이어 1이 첫 번째 턴
            btn_p1call.interactable = true;
            btn_p1half.interactable = true;
            btn_p1die.interactable = true;
        }
        else if (turn == 2)
        {                        //플레이어 2가 첫 번째 턴
            btn_p2call.interactable = true;
            btn_p2half.interactable = true;
            btn_p2die.interactable = true;
        }

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(turn);
            stream.SendNext(p1bet);
            stream.SendNext(p2bet);
            stream.SendNext(BettingCoin.num);

            stream.SendNext(BettingCoin.tx_betcoin.text);

            stream.SendNext(btn_p1call.interactable);
            stream.SendNext(btn_p1half.interactable);
            stream.SendNext(btn_p1die.interactable);

            stream.SendNext(btn_p2call.interactable);
            stream.SendNext(btn_p2half.interactable);
            stream.SendNext(btn_p2die.interactable);

        }
        else
        {
            turn = (int)stream.ReceiveNext();
            p1bet = (int)stream.ReceiveNext();
            p2bet = (int)stream.ReceiveNext();

            BettingCoin.num = (int)stream.ReceiveNext();

            BettingCoin.tx_betcoin.text = (string)stream.ReceiveNext();

            btn_p1call.interactable = (bool)stream.ReceiveNext();
            btn_p1half.interactable = (bool)stream.ReceiveNext();
            btn_p1die.interactable = (bool)stream.ReceiveNext();

            btn_p2call.interactable = (bool)stream.ReceiveNext();
            btn_p2half.interactable = (bool)stream.ReceiveNext();
            btn_p2die.interactable = (bool)stream.ReceiveNext();

        }
    }


}
