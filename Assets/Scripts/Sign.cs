using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public ChatBubble chatBubble;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            chatBubble.Create(chatBubble, this.transform, this.transform.localPosition, "EI TIOOO QUE DIUS?");
        }
    }
}
