using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCannonFiringSound : MonoBehaviour
{
    private AudioSource _audioSource;
    private BallThrower _ballThrower;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _ballThrower = GetComponent<BallThrower>();
        _ballThrower.OnBallThrown += OnCannonFire;
    }

    public void OnCannonFire()
    {
        _audioSource.Play();
    }
}
