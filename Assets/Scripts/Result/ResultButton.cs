using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultButton : MonoBehaviour
{
    //遷移先
    public enum MenuType
    {
        TITLE,
        EXIT,
        SHOPPING
    }

    //ボタンをが押された時の処理 
    public void OnClick(int menuType)
    {
        switch ((MenuType)menuType)
        {
            case MenuType.TITLE:
                SceneTransitionManager.isToTitle = true;
                break;
            case MenuType.EXIT:
                SceneTransitionManager.isToExit = true;
                break;
            case MenuType.SHOPPING:
                SceneTransitionManager.isToShopping = true;
                break;

        }

    }


}
