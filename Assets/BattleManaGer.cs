using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManaGer : MonoBehaviour
{
    // Start is called before the first frame update
    private int turn;
    public Text texts;
    [SerializeField] private InforEnemy enemy;
    [SerializeField] private InforAllies allies;
   
    
    void Start()
    {
        turn = 1;
    }

    // Update is called once per frame
    void Update()
    {

       
        if (turn == 1)
        {
            
            if (enemy.GetHeath() <= 0)
            {
                turn = 3;
            }
            else
            {
                turn = 2;
            }
            
        }


        else if (turn == 2)
        {
            int Choice = Random.Range(1, 3);

            
            if (allies.GetHeath() <= 0)
            {

                turn = 4;

            }
            if (Choice == 1 && allies.GetHeath() >= 0)
            {
                Punch();
                turn = 1;

            }
            if (Choice == 2 && allies.GetHeath() >= 0)
            {
                Kick();
                turn = 1;
              
            }

        }


        else if (turn == 3)
        {
            texts.text = "You defeat the enemy";
            Debug.Log("You defeat the enemy");
            StartCoroutine(ChangeScene(4));
            SceneManager.LoadScene("Second");
        }
        else if (turn == 4)
        {
            texts.text = "You defeated ";
            StartCoroutine(ChangeScene(4));
            SceneManager.LoadScene("FirstScene");
        }  

        
    }

    IEnumerator ChangeScene(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
       
    }

    public void Punch()
    {
        
       if(turn == 1)
        {
            texts.text = "You dealt 10 damage\t";
            enemy.SetHealth(enemy.GetHeath() - 10);

        }
       if(turn == 2)
        {
            texts.text = "Enemy dealt 10 damage\t";
            allies.SetHealth(allies.GetHeath() - 10);
           
        }

        Debug.Log(turn);
    }
    public void Kick()
    {
        
        if (turn == 1)
        {
            texts.text = "You dealt 20 damage\t";
            enemy.SetHealth(enemy.GetHeath() - 20);
            turn = 2;
        }
        if (turn == 2)
        {
            texts.text = "Enemy dealt 20 damage\t";
            allies.SetHealth(allies.GetHeath() - 20);
            turn = 1;
        }
        Debug.Log(turn);
    }
}
