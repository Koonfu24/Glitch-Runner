using UnityEngine;

public class EnvMover : MonoBehaviour
{
    public float speed = 5f;
    public float destroyXPos = -15f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < destroyXPos)
        {
            Destroy(gameObject);
        }
    }
}
