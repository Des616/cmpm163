using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildCity : MonoBehaviour
{
    public GameObject[] buildings;
    public GameObject xStreets;
    public GameObject zStreets;
    public GameObject crossroad;
    public GameObject pond;
    public int mapWidth = 20;
    public int mapHeight = 20;
    public int buildingFootprint = 3;
    int[,] mapgrid;
    void Start()
    {
    	mapgrid = new int[mapWidth,mapHeight]; //initializing it to be a 2d array width of map by height
    	float seed = Random.Range(1.0f,100f);
        for(int h = 0; h < mapHeight; h++)
        {
        	for(int w = 0; w<mapWidth; w++)
        	{
        		
        		mapgrid[w,h]= (int) (Mathf.PerlinNoise(w/10.0f + seed,h/10.0f + seed) * 100);
           	}

        }

        //build streets
        int x =0;

        for(int n = 0; n < 50; n++){
        	for(int h = 0; h < mapHeight; h ++){
        		mapgrid[x,h] = -1;
        	}
        	x+= Random.Range(3,3);
        	if(x>= mapWidth) break;
        }
         int z =0;

        for(int n= 0; n < 50; n++){
        	for(int w = 0; w< mapWidth; w ++){
        		
        		if(mapgrid[w,z] == -1){
        			mapgrid[w,z] = -3;
        		}
        		else{
        			mapgrid[w,z] = -2;
        		}
        		        		
        	}
        	z+= Random.Range(2,20);
        	if(z>= mapHeight) break;
        }



        //draw everything
        for(int h = 0; h < mapHeight; h++)
        {
        	for(int w = 0; w<mapWidth; w++)
        	{        
        		int result = mapgrid[w,h];
        		Vector3 pos = new Vector3(w * buildingFootprint ,0,h * buildingFootprint);
        		if(result <-2){
        		Instantiate(crossroad,pos,crossroad.transform.rotation);
        		}
        		else if(result <-1){
        		Instantiate(xStreets,pos,xStreets.transform.rotation);
        		}
        		else if(result <0){
        		Instantiate(zStreets,pos,zStreets.transform.rotation);
        		}
        		else if(result <20){
        		Instantiate(buildings[0],pos,Quaternion.identity);
        		}
        		else if(result < 35){
        			Instantiate(buildings[1],pos,Quaternion.identity);
	       		}
	       		else if(result < 46){
        			Instantiate(buildings[2],pos,Quaternion.identity);
       			}
       			else if(result < 54){
        			Instantiate(buildings[3],pos,Quaternion.identity);
       			}
       			else if(result < 63){
        			Instantiate(buildings[4],pos,Quaternion.identity);
        			float pondChance = Random.Range(0f,10f);
        			if(pondChance > 8.0){
         				Instantiate(pond,new Vector3(pos.x,pos.y+0.1f,pos.z), Quaternion.identity);
        			}
       			}
       			
       			else if(result < 72){
        			Instantiate(buildings[6],pos,Quaternion.identity);
       			}
       			else {
	       			Instantiate(buildings[8],pos,Quaternion.identity);
	       			
      			}
      			
      		}
   		 }
   	}

}
