using UnityEngine;

public class puzzleManager : MonoBehaviour
{
   public int platesNeeded = 3;
   private int currentPlatesActive = 0;

   public Transform door;
   public Vector3 openOffset = new Vector3(0, 2f, 0);
   public float openSpeed = 2f;

   private Vector3 closedPosition;
   private Vector3 openPosition;
   private bool isDoorOpen = false;

   void Start()
   {
        closedPosition = door.position;
        openPosition = closedPosition + openOffset;
   }

   void Update()
   {
    Vector3 target = isDoorOpen ? openPosition : closedPosition;
    door.position = Vector3.Lerp(door.position, target, Time.deltaTime * openSpeed);
   }

   public void PlateActivated()
   {
        currentPlatesActive++;

        if (currentPlatesActive >= platesNeeded)
        {
            isDoorOpen = true;
        }
   }

   public void PlateDeactivated()
   {
    currentPlatesActive--;

    if (currentPlatesActive < platesNeeded)
    {
        isDoorOpen = false;
    }
   }
}
