# Szamitogep-biztonsag-VIHIMA06
Számítógép-biztonság (VIHIMA06) - Házi feladat

# Házi feladat
## Általános leírás
A félév során egy open source alkalmazást kell elkészíteni csapatokban. A projekt célja a tanult módszerek alkalmazása a gyakorlatban, egy biztonságkritikus szoftver teljes tervezési, fejlesztési, és tesztelési folyamatának az elvégzése. Egy olyan online áruházat kell készíteni, amiben egyedi formátumú animált képeket lehet böngészni. A szoftvernek a CAFF (CrySyS Animated File Format) formátumot kell támogatnia. A teljes rendszer kell, hogy tartalmazzon egy HTTP(S) protokollon elérhető távoli szolgáltatást, valamint az ahhoz tartozó webes vagy mobil klienst.

# Felhasznált formátumok:

- CAFF fájlformátum
  - tömörítés nélküli animációformátum
  - CIFF képek tárolására alkalmas
  - az animációhoz tartozó metaadatokat tárolja
  - Példa fájlok a teszteléshez
- CIFF fájlformátum
  - tömörítés nélküli képformátum
  - pixel informácikat tartalmaz
  - a képhez tartozó metaadatokat tárolja

# Követelmények:

- Funkcionalitás
  - felhasználóknak kell tudni regisztrálni és belépni
  - felhasználóknak kell tudni CAFF fájlt feltölteni, letölteni, keresni
  - felhasználóknak kell tudni CAFF fájlhoz megjegyzést hozzáfűzni
  - a rendszerben legyen adminisztrátor felhasználó, aki tud adatokat módosítani, törölni
- Szerver oldali funkciókövetelmények
  - CAFF feldolgozási képesség
  - teljesítménymegfontolásokból C/C++ nyelven kell implementálni
  - feladat: a CAFF fájlból egy előnézet generálása a webshopban megjelenítéshez
- Kliens oldali követelmények
  - vagy egy webes vagy iOS vagy Android implementáció

A félév során a projektet folyamatosan verziókövetve githubon kell fejleszteni. Az egyes mérföldkövek beadása az elkészült commithoz tartozó link leadása lesz a moodle rendszerben. 3 (+1) fázisban lesz a beadás.

# Csapatok
A feladatot 4-5 fős csapatokban kell elvégezni. Javasoljuk, hogy úgy álljanak össze a tagok, hogy lehetőleg a szükséges technológiák mindegyikét valaki ismerje. A kialakított csapatok névsorát a kari Moodle rendszerben, a tárgy oldalán, az erre kijelölt beadófelületen kell beadni a második oktatási hét végéig.

## Határidő
2022.09.21.

# Tervezés
Az első fázis során a tervezésen van a hangsúly. Ebben a részben a rendszer architektúraterveit kell elkészíteni. A beadáskor az SDL folyamat requirements és design fázisaihoz tartozó dokumentumokat, valamint egy tesztelési tervet kell leadni. Ezeket az anyagokat a projekt wiki oldalán kell elkészíteni. (A beadás a wiki git commit.)

## Határidő
2022.10.19.

# Natív komponens
A második fázisban a szerver oldali komponensek közül a natív nyelven implementált C/C++ parsert kell leadni a hozzá tartozó Makefile-lal együtt.

## Határidő
2022.11.09.

# Implementáció és tesztelés
A harmadik fázis a végleges projektleadás. Ekkorra a rendszer egészének működőképesnek kell lennie (gitben), és az ehhez tartozó dokumentumoknak is el kell készülniük (wikiben). A projektet a félév végén be kell mutatni működés közben. A leadás előtt várunk egy felosztást (százalékban), hogy melyik csapattag mennyit dolgozott a projekten, ami alapján a végső pontszámból részesülni fog.

## Határidő
2022.12.04.

# Demo
A félév végén minden csapatnak be kell mutatnia az elkészült alkalmazást. A demón friss tesztinputokat is kapnak a csapatok, és megnézzük, hogy jól kezeli-e azokat a programjuk. A demóra az utolsó előadás órarendi idejében kerül sor, és Teams-en keresztül fog zajlani.

## Határidő
2022.12.07.
