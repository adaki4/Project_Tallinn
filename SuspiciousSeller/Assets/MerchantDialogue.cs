using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UIElements;

public class MerchantDialogue : MonoBehaviour
{
    [SerializeField] private GameObject speechBubblePrefab;
    private GameObject speechBubbleInstance;

    public TextAsset inkAsset;

    public TextAsset inkAsset2;

    protected bool canSpeak=false;

    protected bool isSpeaking=false;

    protected bool firstTimebitch=true;

    //NPC collides with player, awaits to speak
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerManager>() != null)
        {
            if(!canSpeak&&!isSpeaking)
            {
                Debug.Log(firstTimebitch);
                Debug.Log("i cant speak now i can");
                speechBubbleInstance=Instantiate(speechBubblePrefab, transform.position+new Vector3(0,3.5f), Quaternion.identity, transform);
                canSpeak = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerManager>() != null)
        {
           canSpeak=false; isSpeaking = false;
           if(speechBubbleInstance!=null) { Destroy(speechBubbleInstance); }
            firstTimebitch = false;

        }
    }
    protected virtual void OnMouseUpAsButton()
    {
        if (canSpeak&&!isSpeaking)
        {
            Destroy(speechBubbleInstance);
            if (firstTimebitch)
            {
                ModifiedInkExample.instance.StartStory(inkAsset);
            }
            else
            {
                ModifiedInkExample.instance.StartStory(inkAsset2);
            }
            isSpeaking = true;
        }
    }
    // Start is called before the first frame update

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
