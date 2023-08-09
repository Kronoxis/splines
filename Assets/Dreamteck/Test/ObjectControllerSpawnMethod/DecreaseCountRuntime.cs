using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dreamteck.Splines.Test.ObjectControllerSpawnMethod
{
    public class DecreaseCountRuntime : MonoBehaviour
    {
        [SerializeField]
        private ObjectController controller;

        private void OnEnable()
        {
            controller.spawnCount -= 2;
            enabled = false;
        }
    }
}