using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailCollider : MonoBehaviour
{
    [SerializeField]
    GameObject EndText;
    // Start is called before the first frame update
    void Start()
    {
        EndText.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EndText.SetActive(true);
    }
}
