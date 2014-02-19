Projects from computer graphics

sortowanie krawedziowe
algorytm liang-barsky do obcinania wielokata prostokatem (mozliwosc pracy krok po kroku)
przycisk wypelnij 
rozszezyc o wypelnianie wzorem

#include <windows.h> #include <math.h> void LiangBarsky(RECT rcClip, POINT* ptA, POINT* ptB) { float t0, t1, R, dx, dy, P, q; unsigned char k; t0 = 0; t1 = 1; dx = ptB->x - ptA->x; dy = ptA->y - ptB->y; for(k = 1; k <= 4; k++) { switch(k) { 
case 1: { // lewo P = -dx; q = ptA->x - rcClip.left; break; } 
case 2: { // prawo P = dx; q = rcClip.right - ptA->x; break; } 
case 3: { // dol P = -dy; q = rcClip.bottom - ptA->y; break; } 
case 4: { // gora P = dy; q = ptA->y - rcClip.top; } } 
if((P != 0) || (q != 0)) {
 if(P != 0) { 
 R = q / P; 
 if(P > 0) { 
 if(R > t0) { 
 t1 = min(t1, R); 
 } else 
 return; 
 } else { 
 if(R < t1) { t0 = max(t0, R); } else return; } } else continue; } else return; } 
 ptB->x = lroundf(ptA->x + t1 * dx); 
 ptB->y = lroundf(ptA->y - t1 * dy); 
 ptA->x = lroundf(ptA->x + t0 * dx); 
 ptA->y = lroundf(ptA->y - t0 * dy); } 