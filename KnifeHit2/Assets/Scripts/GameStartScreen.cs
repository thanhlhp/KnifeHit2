using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartScreen : ThanhMonoBehaviour
{
    [SerializeField] protected Button startBtn;

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay_scene");
        
    }
    
}
