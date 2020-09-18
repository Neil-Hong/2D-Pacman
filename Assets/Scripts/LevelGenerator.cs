using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Sprite[] sprites;
    public Sprite outsideWall;
    public Sprite outsideCorner;
    public Sprite insideWall;
    public Sprite insideCorner;
    public Sprite tJunction;
    public int[,] Maze;
    int Vertical, Horizontal, Columns, Rows;
    
    
    void Awake()
    {
        //Sprite outSideCorner = Resources.Load("Outside Corner", typeof(Sprite)) as Sprite;
        //Sprite inSideWall = Resources.Load("Inside Wall", typeof(Sprite)) as Sprite;
       //Sprite inSideCorner = Resources.Load("Inside Corner", typeof(Sprite)) as Sprite;
        Vertical = (int)Camera.main.orthographicSize;
        Horizontal = Vertical * (Screen.width / Screen.height);
        Columns = Horizontal * 2;
        Rows = Vertical * 2;
        int[,] Maze =
     {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
    };
        int[,] Maze2 = new int[15,14];
        int[,] Maze3 = new int[15, 14];
        int[,] Maze4 = new int[15, 14];
        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                Maze2[i, j] = Maze[i, 14-1-j];
            }
        }
        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                Maze3[i, j] = Maze[15-1-i,j];
            }
        }
        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                Maze4[i, j] = Maze[15 - 1 - i, 14-1-j];
            }
        }

        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                GameObject g = new GameObject("x:" + i + "y: " + j);
                g.transform.position = new Vector3(j+14, -i-15);
                var s = g.AddComponent<SpriteRenderer>();
                switch (Maze4[i, j])
                {
                    case 0:
                        s.sprite = sprites[42];
                        break;
                    case 1:
                        s.GetComponent<SpriteRenderer>().sprite = sprites[4];
                        if (i == 5 && j == 13)
                        {
                            s.sprite = sprites[0];
                        }
                        else if (i == 1 && j == 8)
                        {
                            s.sprite = sprites[28];
                        }
                        else if (i == 5 && j == 8)
                        {
                            s.sprite = sprites[39];
                        }
                        break;
                    case 2:
                        s.sprite = sprites[2];
                        if (i == 0)
                        {
                            s.sprite = sprites[10];
                        }
                        else if (i == 5)
                        {
                            s.sprite = sprites[11];
                        }
                        else if (i==1 ||i == 14)
                        {
                            s.sprite = sprites[12];
                        }
                        break;
                    case 3:
                        if ((i==4||i==10) && (j==0))
                        {
                            s.sprite = sprites[36];
                        }
                        else if ((i==1||i==10||i==7)&& (j==3||j==6||j==11))
                        {
                            s.sprite = sprites[36];
                        }
                        else if ((i == 2 || i == 8 || i == 12) && (j == 3 || j == 6 || j == 11))
                        {
                            s.sprite = sprites[38];
                        }
                        else if ((i == 1 || i == 4 || i == 7||i==10) && (j == 2 || j == 8))
                        {
                            s.sprite = sprites[37];
                        }
                        else if (i == 1 && j == 5)
                        {
                            s.sprite = sprites[37];
                        }
                        else if ((i == 5 || i == 8 || i == 12 || i == 10) && (j == 2 ||j == 8))
                        {
                            s.sprite = sprites[39];
                        }
                        else if (i == 8 && j == 5)
                        {
                            s.sprite = sprites[39];
                        }
                        else if (i == 4 && j == 5)
                        {
                            s.sprite = sprites[35];
                        }
                        else if (i == 5 && j == 5)
                        {
                            s.sprite = sprites[33];
                        }
                        else if (i == 7 && j == 0)
                        {
                            s.sprite = sprites[34];
                        }


                        break;
                    case 4:
                        if ((i==5||i==6||i==11||i==12||i==13)&& j==0)
                        {
                            s.sprite = sprites[23];
                        }
                        else if ((i == 2||i==3||i==4||i==5||i==6||i==7||i==11) && (j == 6||j==11))
                        {
                            s.sprite = sprites[23];
                        }
                        else if ((i==2||i==3||i==6||i==7)&&j==5)
                        {
                            s.sprite = sprites[24];
                        }
                        else if (i==11 && (j==2||j==8))
                        {
                            s.sprite = sprites[24];
                        }
                        else if ((i == 0 || i == 1 ) && j == 3)
                        {
                            s.sprite = sprites[23];
                        }
                        else if ((i==4||i==7||i==10)&&(j==1||j==2||j==3||j==4||j==9||j==10))
                        {
                            s.sprite = sprites[14];
                        }
                        else if (i == 10 && j == 5)
                        {
                            s.sprite = sprites[14];
                        }
                        else if (i == 8 && (j==0||j==1||j==2||j==3||j == 9 || j == 10))
                        {
                            s.sprite = sprites[19];
                        }
                        else if ((i==5||i == 12) && (j == 3 || j == 4 || j == 5 || j == 9 || j == 10))
                        {
                            s.sprite = sprites[19];
                        }
                        else if (i==2 && (j==1||j==2))
                        {
                            s.sprite = sprites[19];
                        }

                        break;
                    case 5:
                        s.sprite = sprites[43];
                        break;
                    case 6:
                        s.sprite = sprites[44];
                        break;
                    case 7:
                        s.sprite = sprites[41];
                        break;
                    default:
                        break;
                }
            }
        }

        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                GameObject g = new GameObject("x:" + i + "y: " + j);
                g.transform.position = new Vector3(j, -i-15);
                var s = g.AddComponent<SpriteRenderer>();
                switch (Maze3[i, j])
                {
                    case 0:
                        s.sprite = sprites[42];
                        break;
                    case 1:
                        s.GetComponent<SpriteRenderer>().sprite = sprites[5];
                        if (i == 5 && j == 0)
                        {
                            s.sprite = sprites[1];
                        }
                        else if (i == 1 && j == 5)
                        {
                            s.sprite = sprites[27];
                        }
                        else if (i == 5 && j == 5)
                        {
                            s.sprite = sprites[29];
                        }
                        break;
                    case 2:
                        s.sprite = sprites[3];
                        if (i == 1)
                        {
                            s.sprite = sprites[12];
                        }
                        else if (i == 14)
                        {
                            s.sprite = sprites[12];
                        }
                        else if (j == 5)
                        {
                            s.sprite = sprites[3];
                        }
                        else if (i == 5 && (j==1||j==2||j==3||j==4))
                        {
                            s.sprite = sprites[11];
                        }
                        break;
                    case 3:
                        if (i==1 && j==5)
                        {
                            s.sprite = sprites[27];
                        }
                        else if (i==5 && j==0)
                        {
                            s.sprite = sprites[1];
                        }
                        else if ((i==1||i==7||i==10)&& (j==2||j==7||j==10))
                        {
                            s.sprite = sprites[37];
                        }
                        else if ((i == 4 || i == 10) && j==13)
                        {
                            s.sprite = sprites[37];
                        }
                        else if ((i == 2 || i == 8 || i == 12) && (j == 2 || j == 7||j==10))
                        {
                            s.sprite = sprites[39];
                        }
                        else if ((i == 4 || i == 7 || i == 10) && ( j == 5 || j == 11))
                        {
                            s.sprite = sprites[36];
                        }
                        else if (i == 1 && j == 8)
                        {
                            s.sprite = sprites[36];
                        }
                        else if ((i == 5 || i == 8 || i == 12) && (j == 5 || j == 11))
                        {
                            s.sprite = sprites[38];
                        }
                        else if (i==8&& j==8)
                        {
                            s.sprite = sprites[38];
                        }
                        else if (i==4 && j==8)
                        {
                            s.sprite = sprites[34];
                        }
                        else if (i == 5 && j == 8)
                        {
                            s.sprite = sprites[32];
                        }
                        else if (i == 7 && j == 13)
                        {
                            s.sprite = sprites[35];
                        }
                        break;
                    case 4:
                        if ((i==4||i==7||i == 10 )&& (j == 3 || j == 4 || j == 9 || j == 10 || j == 11 | j == 12))
                        {
                            s.sprite = sprites[14];
                        }
                        else if (i==10 && j==8)
                        {
                            s.sprite = sprites[14];
                        }
                        else if ((i == 8 || i == 12) && (j == 3 || j == 4 || j == 8 || j == 9 || j == 10||j==11||j==12))
                        {
                            s.sprite = sprites[19];
                        }
                        else if ((i==2||i==8) && (j==11||j==12||j==13))
                        {
                            s.sprite = sprites[19];
                        }
                        else if (i == 5 && (j == 9||j==10))
                        {
                            s.sprite = sprites[19];
                        }
                        else if ((i == 0 || i == 1) && j == 10)
                        {
                            s.sprite = sprites[24];
                        }
                        else if (i == 11 && (j == 5 || j == 11))
                        {
                            s.sprite = sprites[23];
                        }
                        else if ((i == 2 || i == 3 || i == 4 || i == 5 || i == 6 || i == 7||i==11||i==12||i==13) && (j == 7||j==12||j==13))
                        {
                            s.sprite = sprites[24];
                        }
                        else if ((i == 2 || i == 3 || i == 6 || i == 7) && j == 8)
                        {
                            s.sprite = sprites[23];
                        }
                        else if (i == 11 && j == 2)
                        {
                            s.sprite = sprites[24];
                        }
                        else if ((i == 13 || i == 14) && j == 10)
                        {
                            s.sprite = sprites[24];
                        }

                        break;
                    case 5:
                        s.sprite = sprites[43];
                        break;
                    case 6:
                        s.sprite = sprites[44];
                        break;
                    case 7:
                        s.sprite = sprites[40];
                        break;
                    default:
                        break;
                }
            }
        }

        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                GameObject g = new GameObject("x:" + i + "y: " + j);
                g.transform.position = new Vector3(j+14, -i);
                var s = g.AddComponent<SpriteRenderer>();
                switch (Maze2[i, j])
                {
                    case 0:
                        s.sprite = sprites[42];
                        break;
                    case 1:
                        s.GetComponent<SpriteRenderer>().sprite = sprites[0];
                        if (i == 9 && j == 13)
                        {
                            s.sprite = sprites[4];
                        }
                        else if (i == 9 && j == 8)
                        {
                            s.sprite = sprites[28];
                        }
                        else if (i == 13 && j == 8)
                        {
                            s.sprite = sprites[26];
                        }
                        break;
                    case 2:
                        s.sprite = sprites[2];
                        if (i == 0)
                        {
                            s.sprite = sprites[10];
                        }
                        else if (i == 9)
                        {
                            s.sprite = sprites[13];
                        }
                        else if (j == 5)
                        {
                            s.sprite = sprites[3];
                        }
                        else if (i == 13)
                        {
                            s.sprite = sprites[11];
                        }
                        break;
                    case 3:
                        if ((i == 2 || i == 6 || i == 12) && (j == 2 ||j==5|| j == 8 || j == 10))
                        {
                            s.sprite = sprites[37];
                        }
                        else if (i==9 && j==2)
                        {
                            s.sprite = sprites[37];
                        }
                        else if ((i == 4 || i == 7 || i==10||i == 13) && (j == 2 || j == 8 || j == 10))
                        {
                            s.sprite = sprites[39];
                        }
                        else if ((i == 2 || i == 9) && (j == 6 || j==11))
                        {
                            s.sprite = sprites[36];
                        }
                        else if (( i == 7 || i == 10) && (j == 3 || j == 11))
                        {
                            s.sprite = sprites[38];
                        }
                        else if ((i == 6 ||i==12)&& (j == 3||j==6||j==11))
                        {
                            s.sprite = sprites[36];
                        }
                        else if (i == 9 && j == 5)
                        {
                            s.sprite = sprites[35];
                        }
                        else if (i == 10 && j == 5)
                        {
                            s.sprite = sprites[33];
                        }
                        else if ((i == 4 || i==10||i==13)&& (j == 0||j==6||j==11))
                        {
                            s.sprite = sprites[38];
                        }
                        else if ((i == 4 || i == 13) && j == 5)
                        {
                            s.sprite = sprites[39];
                        }
                        else if (i == 7 && j == 0)
                        {
                            s.sprite = sprites[32];
                        }

                        break;
                    case 4:
                        if ((i == 2 || i == 6) && (j == 3 || j == 4 || j == 5 || j == 9 || j == 10 ))
                        {
                            s.sprite = sprites[14];
                        }
                        else if ((i == 6 ||i==12)&& (j == 0 || j == 1||j==2))
                        {
                            s.sprite = sprites[14];
                        }
                        else if (i == 6 && j == 13)
                        {
                            s.sprite = sprites[14];

                        }
                        else if ((i == 4 || i == 7||i ==10) && (j == 3 || j == 4 ||j == 9 || j == 10))
                        {
                            s.sprite = sprites[19];
                        }
                        else if (i == 4 && j == 5)
                        {
                            s.sprite = sprites[19];
                        }
                        else if (i == 3 && (j == 2 || j == 8))
                        {
                            s.sprite = sprites[24];
                        }
                        else if ((i == 8 ||i ==9)&& j==0)
                        {
                            s.sprite = sprites[23];
                        }
                        else if ((i == 7 || i == 8 || i == 11 || i == 12) && j == 5 )
                        {
                            s.sprite = sprites[24];
                        }
                        else if ((i == 1 || i == 2 || i == 3 || i==7||i==8||i==9||i==10||i==11||i==12) && (j == 0 || j ==6|| j==11))
                        {
                            s.sprite = sprites[23];
                        }
                        else if ((i==13||i==14)&& j==3)
                        {
                            s.sprite = sprites[23];
                        }
                        else if (i == 9 && (j == 3 || j == 4))
                        {
                            s.sprite = sprites[14];
                        }
                        else if (i == 7 && (j == 1 || j == 2))
                        {
                            s.sprite = sprites[19];
                        }
                        else if ((i == 1 || i == 2 || i == 3) && j == 13)
                        {
                            s.sprite = sprites[24];
                        }
                        else if ((i == 13 || i == 14) && j == 10)
                        {
                            s.sprite = sprites[24];
                        }

                        break;
                    case 5:
                        s.sprite = sprites[43];
                        break;
                    case 6:
                        s.sprite = sprites[44];
                        break;
                    case 7:
                        s.sprite = sprites[40];
                        break;
                    default:
                        break;
                }
            }
        }

        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                GameObject g = new GameObject("x:" + i + "y: " + j);
                g.transform.position = new Vector3(j, -i);
                var s = g.AddComponent<SpriteRenderer>();
                switch (Maze[i, j])
                {
                    case 0:
                        s.sprite = sprites[42];
                        break;
                    case 1:
                        s.GetComponent<SpriteRenderer>().sprite = sprites[1];
                        if (i == 9 && j == 0)
                        {
                            s.sprite = sprites[5];
                        }
                        else if (i == 9 && j == 5)
                        {
                            s.sprite = sprites[27];
                        }
                        else if (i == 13 && j == 5)
                        {
                            s.sprite = sprites[29];
                        }
                        break;
                    case 2:
                        s.sprite = sprites[3];
                        if (i == 0)
                        {
                            s.sprite = sprites[10];
                        }
                        else if (i == 9)
                        {
                            s.sprite = sprites[13];
                        }
                        else if (j == 5)
                        {
                            s.sprite = sprites[3];
                        }
                        else if (i == 13)
                        {
                            s.sprite = sprites[11];
                        }
                        break;
                    case 3:
                        if ((i == 2 || i==6||i==12)&& (j == 2||j ==7||j==10))
                        {
                            s.sprite = sprites[37];
                        }
                        else if ((i == 4 ||i==7 || i==13)&& (j == 2 || j == 7||j==10))
                        {
                            s.sprite = sprites[39];
                        }
                        else if ((i == 2 || i ==6 || i ==9)&& (j == 5 || j == 11))
                        {
                            s.sprite = sprites[36];
                        }
                        else if ((i == 4 || i==7|| i==10)&& (j == 5 || j == 11))
                        {
                            s.sprite = sprites[38];
                        }
                        else if (i==6 && j==8)
                        {
                            s.sprite = sprites[36];
                        }
                        else if (i == 9 && j ==8)
                        {
                            s.sprite = sprites[34];
                        }
                        else if (i == 10 && j == 8)
                        {
                            s.sprite = sprites[32];
                        }
                        else if (i ==13 && j ==8)
                        {
                            s.sprite = sprites[38];
                        }
                        else if ((i == 4 || i ==10)&& j == 13)
                        {
                            s.sprite = sprites[39];
                        }
                        else if (i==7 && j==13)
                        {
                            s.sprite = sprites[33];
                        }

                        break;
                    case 4:
                        if ((i==2 || i==6)&&(j ==3 || j==4 || j ==8 || j==9||j==10||j==11|j==12))
                        {
                            s.sprite = sprites[14];
                        }
                        else if (i==12 &&(j==11||j==12))
                        {
                            s.sprite = sprites[14];
                        }
                        else if (i ==6 && j==13)
                        {
                            s.sprite = sprites[14];

                        }
                        else if((i == 4 ||i==7)&& (j == 3 || j == 4 || j == 9 || j == 10||j==11||j==12))
                        {
                            s.sprite = sprites[19];
                        }
                        else if (i==4 && j==8)
                        {
                            s.sprite = sprites[19];
                        }
                        else if (i ==3 && (j ==2 || j ==7))
                        {
                            s.sprite = sprites[24];
                        }
                        else if (i == 3 && (j == 5 || j ==11))
                        {
                            s.sprite = sprites[23];
                        }
                        else if ((i==7 || i==8||i ==9 ||i==10||i==11||i==12)&&(j==7||j==13))
                        {
                            s.sprite = sprites[24];
                        }
                        else if ((i == 7 || i == 8 || i == 11 || i == 12) && j == 8)
                        {
                            s.sprite = sprites[23];
                        }
                        else if (i ==9 && (j==9||j==10))
                        {
                            s.sprite = sprites[14];
                        }
                        else if (i == 10 && (j == 9 || j == 10))
                        {
                            s.sprite = sprites[19];
                        }
                        else if ((i == 1 || i == 2 || i == 3 ) && j == 13)
                        {
                            s.sprite = sprites[24];
                        }
                        else if ((i==13||i==14) && j ==10)
                        {
                            s.sprite = sprites[24];
                        }

                        break;
                    case 5:
                        s.sprite = sprites[43];
                        break;
                    case 6:
                        s.sprite = sprites[44];
                        break;
                    case 7:
                        s.sprite = sprites[41];
                        break;
                    default:
                        break;
                }
            }
        }
    }
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {

    }
}
