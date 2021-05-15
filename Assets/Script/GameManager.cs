using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button btn_p1call, btn_p1half, btn_p1die, btn_p2call, btn_p2half, btn_p2die;

    public Text tx_betcoin;         //누적 배팅된 코인 텍스트
    public Text tx_p1Bet, tx_p2Bet; //각 플레이어가 배팅한 개수 텍스트
    public Text tx_result;          //승패 결정 결과 텍스트
    public Text tx_p1num, tx_p2num;


    public static int num = 0;      //누적 배팅된 코인
    public int p1Bet, p2Bet;        //각 플레이어가 배팅한 개수
    public int Cnt = 0;              //배팅한 횟수 
    public int p1Cnt = 0, p2Cnt = 0;    //각 플레이어가 call 누를시 flag 1

    public int p1betSum, p2betSum;  //무승부가 날 경우 배팅한 코인을 다시 돌려받기위함
    
    Card_Get1 card_get1 = new Card_Get1();
    Card_Get2 card_get2 = new Card_Get2();
   public void Start(){
       Firstturn();
        Debug.Log(card_get2.txt_card_transport());
        Debug.Log(card_get1.txt_card_transport());
   }
   public void result(){
       if((p1Cnt == 1) && (p2Cnt == 1)){
           tx_result.text = "확인";
           Disable();
       }
   }
   public void p1call(){
       if(Cnt == 0){        //첫턴일시
           p1Bet = 1;      //1개 배팅 가능
           p1betSum += p1Bet; //배팅한 코인을 누적 배팅개수에 담기
           tx_p1Bet.text = p1Bet.ToString();    
           num += p1Bet;                        
           tx_betcoin.text = num.ToString();  //배팅된 코인 텍스트 출력
       }
       else{
           p1Bet = p2Bet;               //상대방이 배팅한 같은 개수만큼 배팅
           p1betSum += p1Bet; //배팅한 코인을 누적 배팅개수에 담기
           tx_p1Bet.text = p1Bet.ToString(); 
           num += p1Bet;
           tx_betcoin.text = num.ToString();
       }
       p1Cnt = 1;                   //call flag 1 (서로 1이면 결과함수 실행)
       Cnt++;
       p1Disable();
   }
   public void p1half(){
       if(Cnt == 0){
           p1Bet = 2;
           p1betSum += p1Bet; //배팅한 코인을 누적 배팅개수에 담기
           tx_p1Bet.text = p1Bet.ToString();
           num += p1Bet;
           tx_betcoin.text = num.ToString();

       }
       else{
           p1Bet = p2Bet + 2;               //상대방이 배팅한 개수보다 2개 더 큰 개수의 코인 배팅
           p1betSum += p1Bet; //배팅한 코인을 누적 배팅개수에 담기
           tx_p1Bet.text = p1Bet.ToString();
           num += p1Bet;
           tx_betcoin.text = num.ToString();
       }
       Cnt++;
       p1Disable();
   }
   public void p1die(){
       p1Disable();
   }
   public void p2call(){
       if(Cnt == 0){
           p2Bet = 1;
           p2betSum += p2Bet; //배팅한 코인을 누적 배팅개수에 담기
           tx_p2Bet.text = p2Bet.ToString();
           num += p2Bet;
           tx_betcoin.text = num.ToString();
       }
       else{
           p2Bet = p1Bet;
           p2betSum += p2Bet; //배팅한 코인을 누적 배팅개수에 담기
           tx_p2Bet.text = p2Bet.ToString();
           num += p2Bet;
           tx_betcoin.text = num.ToString();
       }
       p2Cnt = 1;
       Cnt++;
       p2Disable();
   }
   public void p2half(){
       if(Cnt == 0){
           p2Bet = 2;
           p2betSum += p2Bet; //배팅한 코인을 누적 배팅개수에 담기
           tx_p2Bet.text = p2Bet.ToString();
           num += p2Bet;
           tx_betcoin.text = num.ToString();
       }
       else{
           p2Bet = p1Bet + 2;
           p2betSum += p2Bet; //배팅한 코인을 누적 배팅개수에 담기
           tx_p2Bet.text = p2Bet.ToString();
           num += p2Bet;
           tx_betcoin.text = num.ToString();
       }
       Cnt++;
       p2Disable();
   }
   public void p2die(){
       p2Disable();
   }

   public void p1Disable(){             //플레이어1 버튼 비활성화, 플레이어2 버튼 활성화
       btn_p1call.interactable = false;
       btn_p1half.interactable = false;
       btn_p1die.interactable = false;

       btn_p2call.interactable = true;
       btn_p2half.interactable = true;
       btn_p2die.interactable = true;
   }
   public void p2Disable(){            //플레이어2 버튼 비활성화, 플레이어1 버튼 활성화
       btn_p2call.interactable = false;
       btn_p2half.interactable = false;
       btn_p2die.interactable = false;

       btn_p1call.interactable = true;
       btn_p1half.interactable = true;
       btn_p1die.interactable = true;

   }

   public void Disable(){               //버튼 모두 비활성화
       btn_p1call.interactable = false;
       btn_p1half.interactable = false;
       btn_p1die.interactable = false;

       btn_p2call.interactable = false;
       btn_p2half.interactable = false;
       btn_p2die.interactable = false;
   }

   public void Firstturn(){        //첫 턴 
        int t = Random.Range(1,3);
        if(t == 1){                             //플레이어 1이 첫 번째 턴
            btn_p1call.interactable = true;
            btn_p1half.interactable = true;
            btn_p1die.interactable = true;
        }
        else if(t == 2){                        //플레이어 2가 첫 번째 턴
            btn_p2call.interactable = true;
            btn_p2half.interactable = true;
            btn_p2die.interactable = true;
        }
    }

}
