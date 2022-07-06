using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Creature/Create new move")]

public class MoveBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Element affinity;
    [SerializeField] int damage;
    [SerializeField] int accuracy;
    [SerializeField] int mana;

    public string Name{
        get{return name;}
    }

    public string Description{
        get{return description;}
    }

    public Element Affinity{
        get{return affinity;}
    }

    public int Damage{
        get{return damage;}
    }

    public int Accuracy{
        get{return accuracy;}
    }

    public int Mana{
        get{return mana;}
    }
}
