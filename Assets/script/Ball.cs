using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{

    public bool ispressed = false;
    public Rigidbody2D rb;
    public Rigidbody2D hook;
    public float releasetime = .15f;
    public float length = 1.5f;
    public GameObject nextball;
    private void Update()
    {
        if (ispressed)
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousepos, hook.position) > length)
            {
                rb.position = hook.position + (mousepos - hook.position).normalized * length;


            }
            else
            {
                rb.position = mousepos;
            }
        }
    }
    private void OnMouseDown()
    {
        ispressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        ispressed = false;
        rb.isKinematic = false;

        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releasetime);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;

        yield return new WaitForSeconds(2f);
        if (nextball != null)
        {
            nextball.SetActive(true);
        }
        else
        {
            load();
        }
    }

    public void load()
    {
        Invoke("loadnxt", 2f);
    }

    public void loadnxt()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
