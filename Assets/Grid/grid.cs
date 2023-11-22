
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    [SerializeField] private int Height = 8;
    [SerializeField] private int Width = 9;
    [SerializeField] private int FloorLevel = 1;
    [SerializeField] private Transform cam;
    [SerializeField] private Cell Cell;
    [SerializeField] private Room Room;
    [SerializeField] private List<Room> Rooms = new();


    public void GenerateGrid()
    {

        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                Cell emptyCell = Instantiate(Cell, new Vector3(i, j), Quaternion.identity);
                emptyCell.name = $"Cell {i}{j}";
            }
        }
        cam.position = new Vector3((float)Width/2 -0.5f, (float)Height/2 -0.5f, -10);
    }
    public void GenerateRoom()
    {
        float random = Random.value;
        int numberOfRooms = (int)Mathf.Floor((random*2) + 5 + (FloorLevel * 2));
        while (Rooms.Count < 1)
        {
            ToInstantiateRoom(3, 5);

        }
    }
    public void ToInstantiateRoom(int i,int j)
    {
        var room = Instantiate(Room, new Vector3(i, j), Quaternion.identity);
        room.name = $"Room{i}{j}";
        if (!Rooms.Contains(room))
        {
            Rooms.Add(room);
        }
    }
    void Start()
    {
        GenerateGrid();
        GenerateRoom();
    }

    void Update()
    {

    }
}
