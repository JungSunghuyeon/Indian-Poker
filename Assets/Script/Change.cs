using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Change : MonoBehaviour
{
    // 화면 전환
      public void GameStartChange(){        //게임방 화면 이동
        SceneManager.LoadScene("GameBoard");
    }

    public void RankChange(){                  //랭킹 화면 이동
        SceneManager.LoadScene("Rank");
    }

    public void OptionChange(){                //옵션 화면 이동
        SceneManager.LoadScene("Option");
    }

    public void MainChange(){                   //메인 화면 이동
        SceneManager.LoadScene("Lobby");
    }

   public void LoginChange(){                   //로그인 화면 이동
        SceneManager.LoadScene("Login");
    }

    public void SignUpChange(){                 //회원가입 화면 이동
        SceneManager.LoadScene("SignUp");
    }
}
