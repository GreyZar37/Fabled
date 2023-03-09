using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_ : MonoBehaviour
{
    public static Texture2D normalCursor;
    public Texture2D normalCursor_;

    Vector2 cursorPosition;

    public static Texture2D currentCursor;


    // Start is called before the first frame update
    void Start()
    {
        normalCursor = normalCursor_;
        currentCursor = normalCursor;
    }

    // Update is called once per frame
    void Update()
    {
        cursorPosition = Vector2.zero;
        Cursor.SetCursor(currentCursor, cursorPosition, CursorMode.Auto);
    }
}
