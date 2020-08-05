using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallThroughPlatform : MonoBehaviour
{
    private BoxCollider2D col;
    private float startingOffset;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeRotation()
    {
        StartCoroutine(RotatePlatform());
    }

    private IEnumerator RotatePlatform()
    {
        col.enabled = false;

        yield return new WaitForSeconds(1f);

        col.enabled = true;
    }
}
