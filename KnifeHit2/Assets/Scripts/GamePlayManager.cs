using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : ThanhMonoBehaviour
{
    protected static GamePlayManager instance;
    public static GamePlayManager Instance { get => instance; }
    public GameOverScreen gameOverScreen;
    public int knifeNumber = 3;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    private void FixedUpdate()
    {
        if (knifeNumber == 0)
        {
            gameOverScreen.Setup();
        }    
    }
}
