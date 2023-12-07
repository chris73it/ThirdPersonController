using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.UI;

namespace HeroicArcade.CC.UI
{
    public class AvatarHealthBarController : MonoBehaviour
    {
        [SerializeField] Image avatarBarImage;
        [SerializeField] FloatReference avatarCurrentEnergy = null;
        [SerializeField] FloatReference avatarMaxEnergy = null;

        void Awake()
        {
            avatarCurrentEnergy.Value = avatarMaxEnergy.Value;
        }

        public void UpdateEnergy()
        {
            if (avatarBarImage.fillAmount != avatarCurrentEnergy.Value / avatarMaxEnergy.Value)
            {
                avatarBarImage.fillAmount = avatarCurrentEnergy.Value / avatarMaxEnergy.Value;
            }
        }
    }
}
