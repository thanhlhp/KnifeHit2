using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsImpart : BoxImpart
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
        if(isCollinding)
        {
            StartCoroutine(CollProcess());
        }
    }
    private IEnumerator CollProcess()
    {
        Transform viTriLy = InputManager.Instance.Ly;
        this.transform.parent.position = Vector3.MoveTowards(transform.parent.position, viTriLy.position, speedDown * Time.fixedDeltaTime);
        yield return new WaitForSeconds(1);
        Destroy(this.transform.parent.gameObject);

    }
}

