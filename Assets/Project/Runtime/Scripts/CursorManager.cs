using UnityEngine;

namespace HeroicArcade.CC.Core
{
    public class CursorManager : MonoBehaviour
    {
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
