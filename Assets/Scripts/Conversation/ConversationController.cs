using UnityEngine;
using System.Collections;

namespace DD.Conversation
{
    public class ConversationController : MonoBehaviour
    {
        [SerializeField] ChatBubble myChatBubble = null;
        [SerializeField] Speeches currentSpeeches = null;

        public IEnumerator HandleConversation()
        {
            myChatBubble.SwitchChat(true);

            for(int i = 0; i < currentSpeeches.speeches.Length; i++)
            {
                Speech speech = currentSpeeches.speeches[i];

                myChatBubble.UpdateText(speech.message);
                yield return new WaitForSeconds(speech.timeToShow);
            }

            myChatBubble.SwitchChat(false);
        }
    }
}
