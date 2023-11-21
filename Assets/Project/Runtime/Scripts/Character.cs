using MenteBacata.ScivoloCharacterController;
using UnityEngine;

namespace HeroicArcade.CC.Core
{
    public class Character : MonoBehaviour
    {
        [SerializeField] InputController inputController;
        public InputController InputController { get => inputController; }

        [SerializeField] Animator animator;
        public Animator Animator { get => animator; }

        [Header("Character Parameters")]
        [SerializeField] CameraStyle camStyle;
        public CameraStyle CamStyle { get => camStyle; set => camStyle = value; }
        [SerializeField] float maxWalkSpeed; //6
        public float CurrentMaxWalkSpeed { get => maxWalkSpeed; set => maxWalkSpeed = value; }
        [SerializeField] float maxSprintSpeed; //6
        public float CurrentMaxSprintSpeed { get => maxSprintSpeed; set => maxSprintSpeed = value; }
        [HideInInspector] public float CurrentMaxMoveSpeed;
        [HideInInspector] public Vector3 velocity = Vector3.zero;
        [HideInInspector] public float velocityXZ = 0f;
        [SerializeField] float moveAcceleration;
        public float MoveAcceleration { get => moveAcceleration; set => moveAcceleration = value; }

        [HideInInspector] public MoveContact[] moveContacts = CharacterMover.NewMoveContactArray;
        [HideInInspector] public int contactCount;

        public enum CameraStyle
        {
            Adventure,
            Combat,
        }

        [SerializeField] float turnSpeed;
        public float TurnSpeed { get => turnSpeed; }
    }
}
