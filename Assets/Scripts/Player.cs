using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Player : NetworkBehaviour
{
    Rigidbody rb;
    CinemachineVirtualCamera vCam;

    [SerializeField] private float movementSpeed = 5;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x + 1, this.transform.position.y));
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        vCam = GetComponent<CinemachineVirtualCamera>();
    }

    private void FixedUpdate()
    {
        if (!IsOwner) return;

        HandleMovementServerAuth();
    }

    private void HandleMovementServerAuth()
    {
        Vector2 movementInput = InputManager.mouvementInput;
        HandleMovementServerRPC(movementInput);
    }

    [ServerRpc(RequireOwnership = false)]
    private void HandleMovementServerRPC(Vector2 input)
    {
        rb.velocity = new Vector3(input.x * movementSpeed, rb.velocity.y, input.y * movementSpeed);
    }

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {

        }
        else
        {

        }
    }
}
