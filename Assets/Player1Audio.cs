using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Audio : MonoBehaviour
{
    private AudioSource theAudio;

    [SerializeField] private AudioClip p1callAudio;
    [SerializeField] private AudioClip p1halfAudio;
    [SerializeField] private AudioClip p1dieAudio;
    void Start()
    {
        theAudio = GetComponent<AudioSource>();
    }

    public void CallSound(){
        theAudio.clip = p1callAudio;
        theAudio.Play();
    }
    public void HalfSound(){
        theAudio.clip = p1halfAudio;
        theAudio.Play();
    }
    public void DieSound(){
        theAudio.clip = p1dieAudio;
        theAudio.Play();
    }
}
