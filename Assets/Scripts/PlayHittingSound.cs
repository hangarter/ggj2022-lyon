using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHittingSound : MonoBehaviour
{
    public AudioClip hittingSound;

    private AudioSource _audioSource;
    private BallThrower _ballThrower;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _ballThrower = GetComponent<BallThrower>();
        _ballThrower.OnBallThrown += OnBallHit;
    }

    public void OnBallHit()
    {
        Debug.Log("Hitting Sound");
        _audioSource.PlayOneShot(hittingSound);
    }
}
