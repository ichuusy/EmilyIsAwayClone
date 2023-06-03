using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ChatSystem : MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text ownMessageText;
    public TMP_Text buddyMessageText;
    private string blueColorCode = "<#0050FF>";
    private string redColorCode = "<#FF000C>";
    private string blackColorCode = "<#000000>";
    public int messageIndex = 0;
    public string currentFriend;

    public static ChatSystem Instance;
    public GameObject choicePanel;
    public TMP_Text[] choices;
    private string[] choiceArray;
    public bool isChoicing;
    void Awake()
    {
        Instance = this;
        choicePanel.SetActive(false);
        ownMessageText.text = "";
        buddyMessageText.text = "";
        
    }

    void Update()
    {
    }

    public void OnCreateChat(string friendName)
    {
        currentFriend = friendName;
        title.text = $"{currentFriend} chat - MSN";
    }
    public void OnUpdateChatBuddy()
    {
        buddyMessageText.text += $"{blueColorCode}{currentFriend}:{blackColorCode} "+GameManager.Instance.messageHash[currentFriend].messages[messageIndex]+"\n";
    }
    public void OnUpdateChatOwn()
    {
        int selectObject = System.Convert.ToInt32(EventSystem.current.currentSelectedGameObject.name);
        ownMessageText.text += choiceArray[selectObject];
        System.Array.Clear(choiceArray,0,choiceArray.Length);
        choicePanel.SetActive(false);
        isChoicing = false;

    }

    public void OnCloseChat()
    {
        
    }

    public void SendMessage()
    {
        if(isChoicing) return;
        buddyMessageText.text += $"{redColorCode}ichuusy:{blackColorCode} "+ownMessageText.text+"\n";
        ownMessageText.text = "";
        messageIndex += 1;
        ChoiceSystem();
        OnUpdateChatBuddy();
    }

    public void PersonalInfo()
    {
        
    }

    public void ChoiceSystem()
    {
        string choice = GameManager.Instance.choiceHash[currentFriend].choices[messageIndex];
        choiceArray = choice.Split("|");
        for (int i = 0; i<choiceArray.Length; i++)
        {
            choices[i].text = choiceArray[i];
        }

        isChoicing = true;
        choicePanel.SetActive(true);
        
    }
}
