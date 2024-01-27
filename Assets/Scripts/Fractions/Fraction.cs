using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  public enum Nation
    {
        Neutral = 0,
        Britain,
        Prirates,
        France,
        Spain,
        Portuguese,
        Dutch
    }

public class Fraction : MonoBehaviour
{

    [SerializeField] private Nation nation;
    public Nation Nation { get { return nation; } }

    [Header("Resources")]
    [SerializeField] private int food;
    public int Food { get { return food; } set { food = value; } }
    
    [SerializeField] private int wood;
    public int Wood { get { return wood; } set {  wood = value; } }

    [SerializeField] private int gold;
    public int Gold { get { return gold; } set { gold = value; } }

    [SerializeField] private int stone;
    public int Stone { get {  return stone; } set {  stone = value; } }

}
