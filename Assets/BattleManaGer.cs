using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManaGer : MonoBehaviour
{
    // Start is called before the first frame update
    int turn = 1;
    public Text texts;
    [SerializeField] private InforEnemy enemy;
    [SerializeField] private InforAllies allies;
    bool Punching = false;
    bool Kincking = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        switch(turn)
        {
            case 1:
                if(Punching == true && enemy.GetHeath() >= 0)
                {
                    Punch();
                    texts.text = "You dealt 10 damage";
                    Punching = false;
                    turn = 2;
                    
                }
                if(Kincking == true && enemy.GetHeath() >= 0)
                {
                    Kick();
                    texts.text = "You dealt 20 damage";
                    Kincking = false;
                    turn = 2;
                    
                }
                else if(enemy.GetHeath() <= 0)
                {

                    turn = 3;

                }

                break;

            case 2:
                int Choice = Random.Range(1, 3);

                if (Choice == 1 && allies.GetHeath() >= 0)
                {
                    Punch();
                    texts.text = "You get 10 damage";
                    Punching = false;
                    turn = 1;
                    break;
                }
                else if (Choice == 2 && allies.GetHeath() >= 0)
                {
                    Kick();
                    texts.text = "You get 20 damage";
                    Kincking = false;
                    turn = 1;
                    break;
                }
                if(allies.GetHeath() <= 0)
                {

                    turn = 4;
                    
                }

                
                break;
            case 3:
                texts.text = "You defeat the enemy";
                break;
            case 4:
                texts.text = "You had defeat ";
                break;

        }
    }

    public void Punch()
    {
        Punching = true;
       if(turn == 1)
        {
            enemy.SetHealth(enemy.GetHeath() - 10);
        }
       if(turn == 2)
        {
            allies.SetHealth(allies.GetHeath() - 10);
        }
    }
    public void Kick()
    {
        Kincking = true;
        if (turn == 1)
        {
            enemy.SetHealth(enemy.GetHeath() - 20);
        }
        if (turn == 2)
        {
            allies.SetHealth(allies.GetHeath() - 20);
        }
    }
}
