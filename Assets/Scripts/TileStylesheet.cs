using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStylesheet : MonoBehaviour
{
    public static TileStylesheet Instance;
    public TileStyle[] TileStyles;
    private void Awake()
    {
        Instance = this;
    }

}
