
using System.Collections;
using System.Collections.Generic;

public class LockedSideways : DoorSideways
{


    // Update is called once per frame
    void Update()
    {
        if (DoorIsLocked == true)
        {
           //Ovi ei avaudu
           //Off Navmeshlink aktivointi on false
        }
    }
}
