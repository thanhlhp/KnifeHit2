using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWinScreen : ThanhMonoBehaviour
{
    [SerializeField] protected Button nextBtn;
    public void Setup()
    {
        gameObject.SetActive(true);
    }
    public void NextLv()
    {
        gameObject.SetActive(false);
        GamePlayManager.Instance.knifeNumber = 3;
     
        GamePlayManager.Instance.EndLevel();
    }
}
