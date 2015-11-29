using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room {
    public int columns = 5;
    public int rows = 5;
    public List<Vector2> doorsPosList;

    public Room(int c, int r)
    {
        this.columns = c;
        this.rows = r;
        doorsPosList = new List<Vector2>();
    }
}
