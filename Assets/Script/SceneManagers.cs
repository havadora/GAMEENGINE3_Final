
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class SceneManagers : MonoBehaviour
{
    // Start is called before the first frame update
    string scene;
    [SerializeField] private GameObject Attcking;
    [SerializeField] private GameObject Back;
    [SerializeField] private GameObject Pause;
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject Credits;
    InforAllies allies;
    InforEnemy enemy;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Pause.SetActive(true);
        }

        /*if(allies.GetHeath() <= 0)
        {

        }*/

    }
    public void Menu(string Scene_name)
    {
        SceneManager.LoadScene(Scene_name);
    }
    public void New_Game(string Scene_name)
    {
       
        SceneManager.LoadScene(Scene_name);
        
    }
    public void Continue()
    {
        using (StreamReader sr = new StreamReader("Save.txt"))
        {
            string LastScene;


            while ((LastScene = sr.ReadLine()) != null)
            {
                string[] lines = LastScene.Split(',');
                scene = String.Copy(lines[0]);
                SceneManager.LoadScene(scene);
                
            }
           
        }
       
    }

    public void Credit()
    {
        MainMenu.SetActive(false);
        Credits.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
        //EditorApplication.ExitPlaymode();
    }

    public void Flee()
    {
        //SceneManager.LoadScene("FirstScene");
        using (StreamReader sr = new StreamReader(@"D:\MultiplayerSystem_Final\GAMEENGINE3_Final\Save.txt"))
        {
            string LastScene;


            while ((LastScene = sr.ReadLine()) != null)
            {
                string[] lines = LastScene.Split(',');
                scene = String.Copy(lines[0]);
                SceneManager.LoadScene("FirstScene");
            }
        }

    }

    public void Attack()
    {
        Attcking.SetActive(false);
        Back.SetActive(true);
    }

    public void Backs()
    {
        Attcking.SetActive(true);
        Back.SetActive(false);
    }

    public void Save()
    {
        DirectoryInfo[] cDirs = new DirectoryInfo(@"D:\MultiplayerSystem_Final\GAMEENGINE3_Final").GetDirectories();
        using (StreamWriter sw = new StreamWriter("Save.txt"))
        {
            sw.WriteLine("ss");
        }
    }
    public void Mainmenu()
    {
        MainMenu.SetActive(true);
        Credits.SetActive(false);
    }
}
