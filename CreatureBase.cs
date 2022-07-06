using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Creature", menuName = "Creature/Create new creature")]

public class CreatureBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] Element affinity;

    //Stats
    [SerializeField] int maxHP;
    [SerializeField] int maxMana;
    [SerializeField] int offense;
    [SerializeField] int defense;
    [SerializeField] int moffense;
    [SerializeField] int mdefense;
    [SerializeField] int speed;

    [SerializeField] List<LearnableMove> learnableMoves;

    public string Name{
        get {return name;}
    }

    public string Description{
        get{return description;}
    }

    public Sprite FrontSprite{
        get{return frontSprite;}
    }

    public Sprite BackSprite{
        get{return backSprite;}
    }

    public Element Affinity{
        get{return affinity;}
    }

    public int MaxHP{
        get{return maxHP;}
    }

    public int MaxMana{
        get{return maxMana;}
    }

    public int Offense{
        get{return offense;}
    }

    public int Defense{
        get{return defense;}
    }

    public int MOffense{
        get{return moffense;}
    }

    public int MDefense{
        get{return mdefense;}
    }

    public int Speed{
        get{return speed;}
    }
    
    public List<LearnableMove> LearnableMoves{
        get{return learnableMoves;}
    }

}

[System.Serializable]

public class LearnableMove{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase Base{
        get {return moveBase;}
    }

    public int Level{
        get{return level;}
    }
}

public enum Element
{
    None,
    Physical,
    Fire,
    Water,
    Lightning,
    Earth,
    Ice,
    Light,
    Shadow,
    Nature,
    Death
}
