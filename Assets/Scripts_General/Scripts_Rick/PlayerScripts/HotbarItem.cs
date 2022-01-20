using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarItem : MonoBehaviour
{

    public GameObject ItemPrefab;
    public float FrameNumber = 0f;

    Texture2D tex;
    Sprite item_sprite;
    float timeout = 0; 

    // Start is called before the first frame update
    void Start()
    {
        // tex = UnityEditor.AssetPreview.GetMiniThumbnail(ItemPrefab);
        // item_sprite = Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        // GetComponent<UnityEngine.UI.Image>().sprite = item_sprite;

        while(tex == null || timeout < 2){
            tex = UnityEditor.AssetPreview.GetAssetPreview(ItemPrefab);
            timeout += Time.deltaTime;
        }
        
        item_sprite = Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        GetComponent<UnityEngine.UI.Image>().sprite = item_sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
