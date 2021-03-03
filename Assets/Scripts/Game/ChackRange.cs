using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChackRange : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("enter");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Base")
        {
            this.gameObject.GetComponent<Parts>().SetIsRangeFlag(true);
            if (this.gameObject.GetComponent<Parts>().GetIsfadeOutFlag())
            {
                this.gameObject.GetComponent<Parts>().SetMove(false);
            }
        }

        //Debug.Log("stay");
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Base")
        {
            this.gameObject.GetComponent<Parts>().SetIsRangeFlag(false);
        }
        //Debug.Log("exit");
    }
}
