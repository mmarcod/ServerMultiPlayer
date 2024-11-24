using TMPro;
using Photon.Pun;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNameInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField = null;
    [SerializeField] private Button continueButton = null;

    private const string PlayerPrefsNameKey = "PlayerName";

    private void Start()
    {
        SetUpInputField();
        continueButton.interactable = false;
    }

    private void SetUpInputField()
    {
        if(!PlayerPrefs.HasKey(PlayerPrefsNameKey))
        {
            return;
        }

        string defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);

        nameInputField.text = defaultName;

        SetPlayerName(defaultName);
    }

    public void SetPlayerName(string name)
    {
        continueButton.interactable = string.IsNullOrEmpty(name);
    }

    public void SavePlayerName()
    {
        string playerName = nameInputField.text;
        PhotonNetwork.NickName = playerName;

        PlayerPrefs.SetString(PlayerPrefsNameKey, playerName);
    }
}