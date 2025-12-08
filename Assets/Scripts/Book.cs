using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Book : MonoBehaviour
{
    public Image book;
    public TextMeshProUGUI page1;
    public TextMeshProUGUI page2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        book.enabled = false;
        page1.enabled = false;
        page2.enabled = false;
    }

    public void onClick()
    {
        if(book.enabled == false)
        {
            book.enabled = true;
            page1.enabled = true;
            page2.enabled = true;
        }
        else
        {
            book.enabled = false;
            page1.enabled = false;
            page2.enabled = false;
        }
    }
}
