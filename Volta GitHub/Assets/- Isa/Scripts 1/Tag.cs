using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tag : MonoBehaviour
{
    public string player;
    public string invisivel;
    private void Update()
    {
        
    }

    private void ChangePlayerTagToNewTag()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.tag = invisivel;
        }
    }

    private void RestorePlayerTag()
    {
        GameObject player = GameObject.FindWithTag(invisivel);
        if (player != null)
        {
            player.tag = "Player"; 
        }
    }
}

