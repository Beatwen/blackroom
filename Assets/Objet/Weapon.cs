using System;
using System.Collections;
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
}

public class Weapon : Objet
{
    public int Damage { get; set; }
    public WeaponType Type { get; private set; }

    private static readonly Dictionary<WeaponType, string> weaponNames = new Dictionary<WeaponType, string>
    {
    { WeaponType.SwordOfTheDragon, "Épée du Dragon" },1
    { WeaponType.ElvenLongbow, "Arc Elfe" },4
    { WeaponType.DwarvenWarhammer, "Marteau de Guerre Nain" },5
    { WeaponType.MagesStaff, "Bâton de Mage" },6
    { WeaponType.AssassinsDagger, "Dague de l'Assassin" },7
    { WeaponType.PaladinsHolySword, "Épée Sacrée du Paladin" },8
    { WeaponType.RangersCrossbow, "Arbalète du Rôdeur" },
    { WeaponType.SorcerersWand, "Baguette du Sorcier" },9
    { WeaponType.BarbarianBattleAxe, "Hache de Guerre Barbare" },10
    { WeaponType.ThiefsThrowingKnives, "Couteaux de Lancer du Voleur" },11
    { WeaponType.WarlocksCursedBlade, "Lame Maudite du Démoniste" },2
    { WeaponType.ClericsMace, "Masse du Clerc" },12
    { WeaponType.NinjasShuriken, "Shuriken du Ninja" },3
    { WeaponType.KnightsLance, "Lance du Chevalier" },13
    { WeaponType.DruidsElementalStaff, "Bâton Élémental du Druide" }14
        // ... et ainsi de suite pour les autres armes
    };

    public Weapon(WeaponType type, int damage) : base(weaponNames[type])
    {
        Type = type;
        Damage = damage;
    }

    public override void Interact(Player player)
    {
        Console.WriteLine($"{player.Name} a trouvé l'arme {Name} avec {Damage} de dégâts!");
    }
}
