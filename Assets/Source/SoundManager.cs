using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource efxSource;
    public AudioSource musicSource;

    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlaySingle (AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
