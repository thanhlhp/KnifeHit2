using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Ctrl : ThanhMonoBehaviour
{
   
    [SerializeField] protected Text knifeCount;
    public Text KnifeCount { get => knifeCount; }
    
  
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadKnifeCount();
    }
    private void FixedUpdate()
    {
        KnifeCount.text = GamePlayManager.Instance.knifeNumber + "x";
    }


    private void LoadKnifeCount()
    {
        if (this.knifeCount != null) return;
        this.knifeCount = this.transform.Find("KnifeCount").GetComponent<Text>();
    }
}
