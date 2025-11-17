using UnityEngine;

public class CloseLid : MonoBehaviour
{

    bool isOpen = true;
    public float changeX = 2.0f;
    public float changeZ = 4.0f;

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
        if (!isOpen)
        {
            transform.position += new Vector3(changeX, 0, 0);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,
                                    transform.localEulerAngles.y, changeZ);
            isOpen = true;
            return;
            //transform.rotation += startRotation;   
        }
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Count pills when !isOpen to determine score
        // should be done here?
    }
}
