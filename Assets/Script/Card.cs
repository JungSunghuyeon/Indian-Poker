using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Card : MonoBehaviour
{
    
   public Stack<int> list = new Stack<int>();       //카드 스택
    public int []num = {1,1,2,2,3,3,4,4,5,5,6,6,7,7,8,8,9,9,10,10};
    public void create() {

        num = ShuffleArray(num);                //배열 셔플
        
        for(int i = 0; i < num.Length; i++){    //셔플한 배열의 원소를 카드리스트에 push
            list.Push(num[i]);
        }
        
    }

    //셔플 함수
   public T[] ShuffleArray<T>(T[] array){
       int random1, random2;
        T temp;
        for (int i = 0; i < array.Length; ++i)
        {
            random1 = Random.Range(0, array.Length);
            random2 = Random.Range(0, array.Length);

            temp = array[random1];
            array[random1] = array[random2];
            array[random2] = temp;
        }
        return array;
   }
   
   //카드리스트의 원소를 pop하여 카드 한장씩 받음
  public int deal(){
      return list.Pop();
  }

}
