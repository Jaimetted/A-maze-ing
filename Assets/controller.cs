
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour
{
    private bool walking = true;
    private Vector3 spawnPoint;
    // Use this for initialization
    void Start()
    {
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {


        if (walking)
        {
            transform.position = transform.position + Camera.main.transform.forward * .8f * Time.deltaTime;
        }

        if (transform.position.y < -10f)
        {
            transform.position = spawnPoint;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.name.Contains("Plane"))
            {
                walking = false;
            }
    
            else
            {
                walking = true;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("algo");

        if (other.gameObject.name == "Cube - Finish")
        {
            StartCoroutine(WaitAndWin());
        }
        if (other.gameObject.name == "mummy_rig")
        {
            StartCoroutine(WaitAndDie());
        }
    }
    IEnumerator WaitAndWin()
    {
        yield return new WaitForSeconds(3);
        Application.LoadLevel("Finish");

    }
    IEnumerator WaitAndDie()
    {
        yield return new WaitForSeconds(3);
        Application.LoadLevel("Die");

    }
}
