using TrenApi_2.Models;

namespace TrenApi_2.Services;

public static class TrainService
{
    static List<Train> Trains { get; }
    static List<Carriage> _vagonsDogu { get; }
    static List<Carriage> _vagonsBaskent { get; }
    static int nextId = 2;
    static TrainService()
    {
        _vagonsDogu = new List<Carriage>
        {
            new Carriage { Id= 1, Capacity = 100, Occupancy = 80},
            new Carriage { Id= 2, Capacity = 90, Occupancy = 40},
            new Carriage{ Id= 3, Capacity = 80, Occupancy = 20},
            new Carriage{ Id= 4, Capacity = 120, Occupancy = 30}
        };
        _vagonsBaskent = new List<Carriage>
        {
            new Carriage { Id= 1, Capacity = 90, Occupancy = 40},
            new Carriage { Id= 2, Capacity = 120, Occupancy = 20},
            new Carriage{ Id= 3, Capacity = 70, Occupancy = 0},
            new Carriage{ Id= 4, Capacity = 120, Occupancy = 0}
        };
        Trains = new List<Train>
        {
            new Train { Id = 1, Name = "Doğu Ekspresi", Carriages = _vagonsDogu },
            new Train { Id = 2, Name = "Başkent Ekspresi", Carriages = _vagonsBaskent}
        };
    }

    public static List<Train> GetAll() => Trains;

    public static Train? Get(int id) => Trains.FirstOrDefault(x => x.Id == id);


    public static void Add(Train train)
    {
        train.Id = nextId++;
        Trains.Add(train);
    }
    //Merhaba ben Mert,
    /*  Proje dökümanında  "KisilerFarkliVagonlaraYerlestirilebilir"(Bu parametreyi "together" olarak tanımlayıp projede ters uyguladım) parametresi true(false) verildiğinde 
    ve vagonların toplamında "RezervasyonYapilacakKisiSayisi" parametresi kadar yer olmadığında boş liste döndürmesi şeklinde bir programlama isteniyor gibi görünüyordu.
    Bu kullanıcının sürekli uygun koltuk sayısını bulana kadar deneme yapmasını gerektireceğinden, bu gibi bir durumda, hangi vagonda kaç uygun koltuk varsa, buna uygun
    şekilde bir liste döndürmesi için programladım.
    Sonuç olarak patronlar boş koltukları sevmez. :)
        Proje için birkaç gün vakit ayırmam gerekti. Bunun sebebi daha önce API yazmamış olmamdı. Yeteri kadar ilgilenmediğimi düşünmenizi istemem. Yazarken 
    Microsoft dökümanları ve notlarımdan faydalandım. Bundan önce yazmış olduğum, OOP repositorisinin altındaki _PiggyBank projesini de incelemeniz beni mutlu eder.
    Çok yararlı birkaç gün geçirdim. Bunun için de ayrıca teşekkür ederim. 
    İyi çalışmalar dilerim. */

    public static List<Detail> CheckReservation(int id, int person, bool together)
    {
        List<Detail> _yerlesim = new List<Detail>();
        int _person = person;
        var train = Get(id);
        Detail detail;

        if (together == true)
        { 
            foreach (Carriage item in train.Carriages)
            {
                if (item.Occupancy + person <= (item.Capacity*0.70))
                {
                    detail = new Detail()
                    {
                        carriage = item.ToString(),
                        PersonCount = person,
                        RezOk = true

                    };
                    _yerlesim.Add(detail);
                    break;
                }
            }
        }
        else
        {
            if (_person > 0)
            {
                double suitable = 0;
                foreach (var item in train.Carriages)
                {
                    suitable = (item.Capacity * 0.70) - item.Occupancy;
                    if (_person > suitable && suitable > 0)
                    {
                        detail = new Detail()
                        {
                            carriage =item.ToString(),
                            PersonCount = (int)suitable,
                            RezOk = true
                        };
                        _yerlesim.Add(detail);
                        _person = _person - (int)suitable;
                    }
                    else if (_person <= suitable && _person > 0)
                     {
                        detail = new Detail()
                        {
                            carriage=item.ToString(),
                            PersonCount= _person,
                            RezOk = true
                        };
                        _yerlesim.Add(detail);
                        _person = 0;
                    }
                }
            }
        }
        return _yerlesim;
    }

    public static void Delete(int id)
    {
        var tren = Get(id);
        if (tren == null)
        { return; }
        else
        {
            Trains.Remove(tren);
        }
    }
}


