using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Utils
{
    public enum TYPE
    {
        SCALEDX,
        SCALEDY,
        SCALEDXY,
        OFFSET,
        SPECIFIC
    }
    public class Resize : MonoBehaviour
    {
        private RectTransform rectTransform;
        [SerializeField] private Vector2 offset;
        [SerializeField] private Vector2 scale;
        [SerializeField] private Vector2 specificSize;
        [SerializeField] private TYPE typeSize;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            rectTransform.sizeDelta = typeSize == TYPE.SCALEDXY ? new Vector2(Screen.width/scale.x, Screen.height/scale.y) :
                                                    typeSize == TYPE.SCALEDX ? new Vector2(Screen.width/scale.x, specificSize.y):
                                                    typeSize == TYPE.SCALEDY ? new Vector2(specificSize.x, Screen.height/scale.y):
                                                    typeSize == TYPE.OFFSET ? new Vector2(Screen.width - offset.x, Screen.height-offset.y):
                                                    new Vector2(specificSize.x, specificSize.y);
        }
       
    }
}


