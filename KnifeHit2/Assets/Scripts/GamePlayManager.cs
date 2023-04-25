using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : ThanhMonoBehaviour
{
    protected static GamePlayManager instance;
    public static GamePlayManager Instance { get => instance; }
    public GameOverScreen gameOverScreen;
    public GameWinScreen gameWinScreen;
    public LoadLevels loadLevel;
    public int knifeNumber = 5;
    public int level = 0;
    public int score = 0;
    public int winscore = -1;
    public bool isPlaying = false;
    public bool isFlyingKnife = false;
    protected override void Awake()
    {
        base.Awake();
        GamePlayManager.instance = this;

    }
    private void Update()
    {
        
        Debug.Log(level);
        if (knifeNumber == 0 && score<winscore)
        {
            gameOverScreen.Setup();
        }

        if (score == winscore)
        {
            if (level <1)
            {
                isPlaying = false;
                gameWinScreen.Setup();
            }
            else gameOverScreen.Setup();
            //level++;
        }
    }
    private void Start()
    {
        loadLevel.SetupLv(level);
        isPlaying = true;
    }
    public void NextLevel()
    {
        loadLevel.SetupLv(level);
        GamePlayManager.Instance.isPlaying = true;
    }
    public void EndLevel()
        {
       
            knifeNumber = 5;
            level++;
            score = 0;
            Destroy(this.loadLevel.level);
            Invoke(nameof(NextLevel), 0.25f);
        }
        
    
}
