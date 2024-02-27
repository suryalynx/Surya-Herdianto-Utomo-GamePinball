using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Color color;
    public float score;
    private Renderer rend;
    private Animator animator;
    public AudioManager audioManager;
    public VFXmanager VFXManager;
    public ScoreManager scoreManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
        rend.material.color = color;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider == bola)
        {
            Rigidbody rb = bola.GetComponent<Rigidbody>();
            rb.velocity *= multiplier;

            // animation
            animator.SetTrigger("hit");

            // audio
            audioManager.SfxBumper(other.transform.position);

            // VFX
            VFXManager.VFXBumper(other.transform.position);

            // score
            scoreManager.AddScore(score);
        }
    }
}
