using System;

public class DragonBoss : Monsters
{
    // Propri�t�s sp�cifiques au DragonBoss
    public int FireDamage { get; set; }
    public string SpecialAbility { get; set; }

    // Constructeur du DragonBoss
    public DragonBoss() : base("DRACO", 1000, 1, 0, 0)
    {
        // Initialisez les propri�t�s sp�cifiques au boss ici
        FireDamage = 50;
        SpecialAbility = "Fiery Breath";
    }

    // M�thode pour d�finir les attaques du DragonBoss
    public void PerformAttack()
    {
        // G�n�rez une valeur al�atoire pour l'attaque entre 5 et 25
        int attackDamage = UnityEngine.Random.Range(5, 26);

        // Ajoutez le code pour appliquer les d�g�ts � la cible selon vos besoins
        Console.WriteLine($"{Name} attacks with {attackDamage} damage and {SpecialAbility}!");
    }

    // Vous pouvez �galement ajouter d'autres m�thodes sp�cifiques au DragonBoss ici si n�cessaire
}
