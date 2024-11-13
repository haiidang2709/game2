using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody2D Quaichem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("vungchem"))
        {
            Destroy(gameObject);
        }
    }
    public void Hienthivungchem()
    {
        Quaichem.gameObject.SetActive(true);
    }
}
