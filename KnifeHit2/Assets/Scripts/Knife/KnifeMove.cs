using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class KnifeMove : ThanhMonoBehaviour
{
    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected float speedFly = 15f;
    protected Vector3 directionFly = Vector3.up;
    [SerializeField] protected bool isFlying = false;
    [SerializeField] protected Rigidbody2D knifeRb;
    [SerializeField] protected BoxCollider2D knifeColl;
    [SerializeField] protected KnifeCtrl knifeCtrl;
    public KnifeCtrl KnifeCtrl { get => knifeCtrl; }
    protected Vector3 lastVelocity;
    protected Vector3 posBeforeFly;
    KnifeShootLine knifeLine;
    public bool isMouseDown = false;
    protected int countColl = 0;
    protected override void Awake()
    {
        base.Awake();
        this.posBeforeFly = transform.position;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadKnifeRb();
        this.LoadKnifeCollider();
        this.LoadKnifeCtrl(); 
    }

    private void LoadKnifeCtrl()
    {
        if (this.knifeCtrl != null) return;
        this.knifeCtrl = this.transform.parent.GetComponent<KnifeCtrl>();
    }

    private void LoadKnifeRb()
    {
        if (this.knifeRb != null) return;
        this.knifeRb = this.GetComponent<Rigidbody2D>();
    }
    private void LoadKnifeCollider()
    {
        if (this.knifeColl != null) return;
        this.knifeColl = this.GetComponent<BoxCollider2D>();
    }
    private void FixedUpdate()
    {
        if (isFlying == false )
        {
            if(isMouseDown)
            {
                this.GetTargetPos();
                this.RotateKnife();
            }    
            
           
        }
     
        if (isFlying == true)
        {
            transform.parent.Translate(directionFly * speedFly * Time.fixedDeltaTime);
            this.knifeCtrl.KnifeShootLine.line.gameObject.SetActive(false);
        }
      
    }
   
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            
            isFlying = true;
        }
        if(Input.GetAxis("Fire1") == 1)
        {
            isMouseDown = true;
        }    
       
    }

    private void GetTargetPos()
    {
        this.targetPos = InputManager.Instance.MouseWorldPos;
        this.targetPos.z = 0;
    }
    private void RotateKnife()
    {
        if (this.targetPos.y <= transform.parent.position.y) return;
      
     
        Vector3 diff = this.targetPos - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        this.transform.parent.rotation =  Quaternion.Euler(0f, 0f, rot_z-90);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        countColl++;
        if(countColl<4)
        {
            Vector3 diff = transform.position - this.posBeforeFly;
            var direction = Vector3.Reflect(diff.normalized, collision.contacts[0].normal);
            float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            Debug.Log(diff.normalized);
            this.posBeforeFly = transform.position;
        }else
        {
            Invoke("ResetKnife", 2);
        }    
      
        
    }
    private void ResetKnife()
    {
        Destroy(this.transform.parent.gameObject);
    }

}
