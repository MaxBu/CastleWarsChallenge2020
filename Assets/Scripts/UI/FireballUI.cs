using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballUI : MonoBehaviour
{

    public Transform fireballObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Instantiate(fireballObj, fireballObj.position, fireballObj.rotation);
    }
}
