using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : ThanhMonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; }
    [SerializeField] protected Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos { get => mouseWorldPos; }
    //[SerializeField] protected bool onFiring;
    //public bool OnFiring { get => onFiring; }
    // Start is called before the first frame update
    protected override void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("Only 1 InputManager exist");
        InputManager.instance = this;
    }
  
    void FixedUpdate()
    {
        this.GetMousePos();
        
        
    }
    private void Update()
    {
       
    }
    protected virtual void GetMousePos()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
   
    //public virtual void GetMouseDown()
    //{
    //    if(Input.GetMouseButtonDown(0))
    //    {
    //        this.onFiring = true;
    //    }    

    //}

}
