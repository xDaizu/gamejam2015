using UnityEngine;
using System;
using System.Collections.Generic;       //Allows us to use Lists.
using Random = UnityEngine.Random;      //Tells Random to use the Unity Engine random number generator.
using SimpleJSON;

public class LevelManager : MonoBehaviour
{
    // Using Serializable allows us to embed a class with sub properties in the inspector.
    [Serializable]
    public class Count
    {
        public int minimum;             //Minimum value for our Count class.
        public int maximum;             //Maximum value for our Count class.


        //Assignment constructor.
        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    
    public RoomManager roomManager;
    public TextAsset LevelDoc;

    private JSONNode levelStruct;
    private Level[] levels;

    private GameObject playerWrapper;
    private Transform boardHolder;                               //A variable to store a reference to the transform of our Board object.
    private List<Vector3> gridPositions = new List<Vector3>();   //A list of possible locations to place tiles.

    public void Init()
    {
        this.levelStruct = JSON.Parse(LevelDoc.text);
        int num_levels = this.levelStruct.Count;
        this.levels = new Level[this.levelStruct.Count];
        for (int i = 0; i < num_levels; i++)
        {
            this.levels[i] = new Level(this.levelStruct[i]);
        }
    }

    //Sets up the outer walls and floor (background) of the game board.
    void BoardSetup(Level currentLevel)
    {
        if (currentLevel != null)
        {
            //Instantiate Board and set boardHolder to its transform.
            boardHolder = new GameObject("Board").transform;
            
            GameObject[] Rooms = roomManager.RoomSetup(currentLevel, boardHolder);
            foreach (GameObject room in Rooms)
            {
                room.transform.SetParent(boardHolder, false);
            }
            roomManager.transform.SetParent(boardHolder);

            // Retrieve the player and set it to the start position
            this.playerWrapper = GameObject.Find("PlayerWrapper");
            this.playerWrapper.SetActive(false);
            this.playerWrapper.transform.position = currentLevel.playerStart;
            this.playerWrapper.SetActive(true);
        }
    }

    //SetupScene initializes our level and calls the previous functions to lay out the game board
    public void SetupScene(int level)
    {
        Level currentLevel = levels[level];
        //Creates the outer walls and floor.
        BoardSetup(currentLevel);

        //Reset our list of gridpositions.
        // InitialiseList();

        //Determine number of enemies based on current level number, based on a logarithmic progression
        //int enemyCount = (int)Mathf.Log(level, 2f);

        //Instantiate the exit tile in the upper right hand corner of our game board
        //Instantiate(exit, new Vector3(columns - 1, rows - 1, 0f), Quaternion.identity);
    }


    //RandomPosition returns a random position from our list gridPositions.
    Vector3 RandomPosition()
    {
        //Declare an integer randomIndex, set it's value to a random number between 0 and the count of items in our List gridPositions.
        int randomIndex = Random.Range(0, gridPositions.Count);

        //Declare a variable of type Vector3 called randomPosition, set it's value to the entry at randomIndex from our List gridPositions.
        Vector3 randomPosition = gridPositions[randomIndex];

        //Remove the entry at randomIndex from the list so that it can't be re-used.
        gridPositions.RemoveAt(randomIndex);

        //Return the randomly selected Vector3 position.
        return randomPosition;
    }


    //LayoutObjectAtRandom accepts an array of game objects to choose from along with a minimum and maximum range for the number of objects to create.
    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        //Choose a random number of objects to instantiate within the minimum and maximum limits
        int objectCount = Random.Range(minimum, maximum + 1);

        //Instantiate objects until the randomly chosen limit objectCount is reached
        for (int i = 0; i < objectCount; i++)
        {
            //Choose a position for randomPosition by getting a random position from our list of available Vector3s stored in gridPosition
            Vector3 randomPosition = RandomPosition();

            //Choose a random tile from tileArray and assign it to tileChoice
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];

            Debug.Log("Rotando");
            //Instantiate tileChoice at the position returned by RandomPosition with no change in rotation
            Instantiate(tileChoice, randomPosition, tileChoice.transform.rotation);
        }
    }


}