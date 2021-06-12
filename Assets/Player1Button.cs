using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System;



public class Player1Button : MonoBehaviourPunCallbacks, IPunObservable
{
    public static Button btn_p1call, btn_p1half, btn_p1die;

    public GameObject button_p1call, button_p1half, button_p1die;

    public static int p1bet;
    public static bool p1state = false;
    public static bool p1die_state = false;

    public static int p1usercoin;
    void Start()
    {
        btn_p1call = GameObject.Find("btn_p1call").GetComponent<Button>();
        btn_p1half = GameObject.Find("btn_p1half").GetComponent<Button>();
        btn_p1die = GameObject.Find("btn_p1die").GetComponent<Button>();

        button_p1call = GameObject.Find("btn_p1call");
        button_p1half = GameObject.Find("btn_p1half");
        button_p1die = GameObject.Find("btn_p1die");

        if(!PhotonNetwork.IsMasterClient){
            button_p1call.SetActive(false);
            button_p1half.SetActive(false);
            button_p1die.SetActive(false);
        }

        btn_p1call.onClick.AddListener(p1Call);
        btn_p1half.onClick.AddListener(p1Half);
        btn_p1die.onClick.AddListener(p1Die);
        int.TryParse(Player1Coin.tx_p1Coin.text, out p1usercoin);
    }

    public void p1Call()
    {
        if (BettingCoin.num == 0)
        {
            if (p1usercoin < 0)
            {
                p1usercoin = 0;
                Player1Coin.tx_p1Coin.text = p1usercoin.ToString();
                p1bet = 0;
            }
            else if (p1bet >= p1usercoin)
            {
                p1bet = p1usercoin;
                BettingCoin.num += p1bet;
                p1usercoin -= p1bet;
                BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
                Player1Coin.tx_p1Coin.text = p1usercoin.ToString();
            }
            else
            {
                p1bet = 1;
                BettingCoin.num += p1bet;
                p1usercoin -= p1bet;
                BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
                Player1Coin.tx_p1Coin.text = p1usercoin.ToString();
            }
        }
        else
        {
            if (p1usercoin < 0)
            {
                p1usercoin = 0;
                Player1Coin.tx_p1Coin.text = p1usercoin.ToString();
                p1bet = 0;
            }
            else if (p1bet >= p1usercoin)
            {
                p1bet = p1usercoin;
                BettingCoin.num += p1bet;
                p1usercoin -= p1bet;
                BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
                Player1Coin.tx_p1Coin.text = p1usercoin.ToString();
            }
            else
            {
                p1bet = Player2Button.p2bet;
                BettingCoin.num += p1bet;
                p1usercoin -= p1bet;
                BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
                Player1Coin.tx_p1Coin.text = p1usercoin.ToString();
            }
        }
        p1state = true;
        player1Disable();

    }

    public void p1Half()
    {

        if (BettingCoin.num == 0)
        {
            if (p1usercoin < 0)
            {
                p1usercoin = 0;
                Player1Coin.tx_p1Coin.text = p1usercoin.ToString();
                p1bet = 0;
            }
            else if (p1bet >= p1usercoin)
            {
                p1bet = p1usercoin;
                BettingCoin.num += p1bet;
                p1usercoin -= p1bet;
                BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
                Player1Coin.tx_p1Coin.text = p1usercoin.ToString();
            }
            else
            {
                p1bet = 2;
                BettingCoin.num += p1bet;
                p1usercoin -= p1bet;
                BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
                Player1Coin.tx_p1Coin.text = p1usercoin.ToString();
            }
        }
        else
        {
            if (p1usercoin < 0)
            {
                p1usercoin = 0;
                Player1Coin.tx_p1Coin.text = p1usercoin.ToString();
                p1bet = 0;
            }
            else if (Player2Button.p2bet >= p1usercoin)
            {
                p1bet = p1usercoin;
                BettingCoin.num += p1bet;
                p1usercoin -= p1bet;
                BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
                Player1Coin.tx_p1Coin.text = p1usercoin.ToString();
            }
            else
            {
                p1bet = Player2Button.p2bet + 2;
                BettingCoin.num += p1bet;
                p1usercoin -= p1bet;
                BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
                Player1Coin.tx_p1Coin.text = p1usercoin.ToString();
            }
        }
        player1Disable();
    }

    public void p1Die()
    {
        p1die_state = true;
        player1Disable();

    }

    public void player1Disable()
    {
        Player1Button.btn_p1call.interactable = false;
        Player1Button.btn_p1half.interactable = false;
        Player1Button.btn_p1die.interactable = false;

        Player2Button.btn_p2call.interactable = true;
        Player2Button.btn_p2half.interactable = true;
        Player2Button.btn_p2die.interactable = true;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            try{
            stream.SendNext(p1state);

            stream.SendNext(Player1Button.btn_p1call.interactable);
            stream.SendNext(Player1Button.btn_p1half.interactable);
            stream.SendNext(Player1Button.btn_p1die.interactable);

            //stream.SendNext(Player2Button.btn_p2call.interactable);
            //stream.SendNext(Player2Button.btn_p2half.interactable);
            //stream.SendNext(Player2Button.btn_p2die.interactable);

            stream.SendNext(p1usercoin);
            stream.SendNext(Player1Coin.tx_p1Coin.text);
            stream.SendNext(p1bet);
            stream.SendNext(Player2Button.p2bet);
            stream.SendNext(BettingCoin.num);
            stream.SendNext(BettingCoin.tx_betcoin.text);
            }catch (NullReferenceException ex)
            {
                Debug.Log("");
            }
        }
        else
        {
            try{
            p1state = (bool)stream.ReceiveNext();

            Player1Button.btn_p1call.interactable = (bool)stream.ReceiveNext();
            Player1Button.btn_p1half.interactable = (bool)stream.ReceiveNext();
            Player1Button.btn_p1die.interactable = (bool)stream.ReceiveNext();

            //Player2Button.btn_p2call.interactable = (bool)stream.ReceiveNext();
            //Player2Button.btn_p2half.interactable = (bool)stream.ReceiveNext();
            //Player2Button.btn_p2die.interactable = (bool)stream.ReceiveNext();

            p1usercoin = (int)stream.ReceiveNext();
            Player1Coin.tx_p1Coin.text = (string)stream.ReceiveNext();
            p1bet = (int)stream.ReceiveNext();
            Player2Button.p2bet = (int)stream.ReceiveNext();
            BettingCoin.num = (int)stream.ReceiveNext();
            BettingCoin.tx_betcoin.text = (string)stream.ReceiveNext();
            } catch (NullReferenceException ex)
            {
                Debug.Log("");
            }
        }
    }


}