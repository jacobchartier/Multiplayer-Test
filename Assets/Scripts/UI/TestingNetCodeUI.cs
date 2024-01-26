using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.Netcode;
using System.Runtime.CompilerServices;

public class TestingNetCodeUI : MonoBehaviour
{
    [SerializeField] private Button startHostButton;
    [SerializeField] private Button startClientButton;
    [SerializeField] private TMP_InputField joinCode;

    public static string typeSelected, state = "Waiting for host";

    private void Awake()
    {
        startHostButton.onClick.AddListener(() =>
        {
            state = "Loading";

            Debug.Log("Starting game as HOST.");
            RelayManager.CreateRelay();

            typeSelected = "HOST";

            Hide();
        });

        startClientButton.onClick.AddListener(() =>
        {
            Debug.Log("Starting game as CLIENT.");
            RelayManager.JoinRelay(joinCode.text);

            typeSelected = "CLIENT";

            Hide();
        });
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
