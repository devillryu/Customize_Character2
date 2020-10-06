using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customize_Character : MonoBehaviour
{
    GameObject hair1;
    Transform hair_pos;
    // Start is called before the first frame update
    void Start()
    {
        hair_pos = transform.Find("/Player/Head/Hair_pos");
        hair1 = Resources.Load("Hair/Hair_01") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
       /* if(Input.GetMouseButtonDown(0))
        {
            GameObject newhair = Instantiate(hair1);
            newhair.transform.parent = hair_pos.transform;
        } */
        
    }
}
