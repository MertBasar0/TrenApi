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
            new Carriage { Id= 2, Capacity = 90, Occupancy = 70},
            new Carriage{ Id= 3, Capacity = 80, Occupancy = 50},
            new Carriage{ Id= 4, Capacity = 120, Occupancy = 100}
        };
        _vagonsBaskent = new List<Carriage>
        {
            new Carriage { Id= 1, Capacity = 90, Occupancy = 70},
            new Carriage { Id= 2, Capacity = 120, Occupancy = 96},
            new Carriage{ Id= 3, Capacity = 70, Occupancy = 50},
            new Carriage{ Id= 4, Capacity = 120, Occupancy = 100}
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

    public static void CheckReservation(Train train, bool together)
    {
        if (together == true)
        {
            return;
        }
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

