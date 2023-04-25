using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Ctrl : ThanhMonoBehaviour
{
   
    [SerializeField] protected Text knifeCount;
    public Text KnifeCount { get => knifeCount; }
    [SerializeField] protected Text score;
    public Text Score { get => score; }
    [SerializeField] protected Text winscore;
    public Text Winscore { get => winscore; }


    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadKnifeCount();
    }
    private void Update()
    {
        KnifeCount.text = GamePlayManager.Instance.knifeNumber + "x";
        Score.text = GamePlayManager.Instance.score + "";
        Winscore.text = GamePlayManager.Instance.winscore + "";
    }


    private void LoadKnifeCount()
    {
        if (this.knifeCount != null) return;
        this.knifeCount = this.transform.Find("KnifeCount").GetComponent<Text>();
    }
}
