using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navball : MonoBehaviour
{
    private Star loc;
    private Vector3 pos;
    private UnityEngine.UI.Text text;
    private float distMult;
    private void LateUpdate()
    {
        text = GameObject.Find("Distance").GetComponent<UnityEngine.UI.Text>();
        loc = GameObject.Find("Starfield-Manager").GetComponent<StarfieldGenerator>().starObject[0];
        pos = new Vector3(loc.x, loc.y, loc.z);
        distMult = GameObject.Find("Starfield-Manager").GetComponent<StarfieldGenerator>().distanceMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(pos);
        text.text = (Vector3.Distance(this.transform.position, pos)*distMult).ToString("F2") + " Parsecs to Sol";

    }
}
