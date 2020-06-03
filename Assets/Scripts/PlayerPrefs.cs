using UnityEngine;

public class PlayerPrefs : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;
    public int rounds;
    public static int KillStat = 0;

    public static int BallsReady;
    public int ballsReady;

    void Start ()
    {
        BallsReady = ballsReady;
        Money = startMoney;
        Lives = startLives;

        Rounds = 1;
    }
}