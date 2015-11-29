using UnityEngine;
using System;
using System.Collections.Generic;       //Allows us to use Lists.
using Random = UnityEngine.Random;      //Tells Random to use the Unity Engine random number generator.
using SimpleJson;

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

    public Room[] roomList;
    public Vector3[] roomPositions;
    public RoomLink[] roomLinks;
    public RoomManager roomManager;

    private Transform boardHolder;                               //A variable to store a reference to the transform of our Board object.
    private List<Vector3> gridPositions = new List<Vector3>();   //A list of possible locations to place tiles.

    /*
    //Clears our list gridPositions and prepares it to generate a new board.
    void InitialiseList()
    {
        //Clear our list gridPositions.
        gridPositions.Clear();

        //Loop through x axis (columns).
        for (int x = 1; x < columns - 1; x++)
        {
            //Within each column, loop through y axis (rows).
            for (int y = 1; y < rows - 1; y++)
            {
                //At each index add a new Vector3 to our list with the x and y coordinates of that position.
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }
    */
    void initRoomList()
    {
        int room_num = 3;
        roomList = new Room[room_num];

        roomList[0] = new Room(7, 6);
        roomList[1] = new Room(5, 11);
        roomList[2] = new Room(7, 5);
    }

    void initRoomPositions()
    {
        roomPositions = new Vector3[roomList.Length];
        roomPositions[0] = new Vector3(0, 0, 0);
        roomPositions[1] = new Vector3(7+4, 0, 0);
        roomPositions[2] = new Vector3(0, 6+4, 0);
    }

    void initRoomLinks()
    {
        roomLinks = new RoomLink[3];
        roomLinks[0] = new RoomLink(0, new Vector2(7, 2), 1, new Vector2(-1, 2));
        roomLinks[1] = new RoomLink(1, new Vector2(-1, 8), 2, new Vector2(7, 0));
        roomLinks[2] = new RoomLink(0, new Vector2(3, 6), 2, new Vector2(3, -1));
    }

    //Sets up the outer walls and floor (background) of the game board.
    void BoardSetup()
    {
        //Instantiate Board and set boardHolder to its transform.
        boardHolder = new GameObject("Board").transform;

        this.initRoomList();
        this.initRoomPositions();
        this.initRoomLinks();

        GameObject[] Rooms = roomManager.RoomSetup(roomList, roomPositions, roomLinks);
        foreach (GameObject room in Rooms)
        {
            room.transform.SetParent(boardHolder, false);
        }
        roomManager.transform.SetParent(boardHolder);
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


    //SetupScene initializes our level and calls the previous functions to lay out the game board
    public void SetupScene(int level)
    {
        //Creates the outer walls and floor.
        BoardSetup();

        //Reset our list of gridpositions.
        // InitialiseList();

        //Determine number of enemies based on current level number, based on a logarithmic progression
        //int enemyCount = (int)Mathf.Log(level, 2f);

        //Instantiate the exit tile in the upper right hand corner of our game board
        //Instantiate(exit, new Vector3(columns - 1, rows - 1, 0f), Quaternion.identity);
    }
}