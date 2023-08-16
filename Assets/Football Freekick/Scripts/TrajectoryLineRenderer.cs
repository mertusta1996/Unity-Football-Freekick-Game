using System.Collections.Generic;
using UnityEngine;

public class TrajectoryLineRenderer : MonoBehaviour
{
    public LineRenderer trajectoryLine;
    public int totalBezierPointsCount = 25;
    public int renderingBezierPointsCount = 14;

    public void CreateTrajectoryLine(Transform p1, Transform p2, Transform p3)
    {
        var pointList = new List<Vector3>();

        for (float i = 0; i < totalBezierPointsCount; i++)
        {
            var t1 = Vector3.Lerp(p1.position, p2.position, i / totalBezierPointsCount);
            var t2 = Vector3.Lerp(p2.position, p3.position, i / totalBezierPointsCount);
            var curve = Vector3.Lerp(t1, t2, i / totalBezierPointsCount);

            if (i < renderingBezierPointsCount)
            {
                pointList.Add(curve);
            }
        }

        trajectoryLine.positionCount = pointList.Count;
        trajectoryLine.SetPositions(pointList.ToArray());
    }
}
