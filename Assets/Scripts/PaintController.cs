using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintController : MonoBehaviour
{
    SpriteMask mask;
    Color[] colors;
    int width; 
    int height; 
    public int radius = 5; 
    public GameObject maskObj; 

    void Start() 
    {
        //Get objects
    	mask = maskObj.GetComponent<SpriteMask>();

    	//Extract color data once
    	colors = mask.sprite.texture.GetPixels();

    	//Store mask dimensionns
    	width = mask.sprite.texture.width;
    	height = mask.sprite.texture.height;

    	Clearmask();       
    }

    void Clearmask()
    {                    
        //set all color data to transparent
    	for (int i = 0; i < colors.Length; ++i)
    	{
    	   colors[i] = new Color(1, 1, 1, 0);
    	}

    	mask.sprite.texture.SetPixels(colors);
    	mask.sprite.texture.Apply(false);
    }

    //This function will draw a circle onto the texture at position cx, cy with radius r
    public void DrawOnMask(int cx, int cy, int r)
    {
    	int px, nx, py, ny, d;
    
    	for (int x = 0; x <= r; x++)
    	{
    		d = (int)Mathf.Ceil(Mathf.Sqrt(r * r - x * x));

    		for (int y = 0; y <= d; y++)
    		{
    			px = cx + x;
    			nx = cx - x;
    			py = cy + y;
    			ny = cy - y;

    			colors[py + px] = new Color(1, 1, 1, 1);
    			colors[py + nx] = new Color(1, 1, 1, 1);
    			colors[ny + px] = new Color(1, 1, 1, 1);
    			colors[ny + nx] = new Color(1, 1, 1, 1);
    		}
    	}

    	mask.sprite.texture.SetPixels(colors);
    	mask.sprite.texture.Apply(false);
    }


    void Update() {

    	//Get mouse coordinates
    	Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    	//Check if mouse button is held down
    	if (Input.GetMouseButton(0))
    	{
    		//Check if we hit the collider
    		RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
    		if (hit.collider != null)
    		{              
    			//Normalize to the texture coodinates
    			int y = (int)((0.5 - (mask.transform.position - mousePosition).y) * height);
    			int x = (int)((0.5 - (mask.transform.position - mousePosition).x) * width);

    			//Draw onto the mask
    			DrawOnMask(x, y, radius);
    		}
    	}
    }
    }
