using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Matar : MonoBehaviour
{
    public Slider healthSlider;
    public Text healthText;

    private int vida = 100;
    private int vidaAtual;

    private Animator animator;
    private void Start()
    {
        vidaAtual = vida;
        UpdateHealthUI();
    }

    private void OnMouseEnter()
    {
        animator.SetBool("Murder", false);

    }

    public void TakeDamage(int damage)
    {
        vidaAtual -= damage; // dano
        vidaAtual = Mathf.Clamp(vidaAtual, 0, vida);
        UpdateHealthUI();

        if (vidaAtual <= 0)
        {
            animator.SetBool("Murder", false);
        }
    }

    private void UpdateHealthUI()
    {
        healthSlider.value = (float)vidaAtual / vida; // slider
        healthText.text = "Health: " + vidaAtual + " / " + vida; // texto
    }
}

