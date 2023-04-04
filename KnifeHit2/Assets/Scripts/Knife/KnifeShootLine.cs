using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeShootLine : ThanhMonoBehaviour
{
    public LineRenderer line;
    public int reflections;
    public float maxRayDistance;
    public LayerMask layerDetection;
    [SerializeField] protected KnifeCtrl knifeCtrl;
    public KnifeCtrl KnifeCtrl { get => knifeCtrl; }

    private void Start()
    {
     

    }

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
    private void Update()
    {
        if (this.KnifeCtrl.KnifeMove.isMouseDown == true)
            Physics2D.queriesStartInColliders = false;
        else Physics2D.queriesStartInColliders = true;
        line.positionCount = 1;
        line.SetPosition(0, transform.position);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.parent.position, transform.parent.up, maxRayDistance, layerDetection);
        // Ray
        Ray2D ray = new Ray2D(transform.parent.position, transform.parent.up);

        bool isMirror = false;
        Vector2 mirrorHitPoint = Vector2.zero;
        Vector2 mirrorHitNormal = Vector2.zero;


        for (int i = 0; i < reflections; i++)
        {
            line.positionCount += 1;

            if (hitInfo.collider != null)
            {
                line.SetPosition(line.positionCount - 1, hitInfo.point - ray.direction * -0.1f);

                isMirror = false;
                if (hitInfo.collider.CompareTag("tuong"))
                {
                    mirrorHitPoint = hitInfo.point - new Vector2(transform.parent.position.x,transform.parent.position.y);
                    mirrorHitNormal = (Vector2)hitInfo.normal;
                    hitInfo = Physics2D.Raycast((Vector2)hitInfo.point - ray.direction * -0.1f, Vector2.Reflect(mirrorHitPoint, hitInfo.normal), maxRayDistance, layerDetection);
                    isMirror = true;
                }
                else
                    break;
            }
            else
            {
                if (isMirror)
                {
                    line.SetPosition(line.positionCount - 1, Vector2.Reflect(mirrorHitPoint, mirrorHitNormal) * maxRayDistance);
                    break;
                }
                else
                {
                    line.SetPosition(line.positionCount - 1, transform.parent.position + transform.parent.up * maxRayDistance);
                    break;
                }
            }

        }
    }
}
