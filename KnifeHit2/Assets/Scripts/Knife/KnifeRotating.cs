using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeRotating : ThanhMonoBehaviour
{
    [SerializeField] protected float rotSpeed;
    [SerializeField] protected KnifeCtrl knifeCtrl;
    public KnifeCtrl KnifeCtrl { get => knifeCtrl; }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadKnifeCtrl();
    }
    private void FixedUpdate()
    {
        this.Rotating();
    }

    private void Rotating()
    {
        Vector3 eulers = new Vector3(0, 0,-1);
        this.knifeCtrl.model.Rotate(eulers * this.rotSpeed * Time.fixedDeltaTime);
    }

    private void LoadKnifeCtrl()
    {
        if (this.knifeCtrl != null) return;
        this.knifeCtrl = this.transform.parent.GetComponent<KnifeCtrl>();
    }
}
