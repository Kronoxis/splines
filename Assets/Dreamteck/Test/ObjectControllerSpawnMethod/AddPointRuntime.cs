using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dreamteck.Splines.Test.ObjectControllerSpawnMethod
{
    public class AddPointRuntime : MonoBehaviour
    {
        [SerializeField]
        private SplineComputer spline;

        private void OnEnable()
        {
            var points = spline.GetPoints(SplineComputer.Space.Local);
            ArrayUtility.Add(ref points, new SplinePoint(points[^1]));
            points[^1].SetPositionZ(points[^1].position.z + 1);
            ArrayUtility.Add(ref points, new SplinePoint(points[^1]));
            points[^1].SetPositionZ(points[^1].position.z + 1);
            spline.SetPoints(points, SplineComputer.Space.Local);
            enabled = false;
        }
    }
}