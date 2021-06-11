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
    public static int p2usercoin;

    void Start()
    {
        btn_p2call = GameObject.Find("btn_p2call").GetComponent<Button>();
        btn_p2half = GameObject.Find("btn_p2half").GetComponent<Button>();
        btn_p2die = GameObject.Find("btn_p2die").GetComponent<Button>();

        btn_p2call.onClick.AddListener(p2Call);
        btn_p2call.onClick.AddListener(result);

        btn_p2half.onClick.AddListener(p2Half);
        btn_p2die.onClick.AddListener(p2Die);
        p2usercoin = int.Parse(Login.coin);
    }

    public void result()
    {
        if (Player1Button.p1state == true && Player2Button.p2state == true)
        {
            Debug.Log(P1CardNumber.p1Num);
            Debug.Log(P2CardNumber.p2Num);
            if (P1CardNumber.p1Num > P2CardNumber.p2Num)
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
        }
    }

    public void p2Call()
    {
        if (BettingCoin.num == 0)
        {
            if (p2usercoin < 0)
            {
                p2usercoin = 0;
                Player2Coin.tx_p2Coin.text = p2usercoin.ToString();
                p2bet = 0;
            }
            else if (p2bet >= p2usercoin)
            {
                p2bet = p2usercoin;
                BettingCoin.num += p2bet;
                p2usercoin -= p2bet;
                BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
                Player2Coin.tx_p2Coin.text = p2usercoin.ToString();
            }
            else
            {
                p2bet = 1;
                BettingCoin.num += p2bet;
                p2usercoin -= p2bet;
                BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
                Player2Coin.tx_p2Coin.text = p2usercoin.ToString();
            }
        }
        else
        {
            if (p2usercoin < 0)
            {
                p2usercoin = 0;
                Player2Coin.tx_p2Coin.text = p2usercoin.ToString();
                p2bet = 0;
            }
            else if (p2bet >= p2usercoin)
            {
                p2bet = p2usercoin;
                p2usercoin -= p2bet;
                BettingCoin.num += p2bet;
                BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
                Player2Coin.tx_p2Coin.text = p2usercoin.ToString();
            }
            else
            {
                p2bet = Player1Button.p1bet;
                BettingCoin.num += p2bet;
                p2usercoin -= p2bet;
                BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
                Player2Coin.tx_p2Coin.text = p2usercoin.ToString();
            }
        }
        p2state = true;
        player2Disable();

    }


    public void p2Half()
    {
        if (BettingCoin.num == 0)
        {
            if (p2usercoin < 0)
            {
                p2usercoin = 0;
                Player2Coin.tx_p2Coin.text = p2usercoin.ToString();
                p2bet = 0;
            }
            else if (p2bet >= p2usercoin)
            {
                p2bet = p2usercoin;
                BettingCoin.num += p2bet;
                p2usercoin -= p2bet;
                BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
                Player2Coin.tx_p2Coin.text = p2usercoin.ToString();
            }
            else
            {
                p2bet = 2;
                BettingCoin.num += p2bet;
                p2usercoin -= p2bet;
                BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
                Player2Coin.tx_p2Coin.text = p2usercoin.ToString();
            }
        }
        else
        {
            if (p2usercoin < 0)
            {
                p2usercoin = 0;
                Player2Coin.tx_p2Coin.text = p2usercoin.ToString();
                p2bet = 0;
            }
            else if (Player1Button.p1bet >= p2usercoin)
            {
                p2bet = p2usercoin;
                BettingCoin.num += p2bet;
                p2usercoin -= p2bet;
                BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
                Player2Coin.tx_p2Coin.text = p2usercoin.ToString();
            }
            else
            {
                p2bet = Player1Button.p1bet + 2;
                BettingCoin.num += p2bet;
                p2usercoin -= p2bet;
                BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
                Player2Coin.tx_p2Coin.text = p2usercoin.ToString();
            }
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

    public void player2Disable()
    {
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
            stream.SendNext(p2state);
             stream.SendNext(Player1Button.p1state);

            stream.SendNext(Player1Button.btn_p1call.interactable);
            stream.SendNext(Player1Button.btn_p1half.interactable);
            stream.SendNext(Player1Button.btn_p1die.interactable);

            stream.SendNext(btn_p2call.interactable);
            stream.SendNext(btn_p2half.interactable);
            stream.SendNext(btn_p2die.interactable);

            stream.SendNext(p2usercoin);
            stream.SendNext(Player2Coin.tx_p2Coin.text);


            stream.SendNext(Player1Button.p1bet);
            stream.SendNext(p2bet);
            stream.SendNext(BettingCoin.num);

            stream.SendNext(BettingCoin.tx_betcoin.text);

            

            stream.SendNext(P1CardNumber.p1Num);
            stream.SendNext(P2CardNumber.p2Num);
            stream.SendNext(Player1Name.p1Name);
            stream.SendNext(Player2Name.p2Name);
            stream.SendNext(Result.tx_result.text);

        }
        else
        {
            p2state = (bool)stream.ReceiveNext();
            Player1Button.p1state = (bool)stream.ReceiveNext();

            Player1Button.btn_p1call.interactable = (bool)stream.ReceiveNext();
            Player1Button.btn_p1half.interactable = (bool)stream.ReceiveNext();
            Player1Button.btn_p1die.interactable = (bool)stream.ReceiveNext();

            btn_p2call.interactable = (bool)stream.ReceiveNext();
            btn_p2half.interactable = (bool)stream.ReceiveNext();
            btn_p2die.interactable = (bool)stream.ReceiveNext();

            p2usercoin = (int)stream.ReceiveNext();
            Player2Coin.tx_p2Coin.text = (string)stream.ReceiveNext();


            Player1Button.p1bet = (int)stream.ReceiveNext();
            p2bet = (int)stream.ReceiveNext();

            BettingCoin.num = (int)stream.ReceiveNext();

            BettingCoin.tx_betcoin.text = (string)stream.ReceiveNext();

            

            P1CardNumber.p1Num = (int)stream.ReceiveNext();
            P2CardNumber.p2Num = (int)stream.ReceiveNext();
            Player1Name.p1Name = (string)stream.ReceiveNext();
            Player2Name.p2Name = (string)stream.ReceiveNext();
            Result.tx_result.text = (string)stream.ReceiveNext();

        }
    }
}