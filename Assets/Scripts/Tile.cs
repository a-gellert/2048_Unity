using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tile : MonoBehaviour
{
    public bool mergeThisTurn = false;
    public int indRow;
    public int indCol;
    private int number;
    public int Number
    {
        get
        {
            return number;
        }
        set
        {
            number = value;
            {
                if (number == 0)
                {
                    SetEmpty();
                }
                else
                {
                    ApplyStyle(number);
                    SetVisible();
                }
            }
        }
    }
    private TextMeshProUGUI tileText;
    private Image tileImage;
    private void Awake()
    {
        tileText = GetComponentInChildren<TextMeshProUGUI>();
        tileImage = transform.Find("Number").GetComponent<Image>();
    }

    private void ApplyStyleFromStylesheet(int index)
    {
        tileText.text = TileStylesheet.Instance.TileStyles[index].number.ToString();
        tileText.color = TileStylesheet.Instance.TileStyles[index].TextColor;
        tileImage.color = TileStylesheet.Instance.TileStyles[index].TileColor;
    }
    private void ApplyStyle(int num)
    {
        switch (num)
        {
            case 2:
                ApplyStyleFromStylesheet(0);
                break;
            case 4:
                ApplyStyleFromStylesheet(1);
                break;
            case 8:
                ApplyStyleFromStylesheet(2);
                break;
            case 16:
                ApplyStyleFromStylesheet(3);
                break;
            case 32:
                ApplyStyleFromStylesheet(4);
                break;
            case 64:
                ApplyStyleFromStylesheet(5);
                break;
            case 128:
                ApplyStyleFromStylesheet(6);
                break;
            case 256:
                ApplyStyleFromStylesheet(7);
                break;
            case 512:
                ApplyStyleFromStylesheet(8);
                break;
            case 1024:
                ApplyStyleFromStylesheet(9);
                break;
            case 2048:
                ApplyStyleFromStylesheet(10);
                break;
            case 4096:
                ApplyStyleFromStylesheet(11);
                break;
            case 8192:
                ApplyStyleFromStylesheet(12);
                break;
            case 16384:
                ApplyStyleFromStylesheet(13);
                break;
            case 32768:
                ApplyStyleFromStylesheet(14);
                break;
            case 65536:
                ApplyStyleFromStylesheet(15);
                break;
            case 131072:
                ApplyStyleFromStylesheet(16);
                break;
            default:
                Debug.LogError("Check numbers in Applystyle");
                break;
        }

    }
    private void SetVisible()
    {
        tileImage.enabled = true;
        tileText.enabled = true;
    }
    private void SetEmpty()
    {
        tileImage.enabled = false;
        tileText.enabled = false;
    }

}
