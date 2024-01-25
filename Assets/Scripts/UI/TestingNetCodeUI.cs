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

    public static string typeSelected, code;

    private void Awake()
    {
        startHostButton.onClick.AddListener(() =>
        {
            Debug.Log("Starting game as HOST.");
            GameManager.CreateRelay();

            typeSelected = "HOST";
            code = GameManager.joinCode;

            Hide();
        });

        startClientButton.onClick.AddListener(() =>
        {
            Debug.Log("Starting game as CLIENT.");
            GameManager.JoinRelay(joinCode.text);

            typeSelected = "CLIENT";

            Hide();
        });
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
