using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManaGer : MonoBehaviour
{
    // Start is called before the first frame update
    private int turn;
    public GameObject textObj,chat;
    [SerializeField] private InforEnemy enemy;
    [SerializeField] private InforAllies allies;
    [SerializeField] List<Message> message = new List<Message>();
    private bool AIturn = false;
    private bool BattleDone = false;

    void Start()
    {
        turn = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

       // Debug.Log(enemy.GetHeath());

        



        if (turn == 2 && AIturn == true && BattleDone == false )
        {
            
            int Choice = Random.Range(1, 3);

            
            if (allies.GetHeath() <= 0)
            {
                SendToChat("You defeated");
                StartCoroutine(ChangeScene(4f));
                BattleDone = true;
            }

            if (Choice == 1 && allies.GetHeath() >= 0)
            {
                EnemyPunch();


            }
            if (Choice == 2 && allies.GetHeath() >= 0)
            {
                EnemyKick();


            }

        }


        if (turn == 1 && AIturn == false && BattleDone == false)
        {
            if (enemy.GetHeath() <= 0)
            {
                SendToChat("You defeat enemy");
                StartCoroutine(ChangeScene(4f));
                BattleDone = true;
            }
        }


    }

    private void EnemyKick()
    {
        allies.SetHealth(allies.GetHeath() - 20);
        SendToChat("Enemy dealt 20 damage");
        turn = 1;
        AIturn = false;
    }

    private void EnemyPunch()
    {
        allies.SetHealth(allies.GetHeath() - 10);
        SendToChat("Enemy dealt 10 damage");
        turn = 1;
        AIturn = false;
    }

    IEnumerator ChangeScene(float waitTime)
    {
        
        yield return new WaitForSecondsRealtime(waitTime);
        if (enemy.GetHeath() <= 0)
        {
            SceneManager.LoadScene("Second");
        }
        if (allies.GetHeath() <= 0)
        {
            SceneManager.LoadScene("FirstScene");
        }

    }

    public void PlayerPunch()
    { 
        enemy.SetHealth(enemy.GetHeath() - 10);
        SendToChat("You dealt 10 damage");
        turn = 2;
        AIturn = true;
    }
    public void PlayerKick()
    {
        enemy.SetHealth(enemy.GetHeath() - 20);
        SendToChat("You dealt 20 damage");
        turn = 2;
        AIturn = true;
    }   
    public void SendToChat(string text)
    {
        Message newMessage = new Message();
        newMessage.text = text;

        GameObject newtext = Instantiate(textObj, chat.transform);

        newMessage.textObj = newtext.GetComponent<Text>();
        newMessage.textObj.text = newMessage.text;

        message.Add(newMessage);

            
    }
}
public class Message
{
    public string text;
    public Text textObj;
}
