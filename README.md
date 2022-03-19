# OrdersExercise
Zadanie polegające na zaimplementowaniu i napisaniu testów jednostkowych dla składania zamówień (OrderService). Nie ma tutaj konsoli ani żadnego interfejsu użytkownika dlatego też zostają tylko testy. Główną (najwyższego rzędu) abstrakcją jest IOrderService. 

Większość modeli ma tylko nazwę i jest umieszczona w poprawnym katalogu. Wszystkie pola, property, metody - całą logikę trzeba napisać samemu. 

---

## Wymagane funkcjonalności:
- Składanie zamówienia
- Akceptacja zamówienia
- Odrzucenie zamówienia
- Anulowanie zamówienia
- Dodanie produktów do istniejącego zamówienia
- Pobranie zamówienia
- Wysłanie zamówienia
- Opłacenie zamówienia
- Zakończenie zamówienia
---
## klasy i ich odpowiedzialności
Nie wszystkie klasy są stworzone - będą miejsca gdze trzeba dodać nowe. Dla uproszczenia zadanie ma wydzielone interface dla najważniejszych zachowań.

| Nazwa | Opis |
| ----------- | ----------- |
| **warstwa aplikacji** |
| IOrderService | orkiestruje działaniami związanymi z zamówieniem |
| *Dto | data transfer object (kontrakty z frontendem) |
| **warstwa domeny** |
| IOrderRepository | Repozytorium zamówień |
| Order | Biznesowa reprezentacja zamówienia |
| IProductRepository | Repozytorium produktów |
| IStockChecker | Sprawdza, czy jest dostępna odpowiednia ilość produktu |
| Product | Biznesowa reprezentacja produktu |
| Sku | SKU (Stock keeping unit) identyfikator prodktu |
| **warstwa infrastruktury** |
| Turaj będą implementacje Repozytorów i IStockChecker |
---
## Kryteria akceptacji:
### 1. Składanie zamówienia:
Istotne zdarzenia:

- kiedy zamówienie zostało stworzone, 
- kto złożył zamówienie
- pod jaki adres musi zostać dostarczona przesyłka
- jaki przewoźnik został wybrany 

Reguły biznesowe:
- zamówienie nie może zostać złożone przez zablokowanego użytkownika
- zamówienie nie moze zostac złożone pod inny adress niż polski
- zamówienie nie może zostać złożone jeżeli nie ma wystarczającej ilości produktów,
- maksymalna wartość całkowitej zniżki nie może przekraczać 30% sumy zamówienia
- domyślny przewidywany czas dostawy to 2 dni, chyba że zamówienie jest z piątku (wtedy najszybciej dostarczymy we 
wtorek)
- jeżeli wartość zamówienia przekracza 1000, wymaga manualnej akceptacji. 
- jeżeli wartość zamówienia przekracza 1000 a użytkownik jest zablokowany - automatycznie odrzucaj takie zamówienie

obliczanie cen:

<img src="https://latex.codecogs.com/svg.image?kosztPrzejazdu&space;=&space;WyznaczaPrzewoznik">
<br>
<img src="https://latex.codecogs.com/svg.image?totalNet&space;=&space;(\sum&space;cenProduktowNet&space;-&space;znizkaNet)&space;&plus;&space;cenaPrzewozuNet">
<br>
<img src="https://latex.codecogs.com/svg.image?brutto&space;=&space;netto&space;*&space;1.2">

---
### 2. Akceptacja zamówienia:
Istatne zdarzenia:
- kiedy zamówienie zostało zaakceptowane

Reguły biznesowe:
- nie można zaakceptować zamówienia zablokowanemu użytkownikowi. 
- nie można zaakceptować nieopłaconego zamówienia
---
### 3. Odrzucenie zamówienia:
Istatne zdarzenia:
- kiedy zamówienie zostało odrzucone

Reguły biznesowe:
- każde zamówienie można odrzucić
---
### 4. Anulowanie zamówienia
Użytkownik może anulować swoje zamówienie

Istotne zdarzenia:
- kiedy zamówienie zostało anulowane

Reguły biznesowe:
- nie można anulowac zamówienia, które zostało już wysłane
---
### 5. Dodanie produktów do istniejącego zamówienia
Reguły biznesowe:
- nie można dodać produktów do zamówienia, które zostało wysłane
- nie można dodać produktów do zaakceptowanego zamówienia
---
### 6. Pobranie zamówienia
Pobranie zamówienia zgodnie z kontraktem:
```json
{
   "orderId":"",
   "createdDate":"",
   "accepted":true,
   "refused":true,
   "refuseReason":"",
   "status":"",
   "destinationAddress":{
      "country":"",
      "zipCode":"",
      "city":"",
      "street":"",
      "house":""
   },
   "estimatedDeliveryDate":"",
   "deliveryDate":"",
   "products":[
      {
         "sku":"",
         "name":"",
         "quantity":10,
         "discount":123.23,
         "priceNet":123.23,
         "priceGross":123.23
      },
      {
         "sku":"",
         "name":"",
         "quantity":10,
         "discount":123.23,
         "priceNet":123.23,
         "priceGross":123.23
      }
   ],
   "totalNetValue":123.23,
   "totalGrossValue":123.23,
   "totalNetDiscount":123.42,
   "totalGrossDiscount":123.42,
   "shippingNetValue":123.23,
   "shippingGrossValue":123.23,
   "canceledByUser":true,
   "cancelDate":"",
   "isPaid":true,
   "paymentDateTime":"",
   "paymentAmmount": 123.2
}
```
--- 
### 7. Wysłanie zamówienia
Istotne zdarzenia:
- kiedy zamówienie zostało wysłane
- jakim przewoźnkiem zostało wysłane

Reguły biznesowe:
- nie można wysłać nieopłaconego zamówienia,
- nie można wysłać niezaakceptowanego zamówienia,
- nie można wysłac anulowanego zamówienia
---
### 8. Opłacenie zamówienia
Istotne zdarzenia:
- kiedy zostało opłacone,
- jaka kwota,
- nr transakcji i bank,

Reguły biznesowe:
- nie można opłacić anulowanego zamówienia,
- można oplacić tylko nieoplacone zamówienie
---
### 9. Zakończenie zamówienia
Istotne zdarzenia:
- kiedy zostało dostarczone

Reguły biznesowe:
- zakończyć można tylko zlecenie, które zostało dostarczone. 

