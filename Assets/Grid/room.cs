using UnityEngine;

public class Room : MonoBehaviour
{
    public (float x, float y) coordinate { get; set; }
    public string RoomCat { get; set; }
    private bool isVisited;
    private bool isAdjacentToVisited;
    MainGrid mainGrid; // Supposition que MainGrid est une classe existante dans votre jeu
    private SpriteRenderer spriteRenderer;
    public GameObject weaponPrefab; // Préfabriqué pour l'arme
    private GameObject spawnedWeapon; // Instance de l'arme générée

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mainGrid = GameManager.instance.mainGrid; // Assurez-vous que cette référence est correcte
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            isVisited = true;
            HighLightedRoom();

            // Générer et afficher l'arme si elle n'existe pas déjà
            if (spawnedWeapon == null)
            {
                SpawnWeapon();
            }
            else
            {
                ShowWeapon(); // Rendre l'arme visible si elle est déjà générée
            }
        }
    }

private void SpawnWeapon()
    {
        if (weaponPrefab != null)
        {
            spawnedWeapon = Instantiate(weaponPrefab, transform.position, Quaternion.identity);
            spawnedWeapon.SetActive(false); // L'arme est initialement invisible
            Debug.Log("Arme générée mais invisible");
        }
        else
        {
            Debug.Log("Préfabriqué d'arme non assigné");
        }
    }


    // Appelée pour rendre l'arme visible
public void ShowWeapon()
{
    if (spawnedWeapon != null)
    {
        spawnedWeapon.SetActive(true);
        Debug.Log("Arme rendue visible");
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
        // Ajoutez ici toute logique de mise à jour supplémentaire si nécessaire
    }
}
