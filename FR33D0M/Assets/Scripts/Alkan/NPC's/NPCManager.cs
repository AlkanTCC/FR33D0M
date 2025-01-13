using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NPCManager : MonoBehaviour
{
    public NPCObject[] npcObjectArray;
    public Tilemap sideWalk;

    public List<Vector3Int> allTilePositions = new List<Vector3Int>();

    [SerializeField] GameObject NPCGameObject;

    private void Awake()
    {
        GetAllSideWalkTiles();
    }

    void SpawnNPC()
    {
        for (int i = 0; i < 100; i++)
        {
            Instantiate(NPCGameObject);
        }
    }

    void GetAllSideWalkTiles()
    {
        BoundsInt bounds = sideWalk.cellBounds;

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int position = new Vector3Int(x, y, 0);
                TileBase tile = sideWalk.GetTile(position);

                if (tile != null)
                {
                    allTilePositions.Add(position);
                }
            }
        }

        SpawnNPC();
    }
}
