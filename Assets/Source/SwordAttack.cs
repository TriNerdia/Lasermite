using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class SwordAttack : MonoBehaviour
{
    public Animation swordAnimation;
    public int swordDamage = 10;
    public AudioSource audioData;
    

    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

    private void Start()
    {
        swordAnimation = GetComponent<Animation>();
        audioData = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player" || (collision.gameObject.tag == "Portal" && transform.parent.gameObject.tag != "Enemy"))
        {
            collision.gameObject.GetComponent<ObjectHealth>().TakeDamage(swordDamage);
        }
    }

    private void OnDisable()
    {
       // if (transform.parent.tag == "Player")
        {
            float randomPitch = Random.Range(lowPitchRange, highPitchRange);
            audioData.pitch = randomPitch;
            audioData.Play(0);
        }

    }
    
    public void PlayAttackAnimation()
    {
        if (transform.parent.tag == "Player")
        {
            swordAnimation.Play("Attack");
        }
        else
            swordAnimation.Play("Attack 1");
    }

    
}
