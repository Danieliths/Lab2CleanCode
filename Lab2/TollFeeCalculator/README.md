# CleanCode---TollFeeCalculator
# Daniel Andersson
# Emil Martini

## Hänvisning till buggar lösta som ej var med i bedömning.
- **PrintTollCostTest()** => Output till konsol
- **DifferenceInMinuteTest()** => Skillnad i minuter mellan två tidpunkter. Buggen var DateTime.Minutes, ändrat till DateTime.TotalMinutes
- **AddDifferenceBetweenTollsTest()** => Test att lägga till mellanskillnaden i pris om flera entries kom inom loppet av en timma
- **IncreaseMaxFeePerDayTest()** => Ökar totala feens maxbelopp för varje dag.
- **TollFeeTest()** => Rätt kostnad för alla tider
