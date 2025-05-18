using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSoundPlayer : MonoBehaviour
{
    [SerializeField] AudioClip gameOverSound;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        if (gameOverSound != null)
        {
            audioSource.PlayOneShot(gameOverSound);
        }
    }
}
