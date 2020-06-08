using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : ExtendedBehaviour
{
    public ChatBubble ChatBubble;
    public string Text;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            ChatBubble.Create(ChatBubble, this.transform, this.transform.localPosition, Text);
            Wait(4f, () => {
                Destroy(ChatBubble.transform);
            });
            
        }
    }
}
