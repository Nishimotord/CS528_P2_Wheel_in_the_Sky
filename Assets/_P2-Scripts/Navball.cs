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
        setCourse(0);
    }

    // Update is called once per frame
    void Update()
    {
        distMult = GameObject.Find("Starfield-Manager").GetComponent<StarfieldGenerator>().distanceMultiplier;
        this.transform.LookAt(pos);
        text.text = (Vector3.Distance(this.transform.position, pos)/distMult).ToString("F2") + " Parsecs to " + destination;

    }

    public void setCourse(int id)
    {
        text = GameObject.Find("Distance").GetComponent<UnityEngine.UI.Text>();
        loc = GameObject.Find("Starfield-Manager").GetComponent<StarfieldGenerator>().starObject[id];
        pos = new Vector3(loc.x, loc.y, loc.z);
        destination = loc.proper;
        distMult = GameObject.Find("Starfield-Manager").GetComponent<StarfieldGenerator>().distanceMultiplier;
    }

    public void warp()
    {
        GameObject.Find("CAVE2-PlayerController").transform.position = pos;
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
