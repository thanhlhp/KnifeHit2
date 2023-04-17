using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierImpart : BoxImpart
{
    public float rotSpeed ;
    public Direction direction;
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
        if (this.gameObject.tag == "saw")
        {
            this.Rotating();
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

    private void Rotating()
    {
        Vector3 eulers = new Vector3(0, 0, -1);
        this.model.Rotate(eulers * this.rotSpeed * Time.fixedDeltaTime);
    }
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }    
}
