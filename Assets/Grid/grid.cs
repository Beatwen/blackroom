using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private int height = 8;
    [SerializeField] private int width = 9;
    [SerializeField] private int floorLevel = 1;
    [SerializeField] private Transform cam;
    [SerializeField] private Cell cellPrefab;
    [SerializeField] private Room roomPrefab;
    [SerializeField] private List<Room> rooms = new();
    private List<(int x, int y)> coordinatesOfPotentialRooms = new();

    public void GenerateGrid()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Cell emptyCell = Instantiate(cellPrefab, new Vector3(i, j), Quaternion.identity);
                emptyCell.name = $"Cell {i} {j}";
            }
        }
        cam.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
    }

    public void GenerateRoom()
    {
        float random = Random.value;
        int numberOfRooms = (int)Mathf.Floor((random * 2) + 10 + (floorLevel * 2));
        Debug.Log("We will have " + numberOfRooms + "rooms normally..");

        ToInstantiateRoom(3, 5);
        while (rooms.Count < numberOfRooms)
        {
            if (coordinatesOfPotentialRooms.Count == 0)
            {
                DoICreateARoom((3, 5));
            }
            else
            {
                int rand = (int)Mathf.Floor(Random.value * coordinatesOfPotentialRooms.Count);
                Debug.Log(rand);
                DoICreateARoom(coordinatesOfPotentialRooms[rand]);
            }
        }
    }

    public (int x, int y) ToInstantiateRoom(int i, int j)
    {
        var room = Instantiate(roomPrefab, new Vector3(i, j), Quaternion.identity);
        room.name = $"Room {i} {j}";
        bool roomExists = rooms.Any(futurRoom => futurRoom.name == room.name);
        if (!roomExists)
        {
            Debug.Log($"Adding room number: {i}-{j}");
            rooms.Add(room);
        }
        return (i, j);
    }

    public void DoICreateARoom((int x, int y) roomCoordinate)
    {
        int nbAdjacentRooms = 0;
        List<int> possibilities = new() { 0, 1, 2, 3 };
        while (possibilities.Count > 0 && nbAdjacentRooms < 2)
        {
            int rand = possibilities[(int)Mathf.Floor(Random.value * possibilities.Count)];
            possibilities.Remove(rand);
            int newX = roomCoordinate.x;
            int newY = roomCoordinate.y;

            switch (rand)
            {
                case 0:
                    newY += 1;
                    break;
                case 1:
                    newY -= 1;
                    break;
                case 2:
                    newX += 1;
                    break;
                case 3:
                    newX -= 1;
                    break;
            }

            if (CheckNeighbourCell(newX, newY))
            {
                coordinatesOfPotentialRooms.Add((newX, newY));
            }
            else
            {
                nbAdjacentRooms++;
            }
        }

        if (nbAdjacentRooms < 2 
            && nbAdjacentRooms > 0 
                && (int)Mathf.Floor(Random.value*2) == 0 
                    && roomCoordinate.x > 0 
                        && roomCoordinate.y > 0
                            && roomCoordinate.x < 9
                                && roomCoordinate.y < 8)
        {
            ToInstantiateRoom(roomCoordinate.x, roomCoordinate.y);
            Debug.Log($"Instantiating room at {roomCoordinate.x}-{roomCoordinate.y}");
        }
    }

    public bool CheckNeighbourCell(int x, int y)
    {
        return (!rooms.Any(room => room.name == $"Room {x} {y}"));
    }

    void Start()
    {
        GenerateGrid();
        GenerateRoom();
        Debug.Log($"Total Rooms: {rooms.Count}");
        foreach ((int x, int y) coord in coordinatesOfPotentialRooms)
        {
            Debug.Log(coord.ToString());
        }
        
    }
}
