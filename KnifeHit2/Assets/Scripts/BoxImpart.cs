using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxImpart : ThanhMonoBehaviour
{
    [SerializeField] protected CircleCollider2D circleColl;
    protected bool isCollinding = false;
    [SerializeField] protected BoxCollider2D boxColl;
 
    [SerializeField] protected float speedDown = 3f;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCircleColl();
        this.LoadBoxColl();
    }

    private void LoadBoxColl()
    {
        if (this.boxColl != null) return;
        this.boxColl = this.GetComponent<BoxCollider2D>();
    }

    private void LoadCircleColl()
    {
        if (this.circleColl != null) return;
        this.circleColl = this.GetComponent<CircleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "knife")
        {
            isCollinding = true;


        }
    }
}

   
