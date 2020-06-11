using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacheteBehaviour : MonoBehaviour
{
    Animator ac;

    public bool makeSlices;
    // Start is called before the first frame update
    void Start()
    {
        ac = this.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Slash());
        }
    }

    IEnumerator Slash()
    {
        ac.SetTrigger("Slash");
        yield return new WaitForSeconds(1);
        makeSlices = true;
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        Rigidbody rb = collision.gameObject.AddComponent<Rigidbody>();
        StartCoroutine(DestroySlices(collision.gameObject));
    }
    IEnumerator DestroySlices(GameObject slice)
    {
        yield return new WaitForSeconds(1f);
        Destroy(slice);
    }
    
}
