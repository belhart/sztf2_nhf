Bútorraktár


ADATOK.TXT formátum:
 
BÚTORFAJTA     SZÉLESSÉG MAGASSÁG HOSSZÚSÁG 

ALLO|NORM|ALA       int       int    int
példa: a már létező adatok.txt a debug mappában


Egy bútorraktár számára készítünk alkalmazást.
1. A raktárban eltárolt bútorok téglatest alakú dobozokban vannak. Mindegyik
doboznak van szélessége, hosszúsága és magassága.
2. A bútorok az alábbi módon osztályozhatók:
 Normál bútor. Az ilyen bútorokat a legkisebb alapterületű lapjára fordítva
helyezzük el a raktárban.
 Álló bútor. Az ilyen bútorokat csak az alaplapjukra állítva helyezhetjük el a
raktárban.
 Alacsony bútor. Az alaplapjára helyezve állítjuk a raktárbeli helyére. Olyan
alacsony, hogy más bútorok ráhelyezhetők.
3. A raktárban elhelyezendő bútorokat visszalépéses kereséssel helyezze el az adott
alapterületű és magasságú raktárban.
4. Amikor a raktárból kihozunk bútort, akkor a kicipeléshez szabad utat kell
biztosítani, ezért más bútorok kicipelése is indokolt. Ilyen esetben a kicipelt
bútorok úgy kerülnek vissza a felszabadult helyre, hogy a lehető legoptimálisabb
legyen a térkitöltésük. A kicipelt bútorok új helyéről egy eseménnyel értesítjük a
raktárvezetőt.
5. Amennyiben egy új bútornak nem találunk helyet a raktárban, akkor kivételt
dobunk erről. Ez a kivétel maga után az egész raktár újrarendezését.
6. Ha egy új bútor nem fér el a raktárban, akkor kivételt dobunk erről is, és
átvitetjük a bútort egy másik raktárba.
