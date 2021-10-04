using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using DD.Platforms;
using DD.Conversation;
using DD.Data;

public class GameManager : MonoBehaviour 
{
    PlatformManager platformManager;
    PlayData playData;

    private void Awake() 
    {
        platformManager = FindObjectOfType<PlatformManager>();    
        playData = FindObjectOfType<PlayData>();
    }

    public void HandleArriveAtBoss(GameObject checker)
    {
        StartCoroutine(HandleArrvie(checker));
    }

    IEnumerator HandleArrvie(GameObject checker)
    {
        platformManager.StopMove();

        yield return new WaitForSeconds(0.5f);

        yield return StartCoroutine(checker.GetComponent<ConversationController>().HandleConversation());

        platformManager.StartMove();
        playData.StartBossFight();
    }
}