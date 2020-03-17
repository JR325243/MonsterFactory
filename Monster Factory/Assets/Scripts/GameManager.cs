using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public static List<Vector3> OccupiedSpaces = new List<Vector3>();

    public static void FillSpace(Vector3 space)
    {
        OccupiedSpaces.Add(space);
    }
}
