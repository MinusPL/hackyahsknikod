using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public bool inRange = false;
    public Interractable inter;
    [SerializeField] Transform knife;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            inter.Interract();
            
        }
        if (inter is PaintingInterractable)
        {
            if ((inter as PaintingInterractable).inProgress)
            {
                knife.gameObject.SetActive(true);
                knife.localPosition = new Vector3(Mathf.Abs(Mathf.Lerp(-.8f, .8f, Time.time % 1)) - .4f, 1.7f, .8f);
            }
            
            else{
                knife.gameObject.SetActive(false);
            }
        }
        else{
                knife.gameObject.SetActive(false);
            }
    }

    public void SetInRange(Interractable interractable, bool flag)
    {
        inter = flag ? interractable : null;
        inRange = flag;
    }
}
