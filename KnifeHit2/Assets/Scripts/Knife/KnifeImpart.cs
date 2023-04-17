using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeImpart : ThanhMonoBehaviour
{
    [SerializeField] protected KnifeCtrl knifeCtrl;
    public KnifeCtrl KnifeCtrl { get => knifeCtrl; }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadKnifeCtrl();
    }
    private void LoadKnifeCtrl()
    {
        if (this.knifeCtrl != null) return;
        this.knifeCtrl = this.transform.parent.GetComponent<KnifeCtrl>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "box")
        {
            this.transform.parent.gameObject.SetActive(false);

            Invoke(nameof(this.ResetKnifeImpart), 1);

        }
        if (collision.gameObject.tag == "saw")
        {
           knifeCtrl.KnifeMove.isKnifeDown = true;
           knifeCtrl.KnifeMove.isFlying = false;
        }
    }
    private void ResetKnifeImpart()
    {
        knifeCtrl.KnifeMove.ResetKnife();
    }
}
