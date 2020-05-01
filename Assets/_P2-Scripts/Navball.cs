using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navball : MonoBehaviour
{
    private Star loc;
    private Vector3 pos;
    private UnityEngine.UI.Text text;
    private string destination;
    private float distMult;

    private void Start()
    {

    }
 
    // Update is called once per frame
    private void LateUpdate()
    {
        this.transform.LookAt(pos);
        text.text = (Vector3.Distance(this.transform.position, pos)/distMult).ToString("F2") + " Parsecs to " + destination;

    }

    public void setCourse(int id)
    {
        distMult = GameObject.Find("Starfield-Manager").GetComponent<StarfieldGenerator>().scaling;
        GameObject.Find("Starfield-Manager").GetComponent<StarfieldGenerator>().courseSelection = id;
        text = GameObject.Find("Distance").GetComponent<UnityEngine.UI.Text>();
        loc = GameObject.Find("Starfield-Manager").GetComponent<StarfieldGenerator>().starObject[id];
        pos = new Vector3(loc.x, loc.y, loc.z);
        destination = loc.proper;
    }

    public void warp()
    {
        GameObject.Find("CAVE2-PlayerController").transform.position = new Vector3(pos.x, pos.y - 1, pos.z - 2);
        GameObject.Find("CAVE2-PlayerController").transform.eulerAngles = Vector3.zero;
    }

    /*
     * Some testing things...
     * ID       Name                dist     
     * 0        Sol                 0
     * 70666    Proxima Centauri    1.2959
     * 32263    Sirius              2.6371
     * 90979    Vega                7.6787
     * 69451    Arcturus            11.2575
     * 27919    Betelgeuse          152.6718
     */

}
