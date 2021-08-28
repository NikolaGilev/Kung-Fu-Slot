# Kung Fu Slot

Kung Fu Slot апликацијата е виртуелна слот машина која е составена 18 линии на исплата, а со тоа има доволно комбинации кои можат играчот да го усреќат. Позадината, сликите и музиката се инспирани од анимираните филмови Kung Fu Panda, па ако сте нивни обожавател оваа игра е токму за вас. Слот машината освен бројните линии за исплаќање се карактеризира и со чести “Free Spins Bonus”  бесплатни вртења кои му нудат на играчот да освојат големи добивки кога ќе се предизвикаат импресивни бонуси.

---
### Содржина

- [Изглед, функционалност и цел на играта](#изглед-функционалност-и-цел-на-играта)
- [Повеќе Информации](#повеќе-информации)
- [Линии на исплата](#линии-на-исплата)
- [Бонус Вртења](#бонус-вртења)
  - [Погодок на бонус вртења](#погодок-на-бонус-вртења) 
  - [Купување на бонус вртења](#купување-на-бонус-вртења)
  - [Бонус ниво](#бонус-ниво)
- [Прекин на сесија](#прекин-на-сесија) 
- [Музика](#музика)
- [Изворен код](#изворен-код)
- [Информации за авторите](#информации-за-авторите)
---

## Изглед, функционалност и цел на играта

При стартување на апликацијата се отвара почетниот прозорец и со клик на копчето “Start New Session” се започнува нова игра:

![image](https://user-images.githubusercontent.com/80510786/131215495-e401d8b4-edfb-4a2e-ab63-91de220b2169.png)

Изглед на слот машината:

![image](https://user-images.githubusercontent.com/80510786/131215551-69e6f867-5743-49ab-9e63-bfe5b532027a.png)

Целта на играта е да се забавуваш и да освоиш што можно повеќе кредити.

[Back To The Top](#kung-fu-slot)

---

## Повеќе Информации

Со клик на инфо копчето играчот може да ја види добивката за 3 или 4 конекции за моменталниот износ на облог, како и сите можни линии на исплата, информации за бесплатните вртења и можноста за купување на бесплатни вртења.

![image](https://user-images.githubusercontent.com/80510786/131215641-6a309a0a-96b8-4d48-94f2-03c7710f4690.png)
![image](https://user-images.githubusercontent.com/80510786/131215644-de257ef3-01e7-480e-8d1a-b8b272403945.png)

[Back To The Top](#kung-fu-slot)

---

## Линии на исплата

Кога има погодок во некоја од добитните линии во позадината на соодветните слики се исцртува линија која ги спојува и црвена позадина со кинески змеј.
Во десниот агол се покажува добивката за погодените линии.

![image](https://user-images.githubusercontent.com/80510786/131215893-9982acdc-1046-4c3e-a0e9-24ee28eefc4f.png)

Сите можни комбинации во една слика:

![image](https://user-images.githubusercontent.com/80510786/131215896-4f76a992-0398-465c-9ca0-4344ee72baf1.png)

[Back To The Top](#kung-fu-slot)

---

## Бонус Вртења

  ### Погодок на бонус вртења

При погодок на 3 или 4 свитоци се предизвикуваат 10 или 15 бонус вртења соодветно.

Играчот потоа го отвара свитокот и автоматски му се задава еден од бонус карактерите. Добиениот бонус карактер може да се замени само еднаш со клик на копчето “Reroll”. Потоа при клик на копчето “Proceed to Panda Palace” играчот оди во Бонус нивото.

![image](https://user-images.githubusercontent.com/80510786/131215934-2d433329-8099-46cc-a2c9-a2c28b021773.png)

  ### Купување на бонус вртења

Бонус вртењата може да се купат со помош на “Buy Feature” опцијата.

При клик на “Buy Feature” копчето играчот ќе се праша дали сака да потроши
 (моменталн влог X 100) за да купи 10 вртења.

![image](https://user-images.githubusercontent.com/80510786/131215946-832afd0d-ed92-4853-b944-a26b87aa81ce.png)

 До “Buy Feature” копчето може да се достапи само доколку играчот има доволно кредит.

  ### Бонус ниво

Во Бонус нивото играчот освен нормалните линии на исплата има можност на добивка преку бонус карактерите. Кога на екранот ќе се појават два или повеќе бонус карактери на било кое место се смета за погодок и се означуваат погодените слики со виолетов змеј наместо црвен. 

Играчот исто така може да добие 3 или повеќе свитоци и да си го зголеми бројот на останати вртења.

По искористување на сите вртења играчот се враќа на нормалнто ниво.

![image](https://user-images.githubusercontent.com/80510786/131215964-2334396f-390e-4999-8a1a-221ef3e689c2.png)

[Back To The Top](#kung-fu-slot)

---

## Прекин на сесија

При клик на Escape на тастатурата се појавува на екран порака дали играчот сака да се врати на главното мени или да ја прекине сесијата.

![image](https://user-images.githubusercontent.com/80510786/131216519-f5ab0eb1-b949-4a3f-a88f-0aadea46006c.png)

Исто така може да се прекине сесијата при клик на X копчето.

[Back To The Top](#kung-fu-slot)

---

## Музика

Во нормалното ниво користиме Oogway Ascends - https://www.youtube.com/watch?v=KtMnDmuhKQs

А во бонус нивото користиме Kung Fu Fighting – https://www.youtube.com/watch?v=QspjKVTMlL8

Музиката e имплементирана со помош на WindowsMediaPlayer што е веќе постоечка класа во C# во библиотеката WMPLib.

При клик на копчето за звук започнува музиката и при приближување на маусот до копчето за звук се појавува контрола за подесување на јачината.
При повторен клик на копчето за звук се прекинува.

![image](https://user-images.githubusercontent.com/80510786/131216551-cb877b2e-3ab0-4447-b3ad-7aa5b89ee0b2.png)

[Back To The Top](#kung-fu-slot)

---

## Изворен код

Со помош на Dictonary чуваме клучеви кои означуваат начини на исцртување на добитните линии (String) и вредноти кои означуваат листа од погодени слики (List<PictureBox>).  
  
На winningBoxes за клучевите "straight","down","up","V","^" им поставуваме празна листа.

```csharp
  Dictionary<string, List<PictureBox>> winningBoxes { get; set; }
```
  
```csharp
  winningBoxes = new Dictionary<string, List<PictureBox>>()
  {
      { "straight", new List<PictureBox>() {  } },
      { "down", new List<PictureBox>() {  } },
      { "up", new List<PictureBox>() {  } },
      { "V", new List<PictureBox>() {  } },
      { "^", new List<PictureBox>() {  } }
  };
```
  
Подолу е зададен пример како додаваме вредности во листата на Dictonary за погодените слики и стилот на линија која ќе се отцртува преку клучевите("straight","down","up","V","^").
  
```csharp
  if (p[0] == p[1] & p[1] == p[2] & p[0] != 8) // 1 red..
  {
      winningBoxes["straight"].Add(PictureBoxes[0]);
      winningBoxes["straight"].Add(PictureBoxes[1]);
      winningBoxes["straight"].Add(PictureBoxes[2]);

      if (p[2] == p[3]) // proverka za 4-to
      {
          winningBoxes["straight"].Add(PictureBoxes[3]);
          player.getConnected4(p[0]);
      }
      else
      {
          player.getConnected3(p[0]);
      }
  }
```
  
Во функцијата WonBoxes() на погодените слики им додаваме позадина со црвен змеј, па ја повукуваме Form1_Paint() со помош на Invalidate(true).
  
```csharp
  public void WonBoxes()
  {
      foreach (List<PictureBox> li in winningBoxes.Values)
      {
          foreach(PictureBox pb in li)
              pb.BackgroundImage = Image.FromFile("Pictures/win-img.png");
      }
      Invalidate(true);
  }
```

Во Form1_Paint() за секој клуч од Dictionary доколку постои се исцртува соодветна линија според клучот на листата од погодени слики.

```csharp
  private void Form1_Paint(object sender, PaintEventArgs e)
  {
      // straight, down, up, v, ^

      if (winningBoxes.TryGetValue("straight",out List<PictureBox> straight))
      {
          foreach(PictureBox pb in straight)
          {
              Graphics g = pb.CreateGraphics();

              g.DrawLine(
                  new Pen(Color.Blue, 2f),
                  new Point(0, pb.Size.Height / 2),
                  new Point(pb.Size.Width, pb.Size.Height / 2));

              g.Dispose();
          }
      }

      if (winningBoxes.TryGetValue("down", out List<PictureBox> down))
      {
          foreach (PictureBox pb in down)
          {
              Graphics g = pb.CreateGraphics();

              g.DrawLine(
                  new Pen(Color.White, 2f),
                  new Point(0, 0),
                  new Point(pb.Size.Width, pb.Size.Height));

              g.Dispose();
          }
      }

      if (winningBoxes.TryGetValue("up", out List<PictureBox> up))
      {
          foreach (PictureBox pb in up)
          {
              Graphics g = pb.CreateGraphics();

              g.DrawLine(
                  new Pen(Color.White, 2f),
                  new Point(0, pb.Size.Height),
                  new Point(pb.Size.Width, 0));

              g.Dispose();
          }
      }

      if (winningBoxes.TryGetValue("V", out List<PictureBox> v))
      {
          foreach (PictureBox pb in v)
          {
              Graphics g = pb.CreateGraphics();

              g.DrawLine(
                  new Pen(Color.White, 2f),
                  new Point(0, 0), 
                  new Point(pb.Size.Width / 2, pb.Size.Height / 2));

              g.DrawLine(
                  new Pen(Color.White, 2f),
                  new Point(pb.Size.Width / 2, pb.Size.Height / 2),
                  new Point(pb.Size.Width, 0));

              g.Dispose();
          }
      }

      if (winningBoxes.TryGetValue("^", out List<PictureBox> unV))
      {
          foreach (PictureBox pb in unV)
          {
              Graphics g = pb.CreateGraphics();

              g.DrawLine(
                  new Pen(Color.White, 2f),
                  new Point(0, pb.Size.Height),
                  new Point(pb.Size.Width / 2, pb.Size.Height / 2));

              g.DrawLine(
                  new Pen(Color.White, 2f),
                  new Point(pb.Size.Width / 2, pb.Size.Height / 2),
                  new Point(pb.Size.Width, pb.Size.Height));

              g.Dispose();
          }
      }
  }
```
  
Кога играчот ќе кликне на копчето "Spin" се повикува функцијата WonBoxesToNormal() која ги поставува позадините на погодените слики на null и вредностите во Dictionary ги пребришуваме со користење на Clear() за секој key.
  
```csharp
  public void WonBoxesToNormal()
  {
      foreach (List<PictureBox> kvp in winningBoxes.Values)
      {
          foreach (PictureBox pb in kvp)
          {
              pb.BackColor = Color.Transparent;
              pb.BackgroundImage = null;
              pb.BorderStyle = BorderStyle.None;
          }
      }

      // winningBoxes.Clear() but keeping the keys
      winningBoxes["straight"].Clear();
      winningBoxes["down"].Clear();
      winningBoxes["up"].Clear();
      winningBoxes["^"].Clear();
      winningBoxes["V"].Clear();

  }
```
  
[Back To The Top](#kung-fu-slot)
  
---
  
  ## Информации за авторите
  
  - Никола Гилев 196131
  - Марко Зорески 191225
  
  [Back To The Top](#kung-fu-slot)
