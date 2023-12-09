using System;

public class DragonBoss : Monsters
{
    // Propriétés spécifiques au DragonBoss
    public int FireDamage { get; set; }
    public string SpecialAbility { get; set; }

    // Constructeur du DragonBoss
    public DragonBoss() : base("DRACO", 1000, 1, 0, 0)
    {
        // Initialisez les propriétés spécifiques au boss ici
        FireDamage = 50;
        SpecialAbility = "Fiery Breath";
    }

    // Méthode pour définir les attaques du DragonBoss
    public void PerformAttack()
    {
        // Générez une valeur aléatoire pour l'attaque entre 5 et 25
        int attackDamage = UnityEngine.Random.Range(5, 26);

        // Ajoutez le code pour appliquer les dégâts à la cible selon vos besoins
        Console.WriteLine($"{Name} attacks with {attackDamage} damage and {SpecialAbility}!");
    }

    // Vous pouvez également ajouter d'autres méthodes spécifiques au DragonBoss ici si nécessaire
}
