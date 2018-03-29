using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
       

    void Update()
    {
        if (gameObject.transform.position.y < -30) 
        {
            Destroy(gameObject);
        }
    }

}
