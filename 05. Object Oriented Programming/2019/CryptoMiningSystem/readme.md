# CryptoMiningSystem

## Преглед на задачата
Напишете програма, симулираща система за потребители, които практикуват така нареченото "копаене" на криптовалута. Всеки потребител е инвестирал в различна конфигурация на един компютър. След създаването на компютър, ще ги пускате да "копаят" и ще следите дневните им приходи.

# Problem 1. Структура

## User
Всеки потребител има име, пари, звезди и компютър:
- **Name** = символен низ
- **Stars** = цяло число
- **Money** = реално число
- **Computer** = параметър от тип Computer

Имената на потребителите не трябва да бъдат null или празен стринг. Съобщение: **Username must not be null or empty!**

Парите на потребителя не може да са отрицателни. Съобщение: **User's money cannot be less than 0!**

Звездите на потребителя се изчисляват по формулата: **Stars  = user's money / 100**

При подаване на невалидна стойност хвърлете изключение ArgumentException с конкретното съобщение.

## Computer
Всеки компютър има процесор, видео карта, рам памет и блокова награда:
- **Processor** = параметър от тип Processor
- **VideoCard** = параметър от тип VideoCard
- **Ram** = цяло число
- **MinedAmountPerHour** = реално число

Минималната стойност на рам паметта е 0, а максимална - 32.
Съобщение: **PC Ram cannot be less or equal to 0 and more than 32!**

MinedAmountPerHour се изчислява по следната формула:
**{Video card's mined money per hour} * {Processor's mined multiplier}**

При подаване на невалидна стойност хвърлете изключение – ArgumentException с конкретното съобщение.

## Components
Всеки тип компонент има модел, цена, генерация и работен живот.
- **Model** = символине низ
- **Price** = реално число
- **Generation** = цяло число
- **LifeWorkingHours** = цяло число

Всеки модел на компнента не трябва да е null  или празен стринг. Съобщение: **Model cannot be null or empty!**

Цената на един компонент не трябва да е отрицателна или по – голяма от 10000. Nothing is for free!!! Съобщение: **Price cannot be less or equal to 0 and more than 10000!**

Всеки компонент има генерация, започваща от 1. Съобщение: **Generation cannot be 0 or negative!**

При подаване на невалидна стойност хвърлете изключение – ArgumentException с конкретното съобщение.

## Processor
Всеки процесор има множител на придобитите пари:
- **MineMultiplier** = цяло число
- **LifeWorkingHours** се изчислява по следната формула: **{Generation} * 100**

Никой процесор не може да има генерация по – голяма от 9.
Съобщение: **{processorType} generation cannot be more than 9!**

При подаване на невалидна стойност хвърлете изключение – ArgumentException с конкретното съобщение.

### LowPerformanceProcessor
LowPerformanceProcessor има стойност на MineMultiplier равна на 2.

### HighPerformanceProcessor
HighPerformanceProcessor има стойност на MineMultiplier равна на 8.

## VideoCard
Всяка видео карта има рам памет и количество пари изкарвани на час:
- **Ram** = цяло число
- **MinedMoneyPerHour** = реално число

Всяка видео карта притежава стойност на рам паметта в диапазона 0 > RAM <= 32. Съобщение: **{videoCardType} ram cannot less or equal to 0 and more than 32!**

MinedMoneyPerHour се изчислява по следната формула: **{RAM} * {Generation} / 10**

LifeWorkingHours се изчислява по следната формула: **{RAM} * {Generation} * 10**

При подаване на невалидна стойност хвърлете изключение – ArgumentException с конкретното съобщение.
Генерацията на картата не може да бъде по – голяма от 9.

### GameVideoCard
- Съобщение: Game video card generation cannot be more than 9!
- MinedMoneyPerHour се увеличава с 100%
- При подаване на невалидна стойност хвърлете изключение – ArgumentException с конкретното съобщение.
- Генерацията на картата не може да бъде по – голяма от 6.

### MineVideoCard
- Съобщение: Mine video card generation cannot be more than 6!
- MinedMoneyPerHour се увеличава с 700%.
- LifeWorkingHours се увеличава с 100%.
- При подаване на невалидна стойност хвърлете изключение – ArgumentException с конкретното съобщение.

# Problem 2. Бизнес логика

## The Controller Class
Бизнес логиката на програмата трябва да бъде концентрирана около няколко команди. Внедрете клас, наречен **PCController**, който ще притежава главната функционалност, представена от тези публични методи:

```
public string RegisterUser(List<string> args)
public string CreateComputer(List<string> args)
public string Mine()
public string UserInfo(List<string> args)
public string Shutdown()
```

ЗАБЕЛЕЖКА: Не трябва да променяте нищо по методите. Трябва да имплементирате логиката на самите методи. Не прихвайщайте никакви изключения.

## Команди
Има няколко команди, които контролират бизнес логиката на приложението и трябва да ги имплементирате.

### RegisterUser Команда
Създава потребител и го регистрира в системата. В случай, че потребител с това име вече съществува, просто го пропуснете.

Параметри:
- **name** = символен низ
- **money** = реално число

### CreateComputer Команда
Създава компютър на даден потребител. В случай, че потребителят може да си плати, компютъра се запазва при него. Не всички данни ще бъдат валидни!!!

Параметри:
- **name** = символен низ
- **processorType** = символен низ
- **processorModel** = символен низ
- **processorGeneration** = цяло число
- **processorPrice** = реално число
- **videoCardType** = символен низ
- **videoCardModel** = символен низ
- **videoCardGeneration** = цяло число
- **videoCardRam** = цяло число
- **videoCardPrice** = реално число
 
### Mine Команда
При тази команда всички потребители, които могат, настройват компютрите си да "копаят" за 1 ден. Съберете общата стойност от всички компютри и я запазете в системата.

За всеки потребител трябва да изпълните действията по–долу:

1. Изчислете "изкопаните" пари от компютъра.
2. Намалете живота на процесора с 1 ден.
3. Намалете живота на видео картата с 1 ден.
4. Увеличете парите на потребителя с "изкопаните" пари.
5. Добавете "изкопаните" пари към дневния отчет.

### UserInfo Команда
Тази команда изкарва информация за един потребител.

Параметри:
- **name** = символен низ. Ако потребител с това име не съществува, нищо не се случва.

### Shutdown Команда
Тази команда прекратява изпълнението на програмата и връща всички потребители, подредени по техните звезди в намаляващ ред и след това по име в нарастващ ред.

# Problem 3. Вход / Изход

## Вход
Четете редове с различни команди, докато не получите команда за приключване на програмата.
По-долу можете да видите формата, в който всяка команда ще бъде дадена във входа:

```
RegisterUser {name} {money}
CreateComputer {userName} {processorType} {processorModel} {processorGeneration} {processorPrice} {videoCardType} {videoCardModel} {videoCardGerenation} {videoCardRam} {videoCardPrice}
Mine
UserInfo {name}
Shutdown
```

## Изход
По–долу може да видите кой изход трябва да бъде предоставен от командите.

### RegisterUser Команда
При успешно регистриране на потребител: **Successfully registered user – {name}!**

В противен случай: **Username: {name} already exists!**

### CreateComputer Команда
При успешно създаване на компютъра: **Successfully created computer for user: {name}!**

В случай на невалидни данни: 
- Невалидно име на потребител: **Username: {name} does not exist!**
- Невалиден тип процесор: **Invalid type processor!**
- Невалиден тип видео карта: **Invalid type video card!**

В случай, че финансовите средства на потребителя не са достатъчни за компютърната конфигурация: **User: {name} - insufficient funds!**

### Mine Команда
След завършване на командата, трябва да върнете отчета за деня в следния формат: **Daily profits: {dailyProfits}!**

### UserInfo Команда
След завършването на командата, трябва да върнете информация за потребителя, ако той съществува, в следния формат:
```
Name: {name} - Stars: {stars}
Balance: {balance}
```

В случай, че потребителя си е направил конфигурация добавете:
```
PC Ram: {PC ram}
- {processorType} – {processorModel} – {processorGeneration}
- {videoCardType} – {videoCardModel} – {videoCardGeneration}
* Video card Ram: {videoCardRam}
```

При получаване на не регистрирано потребителско име: **Username: {name} does not exist!**

### Shutdown Команда
След завършване на командата трябва да върнете информация за всички потребители във формата, описан в UserInfo командата, и накрая добавете:
**System total profits: {totalSystemProfits}!!!**

## Ограничения
Името на потребителя ще бъде символен низ, който може да съдържа всеки ASCII символ, с изключение на интервал и запетая. Имената на потребителите винаги ще бъдат уникални. Винаги ще получавате команда за приключване на програмата. Входните данни ще бъдат валидни от страна на типове данни.
