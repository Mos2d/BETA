using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Stage1()
    {
        SceneManager.LoadScene("Stage 1");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Stage2()
    {
        SceneManager.LoadScene("Stage 2");
    }
    public void Stage3()
    {
        SceneManager.LoadScene("Stage 3");
    }
}
