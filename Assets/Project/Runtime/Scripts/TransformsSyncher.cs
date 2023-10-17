using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HeroicArcade.CC.Core
{
    /*
     * It ensures that the transforms are synchronized on every update.
     */
    public class TransformsSyncher : MonoBehaviour
    {
        private void LateUpdate()
        {
            Physics.SyncTransforms();
        }
    } 
}
