using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class around : MonoBehaviour
{
    public int a(int idHex, int looks, int far)
    {
        //zwraca id elementu, na kt�ry si� patrzy
        switch (idHex)
        {
            case 1:
                switch (looks)
                {
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 2;
                            case 1:
                                return 4;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 5;
                            case 1:
                                return 10;
                            case 2:
                                return 15;
                            case 3:
                                return 19;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 3;
                            case 1:
                                return 6;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 2:
                switch (looks)
                {
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 4;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 7;
                            case 1:
                                return 12;
                            case 2:
                                return 17;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 5;
                            case 1:
                                return 8;
                            case 2:
                                return 11;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 1;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 3:
                switch (looks)
                {
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 1;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 5;
                            case 1:
                                return 7;
                            case 2:
                                return 9;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 8;
                            case 1:
                                return 13;
                            case 2:
                                return 18;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 6;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 4:
                switch (looks)
                {
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 9;
                            case 1:
                                return 14;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 7;
                            case 1:
                                return 10;
                            case 2:
                                return 13;
                            case 3:
                                return 16;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 2;
                            case 1:
                                return 1;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 5:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 1;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 2;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 7;
                            case 1:
                                return 9;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 10;
                            case 1:
                                return 15;
                            case 2:
                                return 19;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 8;
                            case 1:
                                return 11;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 3;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 6:
                switch (looks)
                {
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 3;
                            case 1:
                                return 1;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 8;
                            case 1:
                                return 10;
                            case 2:
                                return 12;
                            case 3:
                                return 14;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 11;
                            case 1:
                                return 16;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 7:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 2;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 4;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 9;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 12;
                            case 1:
                                return 17;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 10;
                            case 1:
                                return 13;
                            case 2:
                                return 16;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 5;
                            case 1:
                                return 3;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 8:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 3;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 5;
                            case 1:
                                return 2;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 10;
                            case 1:
                                return 12;
                            case 2:
                                return 14;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 13;
                            case 1:
                                return 18;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 11;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 6;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 9:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 4;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 14;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 12;
                            case 1:
                                return 15;
                            case 2:
                                return 18;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 7;
                            case 1:
                                return 5;
                            case 2:
                                return 3;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 10:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 5;
                            case 1:
                                return 1;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 7;
                            case 1:
                                return 4;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 12;
                            case 1:
                                return 14;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 15;
                            case 1:
                                return 19;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 13;
                            case 1:
                                return 16;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 8;
                            case 1:
                                return 6;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 11:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 6;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 8;
                            case 1:
                                return 5;
                            case 2:
                                return 2;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 13;
                            case 1:
                                return 15;
                            case 2:
                                return 17;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 16;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 12:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 7;
                            case 1:
                                return 2;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 9;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 14;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 17;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 15;
                            case 1:
                                return 18;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 10;
                            case 1:
                                return 8;
                            case 2:
                                return 6;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 13:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 8;
                            case 1:
                                return 3;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 10;
                            case 1:
                                return 7;
                            case 2:
                                return 4;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 15;
                            case 1:
                                return 17;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 18;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 16;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 11;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 14:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 9;
                            case 1:
                                return 4;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 17;
                            case 1:
                                return 19;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 12;
                            case 1:
                                return 10;
                            case 2:
                                return 8;
                            case 3:
                                return 6;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 15:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 10;
                            case 1:
                                return 5;
                            case 2:
                                return 1;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 12;
                            case 1:
                                return 9;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 17;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 19;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 18;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 13;
                            case 1:
                                return 11;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 16:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 11;
                            case 1:
                                return 6;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 13;
                            case 1:
                                return 10;
                            case 2:
                                return 7;
                            case 3:
                                return 4;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 18;
                            case 1:
                                return 19;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 17:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 12;
                            case 1:
                                return 7;
                            case 2:
                                return 2;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 14;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 19;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 15;
                            case 1:
                                return 13;
                            case 2:
                                return 11;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 18:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 13;
                            case 1:
                                return 8;
                            case 2:
                                return 3;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 15;
                            case 1:
                                return 12;
                            case 2:
                                return 9;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 19;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 16;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 19:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 15;
                            case 1:
                                return 10;
                            case 2:
                                return 5;
                            case 3:
                                return 1;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 17;
                            case 1:
                                return 14;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 18;
                            case 1:
                                return 16;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            default:
                return 0;
        }
    }
}
