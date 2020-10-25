using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitch : MonoBehaviour
{
    private AudioManager audioManager;
    private GameManager gameManager;
    private bool activated = false;
    [SerializeField] string stopSong;
    [SerializeField] string playSong;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!activated && collision.gameObject.tag == "Player")
        {
            audioManager.Stop(stopSong);
            audioManager.Play(playSong);
            activated = true;
            gameManager.gameState = GameManager.GameState.Spook;
        }
    }
}
