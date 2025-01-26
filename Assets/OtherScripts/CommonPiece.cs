using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPieceObject
{
    int getMax();
    void getPieceValue(out int tempUp, out int tempDown, out int tempLeft, out int tempRight);
    void rotatePiece();
    int getRotatePhase();
    bool mountain();
    bool getAvailable();
    void setUnavailable();
    void setIndex(int value);
    int getIndex();
    bool getMaterial();
    void setMaterial();
    void resetK();
    int getSupport();
    void setSupport(int value);
    Vector3 GetCoordinates();
}


