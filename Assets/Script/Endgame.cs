using UnityEngine;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{

    public BoxCollider2D collider2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //collision.gameObject.CompareTag("Player");
        if (collision.gameObject.CompareTag("Player") /*|| collision.gameObject.CompareTag("Player")*/)
        {
            SceneManager.LoadScene("YOU DIED");
        }

    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("YOU DIED");
        }
    }*/
}