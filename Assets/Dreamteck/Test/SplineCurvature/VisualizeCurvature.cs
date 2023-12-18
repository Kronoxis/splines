using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class VisualizeCurvature : MonoBehaviour
{
    [Header("Samples")]
    public bool CustomSamples = true;
    [Range(4, 1000)]
    public int Samples = 20;

    [Header("Tangents")]
    public bool DrawTangents = true;
    [Range(0, 2)]
    public float TangentScale = 1f;

    [Header("Curvature")]
    public bool DrawCurvature = true;
    public bool ConnectCurvature = true;
    [Range(0, 2)]
    public float CurvatureScale = 1f;
    private Vector3 lastCurvature;

    private void OnDrawGizmosSelected()
    {
        SplineComputer spline = GetComponent<SplineComputer>();
        SplineSample sample = spline.Evaluate(0d);
        lastCurvature = GetCurvature(spline, sample, (GetTangent(spline, sample, 0d) - sample.position).normalized, 0d);

        SplineSample[] samples = spline.rawSamples;
        int count = CustomSamples ? Samples : samples.Length;
        double step = 1d / (count - 1);
        for (int i = 1; i < count; ++i)
        {
            double percent = CustomSamples ? step * i : samples[i].percent;
            sample = CustomSamples ? spline.Evaluate(percent) : samples[i];

            Vector3 tangent = GetTangent(spline, sample, percent);
            Gizmos.color = Color.yellow;
            if (DrawTangents) Gizmos.DrawLine(sample.position, tangent);

            Vector3 curvature = GetCurvature(spline, sample, (tangent - sample.position).normalized, percent);
            Gizmos.color = Color.cyan;
            if (DrawCurvature) Gizmos.DrawLine(lastCurvature, curvature);
            Gizmos.color = new Color(1, 1, 1, 0.125f);
            if (ConnectCurvature) Gizmos.DrawLine(sample.position, curvature);
            lastCurvature = curvature;
        }
    }

    private Vector3 GetTangent(SplineComputer spline, SplineSample sample, double percent)
    {
        Vector3 tangent = spline.EvaluateTangent(percent);
        Quaternion quat = Quaternion.AngleAxis(-90, sample.right);
        return sample.position + quat * (tangent * TangentScale);
    }

    private Vector3 GetCurvature(SplineComputer spline, SplineSample sample, Vector3 up, double percent)
    {
        float curvature = spline.EvaluateCurvature(percent);
        return sample.position + up * curvature * CurvatureScale;
    }
}
