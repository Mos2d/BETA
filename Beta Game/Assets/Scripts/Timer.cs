using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text text;

    public static float timer;
    public float maxTime;

    public static bool moved;

    public GameObject losing;
    // Start is called before the first frame update

    IEnumerator Yay2(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Start()
    {
        moved = false;
        timer = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = timer.ToString("F2");
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetButtonDown("Fire1"))
        {
            moved = true;
        }
        if (moved)
        {


            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer = 0;
                Lose();
            }

            if (timer <= 3)
            {
                text.color = Color.red;
            }
            else
            {
                text.color = Color.white;
            }

            
        }
    }
    void Lose()
    {
        losing.SetActive(true);
        Timer.moved = false;
        StartCoroutine(Yay2(1));
    }
}
