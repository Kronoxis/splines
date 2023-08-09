using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dreamteck.Splines.Test.ObjectControllerSpawnMethod
{
    public class RemovePointRuntime : MonoBehaviour
    {
        [SerializeField]
        private SplineComputer spline;

        private void OnEnable()
        {
            var points = spline.GetPoints(SplineComputer.Space.Local);
            ArrayUtility.RemoveAt(ref points, 0);
            ArrayUtility.RemoveAt(ref points, 0);
            spline.SetPoints(points, SplineComputer.Space.Local);
            enabled = false;
        }
    }
}