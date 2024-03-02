using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum edgeType
{
    Bottom,
    left,
    Right

}
public class LevelEdge : MonoBehaviour
{
    [SerializeField] private edgeType type;
    public edgeType Type => type;
}
