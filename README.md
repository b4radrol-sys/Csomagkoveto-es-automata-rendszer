
# 📦 Csomagautomata rendszer

## A programról

A program egy csomagautomata működését szimulálja. Segítségével csomagokat lehet feladni, átvenni és nyomon követni, valamint a futár módosíthatja a csomagok állapotát.

## Funkciók

| Menü | Funkció | Leírás |
| :--- | :--- | :--- |
| 0 | Kilépés | Kilépés a programból. |
| 1 | Új csomag feladása | Csomag regisztrálása a címzett nevével és méretével. |
| 2 | Csomag átvétele | Csomag átvétele a követési szám és a PIN-kód segítségével. |
| 3 | Csomagkövetés | A csomag aktuális állapotának és eseményeinek megtekintése. |
| 4 | Csomag állapotának megváltoztatása (futár) | A csomag állapotának módosítása. |

## Használat
A program indításakor a következő főmenü jelenik meg:
```text
=========================================
   CSOMAGAUTOMATA & KÖVETŐ RENDSZER
=========================================

0. Kilépés
1. Új csomag feladása
2. Csomag átvétele
3. Csomagkövetés
4. Csomag állapotának megváltoztatása (futár)
Válassz menüpontot:
```

### 1. Új csomag feladása

Új csomag regisztrálásához meg kell adni a címzett nevét és a csomag méretét (S, M vagy L).
**Példa terminálkimenet:**

```text
Válassz menüpontot: 1

--- 1. ÚJ CSOMAG FELADÁSA (0: Vissza a főmenübe) ---
Címzett neve: Kiss Anna
Csomag mérete (S / M / L): 0
Visszalépés a főmenübe...

Válassz menüpontot: 1

--- 1. ÚJ CSOMAG FELADÁSA (0: Vissza a főmenübe) ---
Címzett neve: Kiss Anna
Csomag mérete (S / M / L): M
Csomag regisztrálva! Követési szám: CSG-1001 | Állapot: Feladva
```

A sikeres regisztráció után a rendszer egy egyedi követési számot rendel a csomaghoz.

### 2. Csomag átvétele

A címzett a követési szám és a hozzá tartozó négyjegyű PIN-kód segítségével veheti át a csomagot az automatából.

A `0` érték megadásával vissza lehet lépni a főmenübe.

**Példa terminálkimenet:**

```text
Válassz menüpontot: 2

--- 2. CSOMAG ÁTVÉTELE (0: Vissza a főmenübe) ---
Követési szám: CSG-1001
4 jegyű nyitókód (PIN): 4829
Sikeres átvétel! A(z) #02-es rekesz kinyílt, a csomag átvéve.
```

Sikeres PIN-kód megadása után az automata kinyitja a csomagot tartalmazó rekeszt, és a csomag átvett állapotba kerül.

### 3. Csomagkövetés

A követési szám megadásával megtekinthető a csomag aktuális állapota és az eddig rögzített eseményei.

A `0` érték megadásával vissza lehet lépni a főmenübe.

**Példa terminálkimenet:**

```text
Válassz menüpontot: 3

--- 3. CSOMAGKÖVETÉS (0: Vissza a főmenübe) ---
Követési szám: CSG-1001

Csomag: CSG-1001 | Címzett: Kiss Anna | Méret: M
Aktuális állapot: Automatában (#02-es rekesz)
Eseménynapló:
2026-11-23 10:35:10 - Csomag feladva
2026-11-23 10:35:24 - Automatába helyezve (#02-es rekesz)
```

A rendszer megjeleníti a csomag legfontosabb adatait, aktuális állapotát és az eseménynaplóban szereplő korábbi műveleteket.

### 4. Csomag állapotának megváltoztatása (futár)

A futár ezen a menüponton keresztül módosíthatja a csomag állapotát a követési szám megadásával.

A rendszer megjeleníti a csomag jelenlegi állapotát, majd a futár kiválaszthatja az új állapotot:

- **1. Szállítás alatt**
- **2. Automatába helyezve**
- **3. Lejárt / Visszaküldve**
- **0. Vissza a főmenübe**

Automatában történő elhelyezéskor a rendszer rekeszt rendel a csomaghoz, és generál egy négyjegyű PIN-kódot.

**Példa terminálkimenet:**

```text
Válassz menüpontot: 4

--- 4. CSOMAG ÁLLAPOTÁNAK MEGVÁLTOZTATÁSA (0: Vissza a főmenübe) ---
Követési szám: CSG-1001
Jelenlegi állapot: Feladva
  1. Kiszállítás alatt
  2. Kiszállított
  3. Elutasított
Új állapot sorszáma: 2
Csomag az automatába helyezve (#02-es rekesz). Nyitókód (PIN): 4829
```

### 📏 Csomagméretek

A rendszer három csomagméretet kezel:

- **S** – Kis csomag
- **M** – Közepes csomag
- **L** – Nagy csomag

## 💾 Adatmentés

A program a csomagok adatait a `csomagok.csv` fájlban tárolja.
