using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject enemy;

    public GameObject winning;
    public GameObject losing;

    public bool alive;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Enemy yeas = enemy.GetComponent<Enemy>();
        alive = yeas.alive;
        if (!Player.alive)
        {
            Lose();
        }
        if (!alive && Player.alive)
        {
            Win();
        }
    }

    IEnumerator Yay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator Yay2(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Win()
    {
        winning.SetActive(true);
        Timer.moved = false;
        StartCoroutine(Yay(1));

    }

    void Lose()
    {
        losing.SetActive(true);
        Timer.moved = false;
        StartCoroutine(Yay2(1));
    }
}
