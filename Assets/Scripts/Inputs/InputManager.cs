using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    Controls controls;
    public static Vector2 mouvementInput;

    private void Awake()
    {
        controls = new Controls();
        controls.Normal.Enable();
    }

    private void OnEnable()
    {
        controls.Normal.Movements.performed += ctx => mouvementInput = ctx.ReadValue<Vector2>();
        controls.Normal.Movements.canceled += ctx => mouvementInput = ctx.ReadValue<Vector2>();
    }
}
