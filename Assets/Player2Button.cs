using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Player2Button : MonoBehaviourPunCallbacks, IPunObservable
{
    public static Button btn_p2call, btn_p2half, btn_p2die;

    public static int p2bet;
    public static bool p2state = false;
   
    void Start()
    {
        btn_p2call = GameObject.Find("btn_p2call").GetComponent<Button>();
        btn_p2half = GameObject.Find("btn_p2half").GetComponent<Button>();
        btn_p2die = GameObject.Find("btn_p2die").GetComponent<Button>();

        btn_p2call.onClick.AddListener(p2Call);
        btn_p2half.onClick.AddListener(p2Half);
        btn_p2die.onClick.AddListener(p2Die);
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
            p2bet = Player1Button.p1bet;
            BettingCoin.num += p2bet;
            BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
        p2state = true;
        player2Disable();

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
            p2bet = Player1Button.p1bet + 1;
            BettingCoin.num += p2bet;
            BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
        p2state = false;
        player2Disable();

    }
    public void p2Die()
    {
        if (BettingCoin.num == 0)
        {

        }
        else
        {

        }
        p2state = false;
        player2Disable();
    }

    public void player2Disable(){
        btn_p2call.interactable = false;
        btn_p2half.interactable = false;
        btn_p2die.interactable = false;

        Player1Button.btn_p1call.interactable = true;
        Player1Button.btn_p1half.interactable = true;
        Player1Button.btn_p1die.interactable = true;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {

            stream.SendNext(Player1Button.btn_p1call.interactable);
            stream.SendNext(Player1Button.btn_p1half.interactable);
            stream.SendNext(Player1Button.btn_p1die.interactable);

            stream.SendNext(btn_p2call.interactable);
            stream.SendNext(btn_p2half.interactable);
            stream.SendNext(btn_p2die.interactable);

           
            stream.SendNext(Player1Button.p1bet);
            stream.SendNext(p2bet);
            stream.SendNext(BettingCoin.num);

            stream.SendNext(BettingCoin.tx_betcoin.text);

            stream.SendNext(p2state);

        }
        else
        {
            Player1Button.btn_p1call.interactable = (bool)stream.ReceiveNext();
            Player1Button.btn_p1half.interactable = (bool)stream.ReceiveNext();
            Player1Button.btn_p1die.interactable = (bool)stream.ReceiveNext();

            btn_p2call.interactable = (bool)stream.ReceiveNext();
            btn_p2half.interactable = (bool)stream.ReceiveNext();
            btn_p2die.interactable = (bool)stream.ReceiveNext();

            
            Player1Button.p1bet = (int)stream.ReceiveNext();
            p2bet = (int)stream.ReceiveNext();

            BettingCoin.num = (int)stream.ReceiveNext();

            BettingCoin.tx_betcoin.text = (string)stream.ReceiveNext();

           p2state = (bool)stream.ReceiveNext();

        }
    }
}
