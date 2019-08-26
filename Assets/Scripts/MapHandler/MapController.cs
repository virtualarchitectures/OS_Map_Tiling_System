using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    //User Coordinate
    public Vector2 OSEastingNorthing;

    //Global offset
    public Vector3 globalOffset; 

    //Map Container
    private GameObject mapContainer;

    //Map tile prefab
    public GameObject mapTilePrefab;

    //Reference to Tile coordiante file
    public TextAsset tileCoordinatesFile;

    //Initialise list to store parsed data
    public List<ParsedData> parsedList = new List<ParsedData>();

    //List of map tile textures
    private Object[] textures;

    //class for parsed data
    public class ParsedData
    {
        public string tileName;
        public int xmin;
        public int ymin;
    }

    void Start()
    {
        //Instantiate map container
        mapContainer = new GameObject("mapContainer");

        //Read Tile Coordinates file
        ParseData();

        //Create tiles
        generateMapTiles();

        //Load textures
        LoadTextures();

        //Set Global Offset
        globalOffset.x = - OSEastingNorthing.x;
        globalOffset.z = - OSEastingNorthing.y;

        //Apply Global Offset
        mapContainer.transform.position = globalOffset;


    }

    //------FUNCTIONS------//

    //Function for parsing data
    void ParseData()
    {
        //Load file
        string fullText = tileCoordinatesFile.text;
        //Split file into rows by line endings
        string[] textLines = fullText.Split('\n');

        //Bool used to skip header
        bool firstLineParsed = false;

        foreach (string line in textLines)
        {
            if (firstLineParsed)
            {
                //Split rows by commas
                string[] values = line.Split(',');
                ParsedData test = new ParsedData();

                //Use try/catch to capture Null Pointer Exception and continue
                try
                {

                    test.tileName = values[0];
                    test.xmin = int.Parse(values[1]);
                    test.ymin = int.Parse(values[2]);
                    parsedList.Add(test);

                }
                catch (System.IndexOutOfRangeException)
                {
                    continue;
                }
            }
            else
            {
                firstLineParsed = true;
            }
        }
        //Log the number of parsed records to the console
        //Debug.Log("Number of parsed records = " + parsedList.Count);
    }

    void LoadTextures()
    {
        textures = Resources.LoadAll<Texture2D>("OS OpenMap Local (Full Colour Raster) TQ/data");

        foreach (var t in textures)
        {
            //Find object with the saame name as the texture
            var matchingTile = GameObject.Find(t.name);
            //Get a reference to the matching map tiles renderer
            var rend = matchingTile.GetComponent< Renderer>();
            //Add the texture to the base map
            rend.material.SetTexture("_BaseMap", t as Texture2D);
        }
    }

    //Function to create map tiles
    void generateMapTiles()
    {
        for (int i = 0; i < parsedList.Count; i++)
        {
            //Instantiate prefab with offset on x and z axis to place bottom left of tile at coordinate
            GameObject instance = Instantiate(mapTilePrefab, new Vector3(parsedList[i].xmin + 2500, 0, parsedList[i].ymin + 2500), Quaternion.Euler(0f, 180f, 0f)) as GameObject;
            //Assign the ID as the name of the instance
            instance.name = parsedList[i].tileName;

            //Add instance to map container object
            instance.transform.parent = mapContainer.transform;
        }
    }
}
