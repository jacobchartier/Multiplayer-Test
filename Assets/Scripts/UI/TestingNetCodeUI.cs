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

    public static string typeSelected;

    private void Awake()
    {
        startHostButton.onClick.AddListener(() =>
        {
            Debug.Log("Starting game as HOST.");
            NetworkManager.Singleton.StartHost();

            typeSelected = "HOST";

            Hide();
        });

        startClientButton.onClick.AddListener(() =>
        {
            Debug.Log("Starting game as CLIENT.");
            NetworkManager.Singleton.StartClient();

            typeSelected = "CLIENT";

            Hide();
        });
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
