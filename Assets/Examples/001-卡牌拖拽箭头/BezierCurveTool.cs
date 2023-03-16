using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BezierCurveTool
{
    private List<Vector2> RecurveBezierCurve(float t, Vector2[] controlPos)
    {
        float u = 1 - t;
        List<Vector2> newControlPos = new List<Vector2>();
        for (int i = 0; i < controlPos.Length - 1; i++)
        {
            Vector2 pos = u * controlPos[i] + t * controlPos[i + 1];
            newControlPos.Add(pos);
        }
        if (newControlPos.Count > 1)
            newControlPos = RecurveBezierCurve(t, newControlPos.ToArray());
        return newControlPos;
    }

    public Vector2 BezierCurve(float t, Vector2[] controlPos)
    {
        return RecurveBezierCurve(t, controlPos)[0];
    }

    public List<Vector2> CreateBezierCurve(Vector2[] controlPos, uint stepNum)
    {
        List<Vector2> CurvePointList = new List<Vector2>();
        for (uint i = stepNum; i > 0; i--)
        {
            float t = (float)i / stepNum;
            Vector2 Point = BezierCurve(t, controlPos);
            CurvePointList.Add(Point);
        }
        return CurvePointList;
    }
}
