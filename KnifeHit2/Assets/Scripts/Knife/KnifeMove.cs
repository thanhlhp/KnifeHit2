using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class KnifeMove : ThanhMonoBehaviour
{
    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected float speedFly = 9f;
    protected Vector3 directionFly = Vector3.up;
    [SerializeField] protected bool isFlying = false;
    [SerializeField] protected Rigidbody2D knifeRb;
    [SerializeField] protected CircleCollider2D knifeColl;
    [SerializeField] protected KnifeCtrl knifeCtrl;
    public KnifeCtrl KnifeCtrl { get => knifeCtrl; }
    protected Vector3 lastVelocity;
    protected Vector3 posBeforeFly;
    [SerializeField]protected TrailRenderer dashLine;
    protected KnifeShootLine knifeLine;
    public bool isMouseDown = false;
    protected int countColl = 0;
    private bool isKnifeDown = false;
    public bool IsKnifeDown { get => isKnifeDown; }

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
        this.LoadDashLine();
    }
    private void LoadDashLine()
    {
        if (this.dashLine != null) return;
        this.dashLine = this.GetComponent<TrailRenderer>();
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
        this.knifeColl = this.GetComponent<CircleCollider2D>();
    }
    private void FixedUpdate()
    {
        if (isFlying == false)
        {
            if (isMouseDown)
            {
                this.GetTargetPos();
                this.RotateLaze();
                directionFly = (this.targetPos - this.transform.parent.position);
                this.knifeCtrl.KnifeShootLine.line.gameObject.SetActive(true);
            }
            if(isKnifeDown)
            {
                dashLine.emitting = false;
                StartCoroutine(this.KnifeDown());
                
            }    
            
        }

        if (isFlying == true)
        {
        
            dashLine.emitting = true;
            this.transform.parent.Translate(directionFly.normalized * speedFly * Time.deltaTime);
            this.knifeCtrl.KnifeShootLine.line.gameObject.SetActive(false);
        } 
    }
   
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            
            isFlying = true;
            isMouseDown = false;
        }
        if(Input.GetAxis("Fire1") == 1)
        {
            isMouseDown = true;
        }
           
       
    }
  

    private void GetTargetPos()
    {
        if (InputManager.Instance.MouseWorldPos.y >= this.transform.parent.position.y + 0.5f)
        {
            this.targetPos = InputManager.Instance.MouseWorldPos;
            this.targetPos.z = 0;
        }
    }
    private void RotateLaze()
    {
        
        var posLaze = this.knifeCtrl.KnifeShootLine.transform.position;
        Vector3 diff = this.targetPos - posLaze;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        this.knifeCtrl.KnifeShootLine.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
        if ( collision.gameObject.CompareTag("tuong"))
        {
            countColl++;
            if (countColl < 4)
            {
                Vector3 diff = transform.parent.position - this.posBeforeFly;
                this.directionFly = Vector3.Reflect(diff.normalized, collision.contacts[0].normal);
                this.posBeforeFly = transform.parent.position;
                
                
            }
            else
            {
                Invoke(nameof(this.DestroyKnife), 0.5f);
                Invoke("ResetKnife", 1f);
                this.knifeColl.isTrigger = true;
            }
        }
        if (collision.gameObject.tag == "ground")
            {
                this.knifeColl.isTrigger = true;
                Invoke(nameof(this.DestroyKnife), 0.5f);
                Invoke("ResetKnife", 1f);

        }
       


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "box")
        {
            this.transform.parent.gameObject.SetActive(false);
            Invoke("ResetKnife", 1);
        }
        if(collision.gameObject.tag == "saw")
        {
            isKnifeDown = true;
            isFlying = false;
        }    
    }
    private void ResetKnife()
    {
        this.knifeColl.isTrigger = false;
        this.transform.parent.position = this.knifeCtrl.pos;
        this.transform.position = this.knifeCtrl.pos;
        posBeforeFly = this.knifeCtrl.pos;
        this.countColl = 0;
        this.knifeCtrl.KnifeShootLine.transform.position = new Vector3(0f, this.knifeCtrl.pos.y, 0f);
        isFlying = false;
        this.transform.parent.gameObject.SetActive(true);
        isKnifeDown = false;
        GamePlayManager.Instance.knifeNumber--;

    }
    private void DestroyKnife()
    {
        this.transform.parent.gameObject.SetActive(false);
    }
    private IEnumerator KnifeDown()
    {
        this.transform.parent.Translate(Vector3.down * 6f * Time.deltaTime);
        yield return new WaitForSeconds(2);
        this.ResetKnife();
    }

}
