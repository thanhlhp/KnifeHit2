using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : ThanhMonoBehaviour
{
   [SerializeField] protected Button resetBtn;
   public void Setup()
    {
        gameObject.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Gameplay_scene");
    }    
}
