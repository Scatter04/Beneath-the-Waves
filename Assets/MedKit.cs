using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    private bool destroyed = false;


    [SerializeField]
    public float rotationSpeed = 85f;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && destroyed == false)
        {
            Destroy(gameObject);
            destroyed = true;
            
        }
    }
}
