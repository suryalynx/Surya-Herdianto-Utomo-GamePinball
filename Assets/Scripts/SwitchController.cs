using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SwitchController : MonoBehaviour
{
    public Collider bola;
    public Material onMaterial;
    public Material offMaterial;
    public float score;
    public AudioManager audioManager;
    public VFXmanager VFXManager;
    public ScoreManager scoreManager;
    private Renderer rend;
    private enum SwitchState
    {
        off,
        on,
        Blink
    }
    private SwitchState state;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        Set(false);
        StartCoroutine(BlinkTimerStart(5));
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other == bola)
        {
            Toggle();
            VFXManager.VFXSwitch(other.transform.position);
        }
    }

    private void Set(bool active)
    {
        if ((active && state != SwitchState.on) || (!active && state != SwitchState.off))
        {

            if (active == true)
            {
                state = SwitchState.on;
                rend.material = onMaterial;
                audioManager.SfxSwitchOn(transform.position);
                StopAllCoroutines();
            }
            else
            {
                state = SwitchState.off;
                rend.material = offMaterial;
                audioManager.SfxSwitchOff(transform.position);
                StartCoroutine(BlinkTimerStart(5));
            }
        }
    }

    private void Toggle()
    {

        if (state == SwitchState.on)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }

        scoreManager.AddScore(score);
    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;
        for (int i = 0; i < times; i++)
        {
            rend.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            rend.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }
        state = SwitchState.off;
        StartCoroutine(BlinkTimerStart(5));

    }

    private IEnumerator BlinkTimerStart(float times)
    {
        yield return new WaitForSeconds(times);
        StartCoroutine(Blink(2));
    }
}

