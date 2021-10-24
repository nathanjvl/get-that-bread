using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//The overall stage 3 scene manager so controlling transitions and the game state
public class Stage3Manager : MonoBehaviour
{
    public int lives_max = 3;
    public int lives_current = 3;

    public Animator playerAnim; // player animator controller
    public Animator transition; // fade out transition.
    public Image[] lives; // life bread in the UI

    public bool monsterReached = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(monsterReached){
            StartCoroutine(TransitionNextScene());
        }

        if (lives_current <= lives_max)
        {
            if (lives_current < 3)
            {
                lives[2].enabled = false;
            }
            if (lives_current < 2)
            {
                lives[1].enabled = false;
            }
            if (lives_current < 1 )
            {
                lives[0].enabled = false;
                // This is the game end sequence since player lost all lives
                StartCoroutine(TransitionGameOver());
            }
        }
    }

    //have scripts call this in order to update the damage on the board
    public void take_damage()
    {
        Debug.Log("DAMAGE TAKEN");
        playerAnim.SetTrigger("Damage");
        lives_current -= 1; // subtract from lives

    }

    //These will be used for coroutines in order to transition nicely to other scenes.
    IEnumerator TransitionNextScene(){
        transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1); // pauses for 1 second
        SceneManager.LoadScene("ButtonMash");
    }

    IEnumerator TransitionGameOver(){
        transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameOver");
    }
}
