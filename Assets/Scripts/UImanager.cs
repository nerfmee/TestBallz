using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public Text RoundsText;
    public Text BallCountText;
    
    public  void ChangeRounds()
    {
        int ballsCount = BallLauncher.ballsReady + 1;
        
        BallCountText.text = ballsCount.ToString();
        PlayerPrefs.Rounds++;
       
        
        RoundsText.text = "Rounds: " + PlayerPrefs.Rounds.ToString();
    }
}
