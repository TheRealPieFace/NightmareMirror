using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    
    public static bool GameIsPause = true;
    
    public Button playButton;
    public Button quitButton;
    public Button resumeButton;
    public Button Quit;
    Animator myAnimator;
   
   



    private void Start()
    {
        Time.timeScale = 0f;
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            PauseGame();
        }

        playButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
        resumeButton.onClick.AddListener(ResumeGame);
        Quit.onClick.AddListener(QuitGame);


        if (GameIsPause)
        {
            StartCoroutine(Wait());
           //Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    

    }
   
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0f;

    }
    void StartGame()
    {
        GameIsPause = false;
        myAnimator.SetBool("startGame", true);
        
        
    }

    void PauseGame()
    {
        GameIsPause = true;
        myAnimator.SetBool("pauseGame", true);
    }

    void ResumeGame()
    {
        GameIsPause = false;
        myAnimator.SetBool("pauseGame", false);

    }

    void QuitGame()
    {
        Application.Quit();
    }

}
