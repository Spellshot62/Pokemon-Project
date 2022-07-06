using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature
{
    CreatureBase _base;
    int level;

    public int HP{get; set;} 

    public List<Move> Moves{get; set;}

    public Creature(CreatureBase cBase, int cLevel){
        _base = cBase;
        level = cLevel;
        HP = _base.MaxHP;

        Moves = new List<Move>();
        foreach (var move in _base.LearnableMoves){
            if(move.Level <= level){
                Moves.Add(new Move(move.Base));
            }

            //sets max # of moves
            if(Moves.Count >= 6){
                break;
            }
        }

    }

    public int Offense{
        get {return Mathf.FloorToInt((_base.Offense * level) / 100f) + 5;}
    }

    public int Defense{
        get {return Mathf.FloorToInt((_base.Defense * level) / 100f) + 5;}
    }

    public int MOffense{
        get {return Mathf.FloorToInt((_base.MOffense * level) / 100f) + 5;}
    }

    public int MDefense{
        get {return Mathf.FloorToInt((_base.MDefense * level) / 100f) + 5;}
    }

    public int Speed{
        get {return Mathf.FloorToInt((_base.Speed * level) / 100f) + 5;}
    }

    public int MaxHP{
        get {return Mathf.FloorToInt((_base.MaxHP * level) / 100f) + 10;}
    }

    public int MaxMana{
        get {return Mathf.FloorToInt((_base.MaxMana * level) / 100f) + 10;}
    }
}
