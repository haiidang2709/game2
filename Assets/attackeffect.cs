using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackeffect : MonoBehaviour
{
    [SerializeField] GameObject attackeffect1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            GameObject Effect = Instantiate(attackeffect1, transform.position, Quaternion.identity);
            Destroy(Effect,5f);
        }
    }
}
