using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierImpart : BoxImpart
{
    protected override void Awake()
    {
        base.Awake();
        this.ResetValue();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.speedDown = 10;
    }
    private void FixedUpdate()
    {
        if (isCollinding)
        {
            StartCoroutine(CollProcess());
        }
    }
    private IEnumerator CollProcess()
    {
        if (this.gameObject.tag == "box")
        {
            Destroy(this.transform.parent.gameObject);
        }
        yield return new WaitForSeconds(1);
    }
}
