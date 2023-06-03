using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject chat;
    public GameObject buddyInfo;
    public GameObject buddyList;
    public static GameManager Instance;
    public BuddyHolder[] buddys;
    public PlayerChoiceHolder[] choices;
    public Dictionary<string, BuddyHolder> messageHash = new Dictionary<string, BuddyHolder>();
    public Dictionary<string, PlayerChoiceHolder> choiceHash = new Dictionary<string, PlayerChoiceHolder>();
    

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        foreach (var buddy in buddys)
        {
            messageHash.Add(buddy.name, buddy);
        }
        foreach (var choice in choices)
        {
            choiceHash.Add(choice.friendName, choice);
        }
        buddyInfo.SetActive(false);
        chat.SetActive(true);
        CreateChat("Nutella");
    }

    public void CreateChat(string friendName)
    {
        ChatSystem.Instance.OnCreateChat(friendName);
        ChatSystem.Instance.OnUpdateChatBuddy();
        ChatSystem.Instance.ChoiceSystem();
    }
}
