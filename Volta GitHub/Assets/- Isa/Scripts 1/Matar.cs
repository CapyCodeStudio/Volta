using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matar : MonoBehaviour
{
    private Animator animator;
    private void OnMouseEnter()
    {
        animator.SetBool("Murder", false);
    }
}
