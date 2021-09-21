using UnityEngine;

public class Object : MonoBehaviour 
{
    public ObjectInfo info = null;

    [SerializeField] bool isSpinning = false;
    [SerializeField] float spinSpeed = 100f;

    private void Update() 
    {
        Spin();
    }

    void Spin()
    {
        if(isSpinning)
        {
            transform.eulerAngles += new Vector3(0, 0, spinSpeed * Time.deltaTime);
        }
    }
}