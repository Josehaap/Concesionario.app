using System;

namespace LibsClass;

public class Catalogo
{
    private List<Coche> _listadoCoches;
    public List<Coche> ListadoCoches => _listadoCoches;

    /// <summary>
    /// Constructor que nos permite crear un catalogo con una lista predefinida de coches. 
    /// </summary>
    /// <param name="listadoCoches"></param>
    public Catalogo(List<Coche>? listadoCoches = null)
    {
        _listadoCoches = listadoCoches ?? new List<Coche>();

        if (listadoCoches is null)
        {
            _listadoCoches = ObtenerVehiculos();
        }
    }

    /// <summary>
    /// Metodo de instancia que nos permite agregar un nuevo coche a un acatalogo ya creado 
    /// </summary>
    /// <param name="coche"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void AgregarCoche(Coche? coche)
    {
        if (coche == null)
            throw new ArgumentNullException(nameof(coche));

        _listadoCoches.Add(coche);
    }

    /// <summary>
    /// Método para eliminar un coche
    /// </summary>
    /// <param name="coche"></param>
    /// <returns></returns>
    public bool EliminarCoche(Coche coche)
    {
        return _listadoCoches.Remove(coche);
    }

    /// <summary>
    /// Metodo de instancia que nos permite buscar coches en el catalogo por el nombre de su marca creando una nueva lista filtrada
    /// </summary>
    /// <param name="marca"></param>
    /// <returns></returns>
    public List<Coche> BuscarPorMarca(string marca)
    {
        return _listadoCoches
            .Where(c => c.Marca.Contains(marca, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

public static List<Coche> ObtenerVehiculos()
{
    return new List<Coche>
    {
        new Coche("Toyota", "Corolla", "Sedán compacto de bajo consumo", 2020, TiposCombustibles.Electrico, 210, "toyota_corolla_1.jpg"),
        new Coche("Ford", "Mustang", "Deportivo clásico con un diseño agresivo", 2021, TiposCombustibles.Gasolina, 250, "ford_mustang_1.jpg"),
        new Coche("Tesla", "Model 3", "Eléctrico de gama media, ideal para el día a día", 2022, TiposCombustibles.Electrico, 225),
        new Coche("Chevrolet", "Camaro", "Coupé deportivo con un motor potente", 2019, TiposCombustibles.Gasolina, 300, "chevrolet_camaro_1.jpg"),
        new Coche("Honda", "Civic", "Compacto económico con buen rendimiento de combustible", 2021, TiposCombustibles.Gasolina, 220, "honda_civic_1.jpg"),
        new Coche("BMW", "M3", "Deportivo de alto rendimiento con tecnología avanzada", 2020, TiposCombustibles.Gasolina, 280, "bmw_m3_1.png"),
        new Coche("Audi", "A4", "Sedán de lujo con una excelente dinámica de conducción", 2022, TiposCombustibles.Gasolina, 240, "Audi_1.jpg"),
        new Coche("Mercedes-Benz", "C-Class", "Elegante sedán de lujo con tecnología avanzada", 2021, TiposCombustibles.Gasolina, 250),
        new Coche("Porsche", "911", "Deportivo icónico con un motor de altas prestaciones", 2020, TiposCombustibles.Gasolina, 320, "porche_911_1.jpg"),
        new Coche("Nissan", "Leaf", "Coche eléctrico asequible y ecológico", 2021, TiposCombustibles.Electrico, 180),
        new Coche("Mazda", "MX-5", "Coupé pequeño y ligero con excelente manejo", 2019, TiposCombustibles.Gasolina, 240, "mazda_mx_5_1.jpg"),
        new Coche("Ford", "F-150", "Camioneta robusta, ideal para trabajo pesado", 2021, TiposCombustibles.Gasolina, 200, "ford_f-150_1.jpg"),
        new Coche("Jeep", "Wrangler", "SUV todoterreno con gran capacidad de aventura", 2022, TiposCombustibles.Gasolina, 210, "jeep_wrangler_1.jpg"),
        new Coche("Toyota", "Prius", "Híbrido compacto, ideal para ahorro de combustible", 2020, TiposCombustibles.Hibrido, 180),
        new Coche("Hyundai", "Kona", "SUV pequeño, perfecto para la ciudad", 2021, TiposCombustibles.Gasolina, 200, "hyundai_kona_1.jpg"),
        new Coche("Chevrolet", "Silverado", "Camioneta de gran tamaño, ideal para remolcar", 2021, TiposCombustibles.Gasolina, 230, "chevrolet_silverado_1.jpg"),
        new Coche("Subaru", "Outback", "SUV con capacidad para todo tipo de terrenos", 2020, TiposCombustibles.Gasolina, 210),
        new Coche("Kia", "Sportage", "SUV con un buen balance entre precio y calidad", 2021, TiposCombustibles.Gasolina, 220, "kia_sportage_1.jpg"),
        new Coche("Tesla", "Model S", "Eléctrico de lujo con tecnología avanzada y gran autonomía", 2022, TiposCombustibles.Electrico, 250),
        new Coche("BMW", "X5", "SUV de lujo con grandes capacidades de manejo y confort", 2021, TiposCombustibles.Gasolina, 240, "BMWX5_1.jpg")
    };
}

}

