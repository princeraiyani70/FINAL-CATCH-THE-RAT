using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    private void OnMouseUp()
    {
        GameManager.instance.SoundPlayOnButtonClick();

        int GameObjectName = int.Parse(gameObject.name);

        GameManager.instance.AllHexagons[GameObjectName].GetComponent<SpriteRenderer>().sprite = GameManager.instance.ClickedHexagon;

        GameManager.instance.AllHexagons[GameObjectName].GetComponent<CircleCollider2D>().enabled = false;

        GameManager.instance.UserMovePosition.Add(GameObjectName);

        GameManager.instance.GetRatMovingPosibilities();

        GameManager.instance.RatMove();
    }
}
