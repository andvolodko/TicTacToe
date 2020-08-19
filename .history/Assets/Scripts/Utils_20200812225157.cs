using UnityEngine;
using System.Collections;

public class Utils : MonoBehaviour
{

    public static void showGameObject(GameObject gameObject)
    {
        switchObject(gameObject, true);
    }

    public static void hideGameObject(GameObject gameObject)
    {
        switchObject(gameObject, false);
    }

    private static void switchObject(GameObject gameObject, bool on)
    {
        if (gameObject)
        {
            gameObject.SetActive(on);
        }
    }
}
