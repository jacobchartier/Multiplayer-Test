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

    #region Debugging stuff (Gizmos)
    private void OnDrawGizmosSelected()
    {
        // Gizmos to see where the player is currently looking.
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x + 1, this.transform.position.y));
    }
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        vCam = GetComponent<CinemachineVirtualCamera>();
    }

    private void FixedUpdate()
    {
        // Check who is the owner of the script. (Server or Client)
        if (!IsOwner) return;

        // Movement handler.
        HandleMovementServerAuth();
    }

    #region Movements handle + RPC
    // Recieve the input from the client.
    private void HandleMovementServerAuth()
    {
        // Handle W, A, S and D keys.
        Vector2 movementInput = InputManager.mouvementInput;
        HandleMovementServerRPC(movementInput);
    }

    // Send the movement to the server.
    [ServerRpc(RequireOwnership = false)]
    private void HandleMovementServerRPC(Vector2 input)
    {
        // Calculate the requested movement.
        rb.velocity = new Vector3(input.x * movementSpeed, rb.velocity.y, input.y * movementSpeed);
    }
    #endregion
}
