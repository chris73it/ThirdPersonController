using System.Security.Claims;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace HeroicArcade.CC.Core
{
    [System.Serializable] public class MoveInputEvent : UnityEvent<Vector2> {}
    [System.Serializable] public class CameraRecenterXEvent : UnityEvent<bool> { }
    [System.Serializable] public class CameraAimEvent : UnityEvent<bool> { }
    [System.Serializable] public class AimSwapEvent : UnityEvent { }

    public sealed class InputController : MonoBehaviour
    {
        [SerializeField] MoveInputEvent moveInputEvent;
        [SerializeField] CameraRecenterXEvent cameraRecenterXEvent;
        [SerializeField] CameraAimEvent cameraAimEvent;
        [SerializeField] AimSwapEvent aimSwapEvent;

        Controls controls;
        private void Awake()
        {
            controls = new Controls();

            controls.Gameplay.Move.started += OnMove;
            controls.Gameplay.Move.performed += OnMove;
            controls.Gameplay.Move.canceled += OnMove;

            controls.Gameplay.Sprint.started += OnSprint;
            controls.Gameplay.Sprint.canceled += OnSprint;

            controls.Gameplay.Jump.started += OnJump;
            controls.Gameplay.Jump.canceled += OnJump;

            controls.Gameplay.CameraRecenterX.started += OnRecenterX;
            controls.Gameplay.CameraRecenterX.canceled += OnRecenterX;

            controls.Gameplay.Aim.started += OnAim;
            controls.Gameplay.Aim.canceled += OnAim;

            controls.Gameplay.Shoot.started += OnShoot;
            controls.Gameplay.Shoot.performed += OnShoot;
            controls.Gameplay.Shoot.canceled += OnShoot;

            controls.Gameplay.AimSwap.started += OnAimSwap;
        }

        private Vector2 moveInput;
        [HideInInspector] public bool IsMovePressed;
        private void OnMove(InputAction.CallbackContext context)
        {
            moveInput = context.ReadValue<Vector2>();
            moveInputEvent.Invoke(moveInput);
        }

        [HideInInspector] public bool IsSprintPressed;
        private void OnSprint(InputAction.CallbackContext context)
        {
            IsSprintPressed = context.ReadValueAsButton();
        }

        [HideInInspector] public bool IsJumpPressed;
        private void OnJump(InputAction.CallbackContext context)
        {
            IsJumpPressed = context.ReadValueAsButton();
        }

        private void OnRecenterX(InputAction.CallbackContext context)
        {
            cameraRecenterXEvent.Invoke(context.ReadValueAsButton());
        }

        [HideInInspector] public bool IsAimPressed;
        private void OnAim(InputAction.CallbackContext context)
        {
            IsAimPressed = context.ReadValueAsButton();
            cameraAimEvent.Invoke(IsAimPressed);
        }

        [HideInInspector] public bool IsShootPressed;
        private void OnShoot(InputAction.CallbackContext context)
        {
            IsShootPressed = context.ReadValueAsButton();
        }

        private void OnAimSwap(InputAction.CallbackContext context)
        {
            aimSwapEvent.Invoke();
        }

        private void OnEnable()
        {
            controls.Gameplay.Enable();
        }

        private void OnDisable()
        {
            controls.Gameplay.Disable();
        }
    }
}
