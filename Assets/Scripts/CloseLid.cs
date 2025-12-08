using UnityEngine;

public class CloseLid : MonoBehaviour
{

    public bool isOpen = true;
    public float changeX = 2.0f;
    public float changeZ = 4.0f;
    float secondsTilOpen = 0;
    void OnMouseDown()
    {
        // Is the tray lid open or closed?
        if (isOpen)
        {
            transform.position += new Vector3(-changeX, 0, 0);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,
                                    transform.localEulerAngles.y, -changeZ);
            isOpen = false;
            return;
        }
        // if (!isOpen)
        // {
        //     transform.position += new Vector3(changeX, 0, 0);
        //     transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,
        //                             transform.localEulerAngles.y, changeZ);
        //     isOpen = true;

        //     return;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if(!isOpen)
        {

            secondsTilOpen += Time.deltaTime;
            if(secondsTilOpen > 1.5)
            {
                isOpen = true;                
                transform.position += new Vector3(changeX, 0, 0);
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,
                                        transform.localEulerAngles.y, changeZ);
                
                secondsTilOpen = 0;
            }
        }
    }
}
