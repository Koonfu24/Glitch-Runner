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
          PlayerAna pa = collision.GetComponent<PlayerAna>();

            if (pa != null)
            {
                pa.SendDataOnDeath();
                pa.ResetData();
            }
            else
            {
                Debug.LogError("❌ ไม่มี PlayerAnalytics บน Player");
            }
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