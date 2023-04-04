using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBeam
{
    Vector3 pos, dir;
    GameObject lineObj;
    LineRenderer line;
    List<Vector3> lineIndices = new List<Vector3>();
    public  LineBeam(Vector3 pos,Vector3 dir, Material material)
    {
        this.line = new LineRenderer();
        this.lineObj = new GameObject();
        this.lineObj.name = "Line Beam";
        this.pos = pos;
        this.dir = dir;
        this.line = this.lineObj.AddComponent<LineRenderer>() as LineRenderer;
        this.line.startWidth = 0.1f;
        this.line.endWidth = 0.1f;
        this.line.material = material;
        this.line.startColor = Color.white;
        this.CastRay(pos,dir,this.line);

    }

    private void CastRay(Vector3 pos, Vector3 dir, LineRenderer line)
    {
        this.lineIndices.Add(pos);
        RaycastHit hit;
        //this.CheckHit(hit,dir,line);
    }

    private void CheckHit(RaycastHit hitinfo,Vector3 direction, LineRenderer line)
    {
        if(hitinfo.collider.gameObject.tag == "tuong" )
        {
            Vector3 pos = hitinfo.point;
            Vector3 dir = Vector3.Reflect(direction, hitinfo.normal);
            CastRay(pos, dir, line);
        }
        else
        {
            this.lineIndices.Add(hitinfo.point);
            this.UpdateLine();
        }
    }

    private void UpdateLine()
    {
        int count = 0;
        line.positionCount = this.lineIndices.Count;
        foreach(Vector3 idx in lineIndices)
        {
            line.SetPosition(count, idx);
            count++;
        }    
    }
}
