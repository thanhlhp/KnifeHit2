using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitImpart : ThanhMonoBehaviour
{
    [SerializeField] protected CircleCollider2D fruitColl;
    protected bool isDestroy = false;
    [SerializeField] protected float speedDown = 3f;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadFruitColl();
    }
    private void FixedUpdate()
    {
        if(isDestroy)
        {
            this.DestroyKnife();
        }    
    }
    private void LoadFruitColl()
    {
        if (this.fruitColl != null) return;
        this.fruitColl = this.GetComponent<CircleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "knife")
        {
            isDestroy = true;
            Debug.Log(isDestroy);
        }    
    }

    private void DestroyKnife()
    {
        Vector3 knifePos = transform.parent.position;
        transform.parent.position = new Vector3(knifePos.x, knifePos.y - speedDown*Time.fixedDeltaTime, knifePos.z);
    }
    IEnumerator fruitFly()
    {

        yield return 0;
    }
}
