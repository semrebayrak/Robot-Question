class Robot
{
    public int position { get; set; }
    public int parachutePosition { get; set;}
    public int counter {get; set;}

    public bool sawOtherRobot { get; set; } = false;
    public bool sawOtherParachute { get; set; } = false;
    public Robot(int position)
    {
        this.position = position;
        this.parachutePosition = position;
    }

    public void Move()
    {
        if (!sawOtherParachute)
        {



            if (counter % 2 == 0)
            {
                counter = -(counter - 1); // +1 +3 +5...
            }
            else
            {
                counter = -(counter + 1); // -2 -4 -6...
            }

            this.position += counter;

        }
       
        // Gerçek hayatta olsa bu fonksiyon da olmalıydı bu sayede daha kısa sürede bulurlardı birbirlerini. Paraşüt üzerinde değil yol üzerinde karşılaşırlardı
      /*   else
        {
            this.position += counter; // Eğer paraşütü bulup whiledan çıktıysa artık o yönde devam edecek diğer robotu bulana kadar

        }*/
    }




}
