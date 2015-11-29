using UnityEngine;
using System;
using SimpleJSON;

public class Level
{
    public Room[] rooms;
    public Vector3[] positions;
    public RoomLink[] links;
    public Vector3 playerStart;
    public Vector3 playerGoal;

    public Level(JSONNode docLevel)
    {
        initRooms(docLevel["rooms"]);
        initPositions(docLevel["positions"]);
        initLinks(docLevel["links"]);
        initPlayer(docLevel["player"]);
    }

    void initRooms(JSONNode docRooms)
    {
        int num_rooms = docRooms.Count;
        this.rooms = new Room[num_rooms];
        for (int i = 0; i < num_rooms; i++)
        {
            this.rooms[i] = new Room(docRooms[i]["cols"].AsInt, docRooms[i]["rows"].AsInt);
        }
    }

    void initPositions(JSONNode docPositions)
    {
        int num_positions = docPositions.Count;
        this.positions = new Vector3[num_positions];
        for (int i = 0; i < num_positions; i++)
        {
            this.positions[i] = new Vector3(
                docPositions[i]["x"].AsFloat,
                docPositions[i]["y"].AsFloat,
                docPositions[i]["z"].AsFloat);
        }
    }

    void initLinks(JSONNode docLinks)
    {
        int num_links = docLinks.Count;
        this.links = new RoomLink[num_links];
        for (int i = 0; i < num_links; i++)
        {
            this.links[i] = new RoomLink(
                docLinks[i]["r1_id"].AsInt,
                new Vector2(docLinks[i]["r1_door"]["x"].AsFloat,
                            docLinks[i]["r1_door"]["y"].AsFloat),
                docLinks[i]["r2_id"].AsInt,
                new Vector2(docLinks[i]["r2_door"]["x"].AsFloat,
                            docLinks[i]["r2_door"]["y"].AsFloat));
        }
    }

    void initPlayer(JSONNode docPlayer)
    {
        this.playerStart = getRoomPos(docPlayer["start"]);
        this.playerGoal = getRoomPos(docPlayer["goal"]);
    }

    // Función auxiliar para initPlayer
    private Vector3 getRoomPos(JSONNode pos)
    {
        Vector3 offset = new Vector3(pos["x"].AsFloat, pos["y"].AsFloat, 0f);
        Vector3 globalPos = this.positions[pos["room"].AsInt] + offset;
        return globalPos;
    }
}
