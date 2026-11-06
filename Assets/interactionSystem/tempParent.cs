using UnityEngine;

public class tempParent : MonoBehaviour
{
  public static tempParent Instance {get; private set;}

  private void Awake()
  {
    if(Instance == null)
    {
        Instance = this;
    }
    else
    {
        Destroy(this);
    }
  }
}
