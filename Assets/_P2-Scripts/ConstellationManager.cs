using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstellationManager : MonoBehaviour
{
    public StarfieldGenerator starfieldGenerator;
    public TextAsset[] fileIndex;
    private Star[] data;
    private int[] hipToID;
    private LineRenderer line;
    private Star star1;
    private Star star2;
    private GameObject[] lines;
    private int startIndex;
    private char[] charSeparators;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void loadConstellation(int selection)
    {
        starfieldGenerator = GameObject.Find("Starfield-Manager").GetComponent<StarfieldGenerator>();
        starfieldGenerator.constellationSelection = selection;
        hipToID = starfieldGenerator.hipToIdPairs;
        data = starfieldGenerator.starObject;
        charSeparators = new char[] { ' ' };
        destroyLines();
        Debug.Log("Loading Sky Culture: " + fileIndex[selection].name);
        string[] rows = fileIndex[selection].text.Split('\n');
        Debug.Log("Number of Constellations: " + rows.Length);
        foreach(string row in rows)
        {
            string[] fields = row.Split(charSeparators, System.StringSplitOptions.RemoveEmptyEntries);

            if(fields.Length > 3)
            {
                if (fields[1] == "0")
                    Debug.Log(fields[0] + ":" + fields[1] + " - " + fields.Length);

                for (int i = 2; i < fields.Length; i += 2)
                {
                    if (fields[i] != null && fields[i + 1] != null)
                    {
                        star1 = new Star();
                        star1 = data[hipToID[System.Convert.ToInt32(fields[i])]];
                        star2 = new Star();
                        star2 = data[hipToID[System.Convert.ToInt32(fields[i + 1])]];
                        if (star1.hip != 0 && star2.hip != 0)
                        {
                            //Debug.Log(fields[i] + "->" + fields[i + 1]);
                            line = new GameObject("Line").AddComponent<LineRenderer>();
                            line.tag = "line";
                            line.startWidth = 0.1f;
                            line.endWidth = 0.1f;
                            line.useWorldSpace = true;
                            line.SetPosition(0, new Vector3(star1.x, star1.y, star1.z));
                            line.SetPosition(1, new Vector3(star2.x, star2.y, star2.z));
                        }
                    }
                }
            }
            
        }
    }

    public void destroyLines()
    {
        lines = GameObject.FindGameObjectsWithTag("line");
        foreach(GameObject line in lines)
        {
            GameObject.DestroyImmediate(line);
        }
    }

}
