# Tävling: Pepparkakstorn – Regler

## Del 1: Byggmoment
Målet är att bygga ett så högt och så snyggt pepparkakstorn som möjligt med det material alla lag har fått tillhanda: pepparkakor, smältlim, limpistol, kristyr och skumtomtar.

Poäng för höjd:
- Varje centimeter = 1 poäng (t.ex. 80 cm = 80 poäng).
- Bonus: Om tornet överstiger 50 cm tilldelas laget +50 bonuspoäng.

Poäng för design:
- Okej design: 50 poäng  
- Bra design: 100 poäng  
- Jättebra design: 150 poäng

## Del 2: Duellmoment
Lagen turas om att kasta diskar mot motståndarlagets torn. Avstånd cirka 5–10 m.  
Duellpar:
- 1 <-> 2  
- 3 <-> 4  
- 5 <-> 6  
- 7 <-> 8

Varje lag får 10 kast.  
Varje träff ger 20 poäng.  
Efter duellen mäts tornen på nytt och höjdpoäng delas ut enligt samma system som i Del 1.

## Vinst
När båda momenten är avslutade summeras lagens totalpoäng. Laget med högst poäng vinner.

## Exempel (förtydligande)
DEL 1 — LAG Y:
- Höjd 88 cm → 88p + 50p bonus = 138p  
- Bra design → 100p  
- Totalt Del 1 = 238p

DEL 1 — LAG X:
- Höjd 48 cm → 48p  
- Jättebra design → 150p  
- Totalt Del 1 = 198p

DEL 2:
- Lag X träffar 4 gånger → 4 * 20p = 80p; kvarstående höjd på motståndare 40 cm = 40p  
- Lag Y träffar 3 gånger → 3 * 20p = 60p; kvarstående höjd på motståndare 10 cm = 10p

Totalt:
- Lag Y = 238 + (60 + 10) = 308p  
- Lag X = 198 + (80 + 40) = 318p → Vinnare Lag X

## Filformat och ordning
`pepparkakstornet/scores.txt` ska vara komma-separerad (CSV). Varje data-rad ska följa ordningen:

ORDNING: Lag, Del1Höjd, Del1Design, Del2Träffar, Del2Höjd
