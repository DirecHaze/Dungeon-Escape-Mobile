using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int _value;
   
    private void Start()
    {
        gameObject.transform.parent = GameObject.Find("Floor").transform;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player._diamondHave += _value;
            Destroy(this.gameObject);
        }
    }
}
