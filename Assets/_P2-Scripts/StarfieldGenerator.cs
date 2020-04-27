using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarfieldGenerator : MonoBehaviour
{
    public TextAsset jsonFile;
    public ParticleSystem.EmitParams p;
    public ParticleSystem pSys;
    public float distanceMultiplier;
    public Star[] starObject;
    public int[] hipToIdPairs;

    // Start is called before the first frame update
    void Start()
    {
        distanceMultiplier = 5.0f;
        drawStars(distanceMultiplier);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void drawStars(float scale)
    {
        pSys.Clear();
        starObject = new Star[200000];
        Star temp;
        Stars starsInJson = JsonUtility.FromJson<Stars>(jsonFile.text);
        hipToIdPairs = new int[200000];
        Debug.Log(hipToIdPairs.Length);
        foreach (Star star in starsInJson.stars)
        {
            if (star.hip != 0)
            {
                hipToIdPairs[star.hip] = star.id;
            }
            temp = new Star();
            temp.id = star.id;
            temp.hip = star.hip;
            temp.proper = star.proper;
            temp.mag = star.mag;
            temp.x = star.x * scale;
            temp.y = star.y * scale;
            temp.z = star.z * scale;
            starObject[star.id] = temp;
            p = new ParticleSystem.EmitParams();
            p.position = new Vector3(star.x * scale, star.y * scale, star.z * scale);
            p.startLifetime = 100000;
            p.velocity = Vector3.zero;
            p.startSize = .01f * star.mag * distanceMultiplier;
            p.startColor = Color.white;
            if (star.id == 0)
            {
                p.startColor = Color.yellow;
            }
            pSys.Emit(p, 1);
        }
    }
}
