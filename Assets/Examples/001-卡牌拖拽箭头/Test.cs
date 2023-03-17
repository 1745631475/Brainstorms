using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform[] Pos;


    [ContextMenu("生成贝塞尔曲线")]
    public void GenerateBezierCurve()
    {
        List<Vector3> vector3s = Pos.Select(value => value.position).ToList();
        List<Vector2> vector2s = new List<Vector2>();
        for (int i = 0; i < vector3s.Count; i++)
        {
            vector2s.Add(new Vector2(vector3s[i].x, vector3s[i].y));
        }
        List<Vector2> targetPos = BezierCurveTool.CreateBezierCurve(vector2s.ToArray(), 20);
        for (int i = 0; i < targetPos.Count; i++)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            obj.name = i.ToString();
            obj.transform.position = targetPos[i];
        }
    }
}
