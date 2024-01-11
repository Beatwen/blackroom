// --- Grid --- //

Classe: MonoBehaviour
+---------------------+
| Attributs:          |
| Méthodes:           |
+---------------------+

Classe: Room (hérite de MonoBehaviour)
+---------------------+
| Attributs:          |
| - MainGrid grid     |
| Méthodes:           |
| + void Start()      |
| + void Update()     |
+---------------------+

Classe: BossRoom (hérite de Room)
+---------------------+
| Attributs:          |
| Méthodes:           |
| + void Start()      |
| + void Update()     |
+---------------------+

Classe: ObjectRoom (hérite de Room)
+---------------------+
| Attributs:          |
| Méthodes:           |
| + void Start()      |
| + void Update()     |
+---------------------+

Classe: BossSpawnerFloor1 (hérite de MonoBehaviour)
+---------------------+
| Attributs:          |
| - Entity boss       |
| - int nextLevel     |
| Méthodes:           |
| + void Update()     |
| + void CheckEnemy() |
| + virtual void LoadMapGameScene() |
+---------------------+

Classe: BossSpawnerFloor2 (hérite de BossSpawnerFloor1)
+---------------------+
| Attributs:          |
| Méthodes:           |
| + void Update()     |
+---------------------+

Classe: Cell (hérite de MonoBehaviour)
+---------------------+
| Attributs:          |
| Méthodes:           |
| + void Start()      |
| + void Update()     |
+---------------------+

Classe: EnemySpawnerFloor1 (hérite de MonoBehaviour)
+---------------------+
| Attributs:          |
| - int floorLevel    |
| - GameObject Lezard |
| - int maxMonsters   |
| - List<GameObject> monsters |
| - List<Monsters> monstersDead |
| - private int count |
| Méthodes:           |
| + virtual void SetNbMonsters() |
| + virtual void Spawner(float x, float y) |
| + void SpawnLezard(Vector3 position) |
| + void Start()      |
| + void Update()     |
| + virtual void CheckEnemy() |
| + virtual void LoadMapGameScene() |
+---------------------+

Classe: EnemySpawnerFloor2 (hérite de EnemySpawnerFloor1)
+---------------------+
| Attributs:          |
| - GameObject medusa |
| Méthodes:           |
| + override void Spawner(float x, float y) |
| + void SpawnMedusa(Vector3 v) |
+---------------------+

Classe: GameManager (hérite de MonoBehaviour)
+---------------------+
| Attributs:          |
| - static GameManager instance |
| - MainGrid mainGrid |
| Méthodes:           |
| + void Awake()      |
+---------------------+

Classe: MainGrid (hérite de MonoBehaviour)
+---------------------+
| Attributs:          |
| - int height, width |
| - Player player     |
| - int floorLevel    |
| - Transform cam     |
| - Cell cellPrefab   |
| - Room roomPrefab   |
| - List<Room> rooms  |
| - Room startRoom, bossRoom |
| - List<(int x, int y)> coordinatesOfPotentialRooms |
| Méthodes:           |
| + void GenerateGrid() |
| + void GenerateRoom() |
| + void GenerateRoomFunction() |
| + (int x, int y) InstantiateRoom(int x, int y) |
| + void DoICreateARoom((int x, int y) roomCoordinate) |
| + bool CheckNeighbourCell(int x, int y) |
| + Vector3 SpawnPlayer() |
| + Vector3 SpawnBoss(Room playerStartRoom) |
| + float DistanceBtwRooms(Room room, Room playerStartRoom) |
| + Room GetRoom((float x, float y) coordinates) |
| + void SaveGridState() |
| + void LoadGridState() |
| + void Start()      |
| + void OnDestroy()  |
| + void Update()     |
+---------------------+

// --- Menu --- // 

Classe: IntroController (hérite de MonoBehaviour)
+----------------------------------+
| Attributs:                       |
| - public float delay = 12f       |
| Méthodes:                        |
| + void Start()                   |
| + IEnumerator SwitchSceneAfterDelay(float delay) |
+----------------------------------+
Description:
- La méthode Start() déclenche une coroutine qui attend un délai avant de changer de scène.
- La coroutine SwitchSceneAfterDelay(float delay) utilise WaitForSeconds pour attendre le délai spécifié avant de charger la scène "StartMenu".

Classe: StartMenu (hérite de MonoBehaviour)
+----------------------------------+
| Attributs:                       |
| Méthodes:                        |
| + public void StartBtn()         |
| + public void LoadBtn()          |
| + public void SettingsBtn()      |
| + public void QuitBtn()          |
| + void Start()                   |
| + void Update()                  |
+----------------------------------+
Description:
- StartBtn(): Supprime les fichiers d'état et charge la scène "MapGame1".
- LoadBtn(): Charge une scène de jeu basée sur le niveau du sol.
- SettingsBtn(): Charge la scène "Settings".
- QuitBtn(): Quitte l'application.
- Les méthodes Start() et Update() sont présentes mais ne contiennent pas d'implémentation spécifique dans le code fourni.

// --- Monster --- // 

Classe: Monsters (hérite de Entity)
+----------------------------------+
| Attributs:                       |
| - public LayerMask WhatIsPlayer  |
| - public bool isDead = false     |
| - public float moveSpeed = 1f    |
| - public float rotationSpeed = 1f|
| - float enemySpeedX              |
| - float direction                |
| - public float timeBetweenAttacks|
| - bool alreadyAttacked           |
| - private Vector3 previousPosition|
| - public Vector3 walkPoint       |
| - private Transform playerPos    |
| - public float sightRange = 2    |
| - public float attackRange = 1   |
| - public bool playerIsVisible, playerIsClose |
| - public int counter = 0         |
| Méthodes:                        |
| + void Patrol()                  |
| + void ChasePlayer()             |
| + void AttackPlayer()            |
| + void AttackPlayerLogic()       |
| + private void ResetAttack()     |
| + private void Awake()           |
| + public void GiveExperience(int experiencePoints) |
| + public void GiveItem(string item) |
| + private void OnTriggerEnter2D(Collider2D collide) |
| + private void OnTriggerExit2D(Collider2D collision) |
| + protected override void Start()|
| + protected override void Update()|
| + private void OnDrawGizmos()    |
+----------------------------------+
Description:
- Cette classe gère le comportement des monstres, y compris la patrouille, la poursuite et l'attaque du joueur.

Classe: Lizard (hérite de Monsters)
+----------------------------------+
| Attributs:                       |
| Méthodes:                        |
| + protected override void Start()|
| + protected override void Update()|
+----------------------------------+
Description:
- La classe Lizard hérite de Monsters et peut avoir des comportements supplémentaires ou modifiés, mais dans le code fourni, elle utilise les implémentations de base de Start() et Update() de la classe parente.


// --- Player --- // 

Classe: Player (hérite de Entity)
+----------------------------------+
| Attributs:                       |
| - [SerializedObject] MainGrid grid |
| - public float x, y, z           |
| - public Inventory PlayerInventory |
| - public int Mana                |
| Méthodes:                        |
| + void IncreaseMana(int amount)  |
| + void PickUpItem(string item)   |
| + void UseItem(string item)      |
| + void CastSpell(Spell spell)    |
| + void SetGridReference(MainGrid gridReference) |
| + void GainExperience(int experiencePoints) |
| + Transform GetPlayerLocation()  |
| + protected override void Start()|
| + bool CheckPlayerNeighbourCell(int x, int y) |
| + virtual void Move()            |
| + protected override void Update()|
+----------------------------------+
Description:
- Gère les actions du joueur, y compris le mouvement, la collecte et l'utilisation d'objets, et la gestion de la mana.

Classe: Spell
+----------------------------------+
| Attributs:                       |
| - public string Name             |
| - public int ManaCost            |
| Méthodes:                        |
| + public Spell(string name, int manaCost) |
| + public void Cast()             |
+----------------------------------+
Description:
- Représente un sort magique avec un nom et un coût de mana, avec la capacité de lancer le sort.

Classe: PlayerFightMode (hérite de Entity)
+----------------------------------+
| Attributs:                       |
| - [SerializeField] private float movementSpeed |
| - private float x, y, z          |
| - [SerializeField] AudioSource attackAudioSource |
| - private PlayerData playerData  |
| Méthodes:                        |
| + private void PlayAttackSound() |
| + public void SavePlayerState()  |
| + public void LoadPlayerState()  |
| + protected override void Start()|
| + protected override void Die()  |
| + void LoadStartMenu()           |
| + public void ManaRegen()        |
| + protected override void Update()|
| + void OnDisable()               |
+----------------------------------+
Description:
- Gère le mode de combat du joueur, y compris les mouvements, les attaques et la gestion de l'état du joueur.

Classe: WeaponFightMode (hérite de MonoBehaviour)
+----------------------------------+
| Attributs:                       |
| - private SpriteRenderer spriteRenderer |
| - private BoxCollider2D boxCollider |
| - public PlayerFightMode fightMode |
| - private bool enableAttack       |
| - public float horizontalInput, verticalInput |
| - private float attackCooldown, timeSinceAttack |
| Méthodes:                        |
| + void OnTriggerEnter2D(Collider2D attack) |
| + void ResetAttackCooldown()     |
| + void Start()                   |
| + void Update()                  |
+----------------------------------+
Description:
- Gère le comportement de l'arme en mode de combat, y compris la détection des collisions et la gestion du temps de rechargement des attaques.

// --- Entity --- // 

Classe: Entity (hérite de MonoBehaviour)
+----------------------------------+
| Attributs:                       |
| - public Animator animator       |
| - public SpriteRenderer spriteRenderer |
| - public BoxCollider2D boxCollider |
| - public Rigidbody2D rb          |
| - public float horizontalInput   |
| - public float verticalInput     |
| - public int AttackDamage        |
| - public string Name             |
| - public bool hasAlreadyHit      |
| - public int Life                |
| - public int Mana                |
| - public int Experience          |
| - public int Level               |
| - public int PositionX           |
| - public int PositionY           |
| Méthodes:                        |
| + protected virtual void CharFlipLogic(float direction) |
| + public virtual void TakeDamage(int damage) |
| + protected virtual void Die()   |
| + protected virtual void Start()  |
| + protected virtual void Update() |
+----------------------------------+
Description:
- La classe de base `Entity` définit les caractéristiques et les comportements communs des entités dans le jeu, telles que les personnages et les monstres.
- `CharFlipLogic(float direction)` gère le retournement du sprite en fonction de la direction du mouvement.
- `TakeDamage(int damage)` gère la réception des dégâts et la vérification de la mort de l'entité.
- `Die()` gère le comportement de l'entité lorsqu'elle meurt.
- Les méthodes `Start()` et `Update()` sont marquées comme `virtual` permettant aux classes dérivées de les surcharger avec des implémentations spécifiques.
