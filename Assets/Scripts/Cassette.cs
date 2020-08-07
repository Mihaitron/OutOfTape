using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cassette : MonoBehaviour
{
    private GameObject button;
    private float waitTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime <= 0)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Button")
            button = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Button")
            button = null;
    }

    private void OnDestroy()
    {
        if (button != null)
            button.GetComponent<GroundButton>().setTapeCollision(false);
    }
}
