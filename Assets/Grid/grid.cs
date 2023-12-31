using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;



public class MainGrid : MonoBehaviour
{
    [SerializeField] private int height = 8;
    [SerializeField] private int width = 9;
    public Player player;
    [SerializeField] public int floorLevel = 1;
    [SerializeField] private Transform cam;
    [SerializeField] private Cell cellPrefab;
    [SerializeField] private Room roomPrefab;
    [SerializeField] public List<Room> rooms = new();

    private GridData gridData;
    public Room startRoom;
    public Room bossRoom;
    private readonly List<(int x, int y)> coordinatesOfPotentialRooms = new();

    [System.Serializable]
    private class RoomData
    {
        public string name;
        public float x;
        public float y;
        public string roomCat;
        public bool isVisited;
    }

    [System.Serializable]
    private class GridData
    {
        public List<RoomData> rooms;
        public int playerRoomX;
        public int playerRoomY;
    }



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
        int numberOfRooms = (int)Mathf.Floor((random * 2) + 10 + (floorLevel * 6));
        Debug.Log("We will have " + numberOfRooms);

        InstantiateRoom(3, 5);
        while (rooms.Count < numberOfRooms)
        {
            if (coordinatesOfPotentialRooms.Count == 0)
            {
                DoICreateARoom((3, 5));
            }
            else
            {
                int rand = (int)Mathf.Floor(Random.value * coordinatesOfPotentialRooms.Count);
                DoICreateARoom(coordinatesOfPotentialRooms[rand]);
            }
        }
    }
    public void GenerateRoomFunction()
    {

        for (int i = 0; i < 2; i++)
        {
            int rndRoomIndex = Random.Range(0, rooms.Count);
            rooms[rndRoomIndex].RoomCat = "FightRoom";
            Debug.Log("pi�ce fight  " + rooms[rndRoomIndex].coordinate);
        }

    }

    public (int x, int y) InstantiateRoom(int x, int y)
    {
        var room = Instantiate(roomPrefab, new Vector3(x, y), Quaternion.identity);
        room.name = $"Room {x} {y}";
        room.coordinate = (x, y);
        bool roomExists = rooms.Any(futurRoom => futurRoom.name == room.name);
        if (!roomExists)
        {
            rooms.Add(room);
        }
        return (x, y);
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
            InstantiateRoom(roomCoordinate.x, roomCoordinate.y);
        }
    }

    public bool CheckNeighbourCell(int x, int y)
    {
        return (!rooms.Any(room => room.name == $"Room {x} {y}"));
    }

    public Vector3 SpawnPlayer()
    {
        int index = Random.Range(0, rooms.Count());
        startRoom = rooms[index];
        SpawnBoss(startRoom);
        Debug.Log($"Default startroom for player is {startRoom.transform.position.x} - {startRoom.transform.position.y}");
        return startRoom.transform.position;
    }
    public Vector3 SpawnBoss(Room playerStartRoom)
    {
        Dictionary<Room, float> roomDistance = new();
        Room BossRoom = playerStartRoom;
        foreach (Room room in rooms)
        {
            float distance = DistanceBtwRooms(room, playerStartRoom);
            roomDistance.Add(room, distance);
        }
        Dictionary<Room, float> sortedRoomDistance = roomDistance.OrderBy(r => r.Value).ToDictionary(x => x.Key, x => x.Value);
        var LastPair = sortedRoomDistance.Last();
        BossRoom = LastPair.Key;
        bossRoom = BossRoom;
        bossRoom.RoomCat = "BossRoom";
        Debug.Log($"BossRoom est {bossRoom.coordinate.x} - {bossRoom.coordinate.y}");
        return BossRoom.transform.position;
    }
    private float DistanceBtwRooms(Room room, Room playerStartRoom)
    {
        float playerCoordX = playerStartRoom.coordinate.x;
        float playerCoordY = playerStartRoom.coordinate.y;
        float roomCoordX = room.coordinate.x;
        float roomCoordY = room.coordinate.y;
        return Mathf.Sqrt(Mathf.Pow(roomCoordX-playerCoordX, 2) + Mathf.Pow(roomCoordY-playerCoordY, 2));
    }
    public Room GetRoom((float x, float y) coordinates)
    {
        return rooms.Find(room => room.coordinate == coordinates);
    }
    public void SaveGridState()
    {
        if (File.Exists("GridState.json"))
        {
            File.Delete("GridState.json");
        }
        gridData = new GridData
        {
            rooms = rooms.Select(room => new RoomData
            {
                name = room.name,
                x = room.coordinate.x,
                y = room.coordinate.y,
                roomCat = room.RoomCat,
                isVisited = room.isVisited
            }).ToList(),
            playerRoomX = (int)player.x,
            playerRoomY = (int)player.y,
        };

        string json = JsonUtility.ToJson(gridData);
        File.WriteAllText("GridState.json", json);
    }


    public void LoadGridState()
    {
        if (File.Exists("GridState.json"))
        {

            Debug.Log("Loading data !");
            string json = File.ReadAllText("GridState.json");
            gridData = JsonUtility.FromJson<GridData>(json);
            foreach (var room in rooms)
            {
                Destroy(room.gameObject);
            }
            rooms.Clear();
            foreach (var roomData in gridData.rooms)
            {
                var room = Instantiate(roomPrefab, new Vector3(roomData.x, roomData.y), Quaternion.identity);
                room.name = roomData.name;
                room.coordinate = (roomData.x, roomData.y);
                room.RoomCat = roomData.roomCat;
                room.isVisited = roomData.isVisited;
                rooms.Add(room);
            }
            Debug.Log($"Player position is restored to {gridData.playerRoomX} - {gridData.playerRoomY}");
            Vector3 playerPosition = new Vector3(gridData.playerRoomX, gridData.playerRoomY, 0);
            player.transform.position = playerPosition;
            player.x = gridData.playerRoomX;
            player.y = gridData.playerRoomY;
        }
    }


    void Start()
    {
        GenerateGrid();
        GenerateRoom();
        GenerateRoomFunction();
    }

    private void OnDestroy()
    {
    }
    private void Update()
    {
    }
}