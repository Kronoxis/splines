using UnityEngine;

namespace Dreamteck.Splines.Test.SplineComputerIntersection
{
    public class VisualizeIntersection : MonoBehaviour
    {
        [SerializeField]
        private SplineComputer spline;
        [SerializeField]
        [Range(0, 1)]
        private double resolution = 1d;
        [SerializeField]
        [Range(0, 1)]
        private double from = 0d;
        [SerializeField]
        [Range(0, 1)]
        private double to = 1d;
        [SerializeField]
        private float tolerance = 0.001f;

        private void OnDrawGizmos()
        {
            if (spline == null) spline = GetComponent<SplineComputer>();
            if (spline == null) return;

            spline.IntersectAll(out Vector3[] points, out double[] percents, resolution, from, to, tolerance);

            Color point = new Color(0, 1, 0, 0.25f);
            Color center = new Color(1, 1, 0, 0.5f);
            Color percentA = new Color(1, 0, 0, 0.25f);
            Color percentB = new Color(0, 0, 1, 0.25f);
            for (int i = 0; i < points.Length; i += 2)
            {
                Gizmos.color = point;
                Gizmos.DrawSphere(points[i], 0.25f);
                Gizmos.DrawSphere(points[i + 1], 0.25f);
                Gizmos.color = center;
                Gizmos.DrawSphere((points[i] + points[i + 1]) * 0.5f, 0.5f);
                Gizmos.color = percentA;
                Gizmos.DrawSphere(spline.Evaluate(percents[i]).position, 0.125f);
                Gizmos.color = percentB;
                Gizmos.DrawSphere(spline.Evaluate(percents[i + 1]).position, 0.125f);
            }
            Gizmos.color = Color.white;
        }
    }
}