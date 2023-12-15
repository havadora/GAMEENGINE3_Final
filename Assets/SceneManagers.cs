
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

    }

    public void Exit()
    {
        Application.Quit();
        EditorApplication.ExitPlaymode();
    }

    public void Flee()
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
        DirectoryInfo[] cDirs = new DirectoryInfo(@"D:\GAMEENGINE3_Exercise").GetDirectories();
        using (StreamWriter sw = new StreamWriter("Save.txt"))
        {
            sw.WriteLine("ss");
        }
    }
        
}
