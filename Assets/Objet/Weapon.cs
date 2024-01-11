using System;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    SwordOfTheDragon,
    ElvenLongbow,
    DwarvenWarhammer,
    MagesStaff,
    AssassinsDagger,
    PaladinsHolySword,
    RangersCrossbow,
    SorcerersWand,
    BarbarianBattleAxe,
    ThiefsThrowingKnives,
    WarlocksCursedBlade,
    ClericsMace,
    NinjasShuriken,
    KnightsLance,
    DruidsElementalStaff
    // ... autres types d'armes
}

public class Weapon : Objet
{
    public int Damage { get; private set; }
    public int ManaRestore { get; private set; }
    public WeaponType Type { get; private set; }

    private static readonly Dictionary<WeaponType, string> weaponNames = new Dictionary<WeaponType, string>
    {
        { WeaponType.SwordOfTheDragon, "Épée du Dragon" },
        { WeaponType.ElvenLongbow, "Arc Elfe" },
        { WeaponType.DwarvenWarhammer, "Marteau de Guerre Nain" },
        { WeaponType.MagesStaff, "Bâton de Mage" },
        { WeaponType.AssassinsDagger, "Dague de l'Assassin" },
        { WeaponType.PaladinsHolySword, "Épée Sacrée du Paladin" },
        { WeaponType.RangersCrossbow, "Arbalète du Rôdeur" },
        { WeaponType.SorcerersWand, "Baguette du Sorcier" },
        { WeaponType.BarbarianBattleAxe, "Hache de Guerre Barbare" },
        { WeaponType.ThiefsThrowingKnives, "Couteaux de Lancer du Voleur" },
        { WeaponType.WarlocksCursedBlade, "Lame Maudite du Démoniste" },
        { WeaponType.ClericsMace, "Masse du Clerc" },
        { WeaponType.NinjasShuriken, "Shuriken du Ninja" },
        { WeaponType.KnightsLance, "Lance du Chevalier" },
        { WeaponType.DruidsElementalStaff, "Bâton Élémental du Druide" }
        // ... et ainsi de suite pour les autres armes
    };

    public Weapon(WeaponType type, int damage, int manaRestore) : base(weaponNames[type])
    {
        Type = type;
        Damage = damage;
        ManaRestore = manaRestore;
    }

    // Cette méthode doit être appelée lorsqu'un joueur interagit avec l'arme.
    public override void Interact(Player player)
    {
        Console.WriteLine($"{player.Name} a trouvé l'arme {Name} avec {Damage} de dégâts et elle restaure {ManaRestore} de mana!");
        player.IncreaseMana(ManaRestore);
        // Ajoutez ici toute autre logique d'interaction, par exemple la destruction de l'objet arme si nécessaire.
    }
}
