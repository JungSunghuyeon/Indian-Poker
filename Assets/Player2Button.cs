using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Player2Button : MonoBehaviourPunCallbacks, IPunObservable
{
    public static Button btn_p2call, btn_p2half, btn_p2die;

    public GameObject button_p2call, button_p2half, button_p2die;

    public static int p2bet;
    public static bool p2state = false;
    public static int p2usercoin;

    void Start()
    {
        btn_p2call = GameObject.Find("btn_p2call").GetComponent<Button>();
        btn_p2half = GameObject.Find("btn_p2half").GetComponent<Button>();
        btn_p2die = GameObject.Find("btn_p2die").GetComponent<Button>();

        button_p2call = GameObject.Find("btn_p2call");
        button_p2half = GameObject.Find("btn_p2half");
        button_p2die = GameObject.Find("btn_p2die");
        
        if(PhotonNetwork.IsMasterClient){
            button_p2call.SetActive(false);
            button_p2half.SetActive(false);
            button_p2die.SetActive(false);
        }

        btn_p2call.onClick.AddListener(p2Call);
        btn_p2half.onClick.AddListener(p2Half);
        btn_p2die.onClick.AddListener(p2Die);
        p2usercoin = int.Parse(Login.coin);
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

            


        }
        else
        {
            p2state = (bool)stream.ReceiveNext();
            

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

            
        }
    }
}