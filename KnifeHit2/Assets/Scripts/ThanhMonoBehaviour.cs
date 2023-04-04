using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThanhMonoBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponent();
        this.ResetValue();
    }
    protected virtual void Awake()
    {
        this.LoadComponent();
    }
    protected virtual void LoadComponent()
    {

    }
    protected virtual void ResetValue()
    {

    }
    protected virtual void OnEnable()
    {

    }
}
