using System;

class Program
{

    static void Main(string[] args)
    {

        /* Algoritmayı kısaca özetlemek gerekirse birbirlerinin paraşütünü ya da kendilerini bulana kadar sürekli + ve - yönlenderde +1 -2 +3 şeklinde gezecekler
        eğer birbirlerini bulursa zaten program amacına ulaşacak eğer paraşütlerini bulurlarsa geldikleri yönde gitmeye devam edeceklerdi ama simülasyon olduğu için
        paraşütte buluşmuşlar gibi gösterdim çünkü kodda yerlerini adım adım değil de zıplayarak değiştirdiklerinden
         birbirlerini hareket ederken göremiyorlar aslında eğer bunu yapmam gerekiyorsa
        ek bir while'da 1-1 ilerleterek yapabilirdim ama gerek olmayacağını düşündüm.
      


        /* Durumu tek sayfa olarak yazmadım çünkü her bir robota o algoritmayı yükleyeceğimizi söylediğiniz olayı görselleştirmek amacımız olmasa da class yapısında gösterdim. */







        Robot robotUno = new Robot(-100);    // Örnek olması için int olarak + - sonsuz aralığında atadım değerleri long da yapabilirsiniz isterseniz tüm değerleri
        Robot robotDos = new Robot(12);



        int prev = robotUno.position;
        int current = robotDos.position;




        while (!robotUno.sawOtherRobot)
        {

            if (!robotUno.sawOtherParachute)
            { // Bir önceki konumlarını tutuyoruz
                prev = robotUno.position;
                robotUno.Move();
                current = robotUno.position;

            }

            if (!robotDos.sawOtherParachute)
            {
                // Bir önceki konumlarını tutuyoruz
                prev = robotDos.position;
                robotDos.Move();
                current = robotDos.position;

            }




            if (robotUno.sawOtherParachute || robotDos.sawOtherParachute)
            {
               
                if (isBetween(prev, current, robotDos.position) || isBetween(prev, current, robotUno.position))
                {

                    // Eğer hareket eden robotun gideceği yönde diğer robot varsa

                    robotUno.sawOtherRobot = true; // Birbirlerini buldular Ama Bu değeri Göstermelik koyuyoruz break ile kıracağız aslında whileı
                    if (!robotUno.sawOtherParachute)
                    { // Robot 2 bekleyen Robot 1 hareket eden oluyor
                        robotUno.position = robotDos.position;
                        // Yol üstünde diğer robotu görünce dur demek aslında bu

                    }
                    else
                    {
                        // Robot 1 bekleyen Robot 2 hareket eden oluyor
                        robotDos.position = robotUno.position;

                    }
                    System.Console.WriteLine("Final Positions for Robot 1 and Robot 2: " + robotUno.position + " " + robotDos.position);
                    break;

                }
            }

            System.Console.WriteLine("Positions for Robot 1 and Robot 2: " + robotUno.position + " " + robotDos.position);

            if (robotUno.position == robotDos.parachutePosition)
            {
                System.Console.WriteLine("Robot One Saw Robot Two's Parachute and It's waiting there");

                robotUno.sawOtherParachute = true;

            }
            if (robotDos.position == robotUno.parachutePosition)
            {

                System.Console.WriteLine("Robot Two Saw Robot One's Parachute and It's waiting there");

                robotDos.sawOtherParachute = true;
              

            }






        }





        static int RandomValue()
        {
            Random rndm = new Random();

            return (int.MaxValue * rndm.Next()) + (int.MinValue * rndm.Next());
        }
    }

    static bool isBetween(int a, int b, int number)
    {
        if (a > b)
        {

            int temp = a;
            a = b;
            b = temp;
        }

        if (a < number && b > number)
        {

            return true;
        }
        return false;
    }

}