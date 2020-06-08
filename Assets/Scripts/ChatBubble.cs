using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatBubble : ExtendedBehaviour
{
    private SpriteRenderer backgroundSpriteRenderer;
    private TextMeshPro textMeshPro;

    public static Transform chatBubblePrefab;
    private void Awake()
    {
        backgroundSpriteRenderer = transform.Find("Background").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
    }

    private void Setup(string text)
    {
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
        Vector2 textSize = textMeshPro.GetRenderedValues(false);
        Vector2 padding = new Vector2(-1f, 0f);
        backgroundSpriteRenderer.size = textSize + padding;

        Vector3 offset = new Vector3(-1f, 0f);
        backgroundSpriteRenderer.transform.localPosition = new Vector3(backgroundSpriteRenderer.size.x / 2f, 0f) + offset;
    }

    public void Create(ChatBubble chatBubble, Transform parent, Vector3 localPosition, string text, Vector3 positionOffset)
    {
        Transform chatBubbleTransform = Instantiate(chatBubble.transform, parent, true);
        chatBubbleTransform.localPosition = localPosition + positionOffset;
        chatBubbleTransform.GetComponent<ChatBubble>().Setup(text);

        Wait(3f, () => {
            Destroy(chatBubbleTransform.gameObject);
        });
        
    }


}
