using UnityEngine;

public class Room : MonoBehaviour
{
    public (float x, float y) coordinate { get; set; }
    private bool isVisited;
    private bool isAdjacentToVisited;
    MainGrid mainGrid = GameManager.instance.mainGrid;
    private SpriteRenderer spriteRenderer;
    public Objet objet { get; set; }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Debug.Log("Trigger entered!");
        if (otherCollider.CompareTag("Player"))
        {
            Debug.Log("Player entered the room!");
            
            isVisited = true;
            
            HighLightedRoom();
            
        }
    }

    public void HighLightedRoom()
    {
        if (isVisited)
        {
            Color currentColor = spriteRenderer.color;
            Color highlightedColor = new Color(currentColor.r, currentColor.g, currentColor.b, 1f);
            spriteRenderer.color = highlightedColor;
            HighLightAdjacentRoom();
        }
        
    }
    private void HighLightAdjacentRoom()
    {
        (float x, float y)[] relativeCoordinates = {
            (coordinate.x + 1, coordinate.y),
            (coordinate.x - 1, coordinate.y),
            (coordinate.x, coordinate.y + 1),
            (coordinate.x, coordinate.y - 1)
        };

        foreach (var relativeCoordinate in relativeCoordinates)
        {
            Room adjRoom = mainGrid.GetRoom(relativeCoordinate);
            if (adjRoom != null && adjRoom.isVisited == false)
            {
                Color currentColor = adjRoom.spriteRenderer.color;
                Color highlightedColor = new Color(currentColor.r, currentColor.g, currentColor.b, 0.5f);
                adjRoom.spriteRenderer.color = highlightedColor;
            }
        }
    }


    void Update()
    {
        
    }
}