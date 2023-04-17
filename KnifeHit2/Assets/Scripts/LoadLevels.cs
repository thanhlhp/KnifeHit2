using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevels : ThanhMonoBehaviour
{
    [SerializeField] protected List<GameObject> levels;
    public List<GameObject> Levels { get => levels; }
    public GameObject level;
   

    public void SetupLv(int Level)
    {
        
        level =  Instantiate(levels[Level].gameObject,transform.position,transform.rotation);
        GamePlayManager.Instance.winscore = level.GetComponent<LevelCtrl>().winScore;
       

    }
  

}
