﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public ChatBubble ChatBubble;
    public string Text;
    public Vector3 PositionOffset;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            ChatBubble.Create(ChatBubble, this.transform, this.transform.localPosition, Text, PositionOffset);
        }
    }
}
