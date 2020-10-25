using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool isStarted = false;
    private bool isSwapped = false;
    [SerializeField] GameObject chair;
    [SerializeField] Sprite emptyChair;
    [SerializeField] Sprite sleepChair;
    [SerializeField] GameObject player;
    [SerializeField] GameObject shade;
    [SerializeField] Transform deathSpawnSpook;
    [SerializeField] Transform deathSpawnChase;
    [SerializeField] Transform shadeSpawn;

    public enum GameState
    {
        Normal,
        Spook,
        Chase
    }

    public GameState gameState = GameState.Normal;
    private bool invincible = false;
    private AudioManager audioManager;

    public float health = 3f;
    [SerializeField] Slider healthSlider;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if(!isStarted && !isSwapped && Input.anyKey)
        {
            chair.GetComponent<SpriteRenderer>().sprite = emptyChair;
            player.SetActive(true);
        }
    }

    public void SwapChairSprite()
    {

        Debug.Log("FJASODJGA");
        chair.GetComponent<SpriteRenderer>().sprite = sleepChair;
        chair.GetComponent<EndInteraction>().active = true;
        isSwapped = true;
    }

    public void TakeDamange(int damage)
    {
        if (!invincible)
        {
            audioManager.Play("Hit");
            health -= damage;
            healthSlider.value = health;
            CheckDeath();
            invincible = true;
            StartCoroutine(ToggleIFrame());
        }
        
    }

    IEnumerator ToggleIFrame()
    {
        yield return new WaitForSeconds(.2f);
        invincible = false;
    }

    private void CheckDeath()
    {
        if(health <= 0)
        {
            HandleDeath();
        }
    }

    public void HandleDeath()
    {
        if(gameState == GameState.Spook)
        {
            player.transform.position = deathSpawnSpook.position;
            health = 3f;
            healthSlider.value = health;
        }
        else if(gameState == GameState.Chase)
        {
            player.transform.position = deathSpawnChase.position;
            shade.transform.position = shadeSpawn.position;
            health = 3f;
            healthSlider.value = health;
        }
    }
}
